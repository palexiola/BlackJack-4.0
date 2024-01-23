using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_4._0
{
    public class Deck   // Deck class: Represents a deck of cards used in the game.
    {
        private List<Card> cards; // Collection of cards in the deck.


        public Deck() // Constructor: Initializes and populates a new deck of cards.
        {
            // Populate the deck with cards
            cards = new List<Card>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            for (int i = 2; i <= 10; i++)
            {
                foreach (var suit in suits)
                {
                    cards.Add(new Card(suit, i));
                }
            }
            foreach (var suit in suits)
            {
                cards.Add(new Card(suit, 10)); // Jack
                cards.Add(new Card(suit, 10)); // Queen
                cards.Add(new Card(suit, 10)); // King
                cards.Add(new Card(suit, 11)); // Ace
            }
            Shuffle();  // Shuffle the deck after creation.
        } // end Constructor  public Deck()

        public void Shuffle() //  Randomizes the order of cards in the deck.
        {
            Random rnd = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        } // **********

        public bool IsDeckEmpty() // Checks if the deck has any cards left.
        {
            return cards.Count == 0;
        } // **********

        public Card DrawCard() //  Draws the top card from the deck and removes it.
        {
            if (!IsDeckEmpty())
            {
                var card = cards[0];
                cards.RemoveAt(0);
                return card;
            }
            else
            {
                throw new InvalidOperationException("No cards left in the deck.");
            }
        } // **********

    }  // end public class Deck  
} // end namespace BlackJack_4._0
