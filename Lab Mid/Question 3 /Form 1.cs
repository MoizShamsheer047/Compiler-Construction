using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string registrationNumber = textBoxRegistrationNumber.Text;

            string password = GeneratePassword(firstName, lastName, registrationNumber);

            textBoxGeneratedPassword.Text = password;
        }

        private string GeneratePassword(string firstName, string lastName, string registrationNumber)
        {
            List<char> passwordChars = new List<char>();

            passwordChars.Add(char.ToUpper(firstName[0]));
            passwordChars.Add(char.ToUpper(lastName[0]));

            string specialCharacters = "!@#$%^&*";
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                passwordChars.Add(specialCharacters[random.Next(specialCharacters.Length)]);
            }

            // Add at least 4 numbers
            for (int i = 0; i < 4; i++)
            {
                passwordChars.Add(random.Next(10).ToString()[0]);
            }

            string lastTwoDigits = registrationNumber.Substring(registrationNumber.Length - 2);
            passwordChars.AddRange(lastTwoDigits);

            passwordChars.Add('4');
            passwordChars.Add('7');

            passwordChars = passwordChars.OrderBy(c => random.Next()).ToList();

            if (passwordChars.Count > 20)
            {
                passwordChars = passwordChars.GetRange(0, 20);
            }

            string password = new string(passwordChars.ToArray());
            return password;
        }
    }
}
