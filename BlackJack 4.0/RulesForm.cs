using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack_4._0
{
    public partial class RulesForm : Form   // Displays the game rules to the player.
    {
        public RulesForm()
        {
            InitializeComponent();
            SetRulesText();     // Populate the text boxes with rules text.
        }

        private void RulesForm_Load(object sender, EventArgs e)
        {

        }

        public void SetRulesText() //Fills the text boxes with rules of the game.
        {
            var rulesTextPart1 = new StringBuilder();
            var rulesTextPart2 = new StringBuilder();

            rulesTextPart1.AppendLine("1. The goal of blackjack is to beat the dealer's hand without going over 21.");
            rulesTextPart1.Append(Environment.NewLine);
            rulesTextPart1.AppendLine("2. Face cards are worth 10. Aces are worth 11.");
            rulesTextPart1.Append(Environment.NewLine);
            rulesTextPart1.AppendLine("3. Each player starts with two cards, one of the dealer's cards is hidden until the end.");
            

            rulesTextPart2.AppendLine("4. To 'Hit' is to ask for another card. To 'Stand' is to hold your total and end your turn.");
            rulesTextPart2.Append(Environment.NewLine);
            rulesTextPart2.AppendLine("5. If you go over 21 you bust, and the dealer wins regardless of the dealer's hand.");
            rulesTextPart2.Append(Environment.NewLine);
            rulesTextPart2.AppendLine("6. If you are dealt 21 from the start (Ace & 10), you got a blackjack.");
            rulesTextPart2.Append(Environment.NewLine);
            rulesTextPart2.AppendLine("7. Dealer will hit until his/her cards total 17 or higher.");


            rchTxtBxRules1.Text = rulesTextPart1.ToString();
            rchTxtBxRules2.Text = rulesTextPart2.ToString();
        }

    }
}
