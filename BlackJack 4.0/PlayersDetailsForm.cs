using System.Security.Cryptography;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BlackJack_4._0
{
    public partial class PlayersDetailsForm : Form
    {
         public RegistrationData PlayerData { get; set; } // Public property to get and set player registration data.
        
        // Constructor: Initializes the form components and player data.
        public PlayersDetailsForm()
        {
            InitializeComponent();
            PlayerData = new RegistrationData(); // Initialize PlayerData object to store player's details.

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //**********************************

        // Event handler for OK button click. Validates and saves player details.
        private void btnOk_Click(object sender, System.EventArgs e)
        {
            //Checks if all fields are not empty and contain valid values
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || !Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Z]+$") ||
                string.IsNullOrWhiteSpace(txtLastName.Text) || !Regex.IsMatch(txtLastName.Text, @"^[a-zA-Z]+$") ||
                !int.TryParse(txtAge.Text, out int age) ||
                cmbBxGender.SelectedIndex == -1 ||
                !chkBxTerms.Checked)
            {
                // Show message if validation fails.
                MessageBox.Show("Please enter all valid details and agree to the terms and conditions.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Save player details into PlayerData object.
            PlayerData.PlayerFirstName = txtFirstName.Text;
            PlayerData.PlayerLastName = txtLastName.Text;
            PlayerData.PlayerAge = age;
            PlayerData.PlayerGender = cmbBxGender.SelectedItem.ToString();

            // Check if the player's age is 21 or older
            if (age < 21)
            {
                MessageBox.Show("You must be at least 21 years old to play.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAge.Text = "";
                cmbBxGender.SelectedItem = null;
                chkBxTerms.Checked = false;
                txtFirstName.Focus();
                return;
                
            }

            //Displays the user details dialog and starts the game if the user confirms
            var confirmData = MessageBox.Show(
                $"Your Name is: {PlayerData.PlayerFirstName} {PlayerData.PlayerLastName} \n" +
                $"Your age is: {PlayerData.PlayerAge} \n" +
                $"Your gender is: {PlayerData.PlayerGender} \n" + "\n" +
                "Is this information correct?",
                "Confirmation player's details",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // If the user confirms, close the form and start the game
            if (confirmData == DialogResult.Yes) // Show PlayArea form and hide current form.
            {
                PlayArea playArea = new PlayArea();
                playArea.Show();
                playArea.FormClosed += PlayArea_FormClosed;
                this.Hide();
            }


            if (confirmData == DialogResult.No) // Reset form if player chooses to correct details.
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAge.Text = "";
                cmbBxGender.SelectedItem = null;
                chkBxTerms.Checked = false;
                txtFirstName.Focus();
            }
        } // end private void btnOk_Click
        //**********************************

        private void PlayArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close(); // Close PlayersDetailsForm when PlayArea form is closed.
        }

        //Pressing the Cancel button makes the details invalid. Clear all input fields and reset the form.
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
            cmbBxGender.SelectedItem = null;
            chkBxTerms.Checked = false;
            txtFirstName.Focus();
        }//**********************************

    } // end public partial class PlayersDetailsForm : Form
} // end namespace BlackJack_4._0
