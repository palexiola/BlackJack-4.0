using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_4._0
{
    public class Card // Card class: Represents a single playing card with a suit and value.
    {
        // Properties
        public string Suit { get; set; }    // The suit of the card (Hearts, Diamonds, Clubs, Spades).
        public int Value { get; set; }  // The numeric value of the card.
        public string ImageName { get; private set; }   // The name of the image resource corresponding to the card.

        // ********** Constructor: Initializes a new card with specified suit and value. **********
        public Card(string suit, int value)
        {
            Suit = suit;
            Value = value;

            // Special handling for face cards and Aces
            if (value > 10 && value < 14)
            {
                Value = 10;
            }
            else if (value == 14) // Assuming 14 is used for Aces
            {
                Value = 11;
            }
            else
            {
                Value = value;
            }

            // Determine image name based on card's value and suit.
            if (value >= 2 && value <= 10)
            {
                ImageName = $"_{value}{suit[0].ToString().ToLower()}";
            }
            else
            {
                char suitInitial = suit[0].ToString().ToLower()[0];
                switch (value)
                {
                    case 11: ImageName = $"j{suit[0].ToString().ToLower()}"; break;
                    case 12: ImageName = $"q{suit[0].ToString().ToLower()}"; break;
                    case 13: ImageName = $"k{suit[0].ToString().ToLower()}"; break;
                    case 14: ImageName = $"a{suit[0].ToString().ToLower()}"; break; // Ace
                }
            }
        } // end Constructor public Card
    } // end public class Card 
} // namespace BlackJack_4._0
