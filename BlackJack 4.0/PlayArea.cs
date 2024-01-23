using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BlackJack_4._0
{
    public partial class PlayArea : Form
    {
        private Deck deck;  // Represents the deck of cards used in the game.
        private List<Card> playerHand;  // Stores the cards currently in the player's hand.
        private List<Card> dealerHand;  // Stores the cards currently in the dealer's hand.
        private int playerScore;    // Current score of the player based on their hand.
        private int dealerScore;    // Current score of the dealer based on their hand.
        private PictureBox[] playerCards;   // Array of PictureBoxes to display the player's cards.
        private PictureBox[] dealerCards;   // Array of PictureBoxes to display the dealer's cards.
        private bool gameStarted = false;   // Flag to indicate if the game has started.

        // ********** Constructor: Initializes the form components and game elements. **********
        public PlayArea()
        {
            InitializeComponent();

            // Initialize the deck and hands for player and dealer
            deck = new Deck();
            playerHand = new List<Card>();
            dealerHand = new List<Card>();
            playerCards = new PictureBox[5] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            dealerCards = new PictureBox[5] { pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };


            ResetGame();    // Resets the game to its initial state.
        } // end constructor  public PlayArea()
        //**********************************************************


        // ********** Resets the game to start a new round. **********
        private void ResetGame()
        {
            // Reset visibility and images for player and dealer card PictureBoxes
            foreach (var pb in playerCards)
            {
                pb.Visible = false;
                pb.Image = null;
            }
            foreach (var pb in dealerCards)
            {
                pb.Visible = false;
                pb.Image = null;
            }

            // Resetting player and dealer scores and displaying them
            lblPlayerScore.Text = "Player's score: 0";
            lblDealerScore.Text = "Dealer's score: 0";

            // Set visibility for game control buttons
            btnHit.Visible = false;
            btnStand.Visible = false;
            btnDeal.Visible = true;

            // Clear player and dealer hands and shuffle the deck
            playerHand.Clear();
            dealerHand.Clear();
            playerScore = 0;
            dealerScore = 0;
            deck.Shuffle();
        } // end private void ResetGame()
        //**********************************************************


        // ********** the user clicks the "Deal" button **********
        private void btnDeal_Click(object sender, EventArgs e)
        {
            ResetGame();    // Resets the game for a new round.
            gameStarted = true;     // Set the gameStarted flag to true.
            btnDeal.Visible = false;
            btnHit.Visible = true;
            btnStand.Visible = true;

            // The player receives two cards
            DrawCardForPlayer();
            DrawCardForPlayer();

            // The dealer receives two cards, but only one is shown
            DrawCardForDealer();
            dealerCards[1].Visible = true;

            UpdateScores();     // Update scores based on the initial cards dealt.
            CheckForBlackjack();    // Check if the player or dealer has a blackjack.
        } // end private void btnDeal_Click()
          //**********************************************************


        // ********** Draws a card for the player and updates the game state. **********
        private void DrawCardForPlayer()
        {
            if (playerHand.Count < 5)
            {
                var card = deck.DrawCard();
                playerHand.Add(card);
                var playerCardPb = playerCards[playerHand.Count - 1];
                playerCardPb.Visible = true;
                playerCardPb.Image = GetCardImage(card);
            }

            UpdateScores(); // Update player's score after drawing a card.
            if (playerScore > 21) // Check for bust or automatic win conditions
            {
                MessageBox.Show("Bust! You've exceeded 21. Dealer wins.");
                ResetGame();
            }
        } // end private void DrawCardForPlayer()
        //**********************************************************

        // ********** Draws a card for the dealer. **********
        private void DrawCardForDealer()
        {
            // Draw two cards for the dealer but only show the first one
            var card1 = deck.DrawCard();
            dealerHand.Add(card1);
            dealerCards[0].Visible = true;
            dealerCards[0].Image = GetCardImage(card1);

            var card2 = deck.DrawCard();
            dealerHand.Add(card2);
            // The second dealer card is face down and not shown
            dealerCards[1].Image = Properties.Resources.red_back_of_cards;
        }// end private void DrawCardForDealer()
        //**********************************************************


        // ********** Retrieves the image for a given card. **********
        private Image GetCardImage(Card card)
        {
            // Використання рефлексії для отримання зображення картки за її ім'ям
            // string resourceName = "_" + card.Value.ToString() + card.Suit.Substring(0, 1).ToLower();
            var imageResource = Properties.Resources.ResourceManager.GetObject(card.ImageName);
            return (Image)imageResource;
        }
        //**********************************************************

        // ********** Updates the scores for both player and dealer. **********
        private void UpdateScores() 
        {
            playerScore = CalculateScore(playerHand);
            lblPlayerScore.Text = "Your score: " + playerScore.ToString();

            // Display only the score of the first card of the dealer until the player stands
            dealerScore = CalculateScore(dealerHand);
            lblDealerScore.Text = "Dealer's score: " + (dealerHand.Any() ? dealerHand[0].Value.ToString() : "0");

        }
        //**********************************************************

        // ********** Calculates the total score for a given hand of cards. **********
        private int CalculateScore(List<Card> hand)
        {
            int score = 0;
            foreach (var card in hand)
            {
                score += card.Value;
            }
            return score;
        }
        //**********************************************************

        // ********** Checks if the player or dealer has a BlackJack. **********
        private void CheckForBlackjack()
        {
            if (playerScore == 21)
            {
                MessageBox.Show("Blackjack! You win!");
                ResetGame();
            }
        }
        //**********************************************************

        // ********** the user clicks the "Hit" button **********
        private void btnHit_Click(object sender, EventArgs e)
        {
            DrawCardForPlayer(); // Player draws an additional card.
            UpdateScores(); // Update scores after drawing a card.

            if (playerScore > 21)
            {
                endGame("Bust! You've exceeded 21. Dealer wins.");
            }
            else if (playerScore == 21)
            {
                endGame("Blackjack! You win!");
            }
        }
        //**********************************************************

        // ********** the user clicks the "Stand" button **********
        private void btnStand_Click(object sender, EventArgs e)
        {
            // Reveal the dealer's second card
            dealerCards[1].Image = GetCardImage(dealerHand[1]);
            dealerCards[1].Visible = true;

            RevealDealersCards(); // Reveal the dealer's second card and any additional cards if necessary
            UpdateScores(); // update the dealer's score display with the full score
            DetermineWinner();  // Determine the winner
        }
        //**********************************************************

        // ********** Reveal all of the dealer's cards and decide the next action based on scores. **********
        private void RevealDealersCards() //The dealer always stops between 17-25
        {
            dealerCards[1].Image = GetCardImage(dealerHand[1]);
            dealerCards[1].Visible = true;


            // Update the dealer's score with both cards now revealed.
            dealerScore = CalculateScore(dealerHand); 
            lblDealerScore.Text = "Dealer's score: " + dealerScore.ToString();


            // Draw additional cards for the dealer until the score is 17 or higher.
            while (dealerScore < 17 && dealerHand.Count < 5)
            {
                if (deck.IsDeckEmpty()) 
                {
                    MessageBox.Show("The deck is out of cards.");
                    endGame("Game ended due to lack of cards.");
                    break; // Exit the loop if there are no cards left to draw.
                }

                Card newCard = deck.DrawCard();
                dealerHand.Add(newCard);
                dealerScore += newCard.Value;

                
                PictureBox pb = dealerCards[dealerHand.Count - 1];
                pb.Image = GetCardImage(newCard);
                pb.Visible = true;
            }

            // Ensure the dealer's score does not exceed 25
            dealerScore = Math.Min(dealerScore, 25);
            lblDealerScore.Text = "Dealer's score: " + dealerScore.ToString();

            DetermineWinner();
        } // end private void RevealDealersCards() 
        //**********************************************************

        // ********** Determines the winner of the round and ends the game. **********
        private void DetermineWinner()
        {
            // Only determine a winner if the game has started
            if (!gameStarted) return;

            if (playerScore == 21)
            {
                endGame("BlackJack! You win!");
            }
            else if (dealerScore > 21)
            {
                endGame("Dealer busts. You win!");
            }
            else if (playerScore > 21)
            {
                endGame("Bust! You've exceeded 21. Dealer wins.");
            }
            else if (playerScore < dealerScore && dealerScore <= 21)
            {
                endGame("Dealer wins!");
            }
            else if (playerScore > dealerScore)
            {
                endGame("You win!");
            }
            else if (playerScore == dealerScore)
            {
                endGame("It's a draw!");
            }
        } // end  private void DetermineWinner()

        private void PlayArea_Load(object sender, EventArgs e)
        {
            Refresh();
            pictureBox2.BringToFront();
            pictureBox3.BringToFront();
            pictureBox4.BringToFront();
            pictureBox5.BringToFront();
        }


        // ********** Ends the current game round and offers an option to play again. **********
        private void endGame(string message)
        {
            MessageBox.Show(message);
            gameStarted = false;
            var result = MessageBox.Show("Do you want to play again?", "Game Over", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ResetGame();
            }
            else
            {
                this.Close();
            }
        } // end private void endGame

        // ********** the user clicks the "New Game" button  **********
        private void mnuNewGame_Click(object sender, EventArgs e)
        {
            ResetGame();
            btnDeal.Visible = true;
            btnDeal.Enabled = true;
        }

        // ********** the user clicks the "Exit" button  **********
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuRules_Click(object sender, EventArgs e)
        {
            using (RulesForm formRules = new RulesForm())
            {
                formRules.ShowDialog();
            }
        }
    } // public partial class PlayArea : Form
} // end namespace BlackJack_4._0
