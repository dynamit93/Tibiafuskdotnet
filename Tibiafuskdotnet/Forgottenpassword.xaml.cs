using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Tibiafuskdotnet
{
    public partial class Forgottenpassword : Window
    {
        private MySqlConnection con; // Initialize your connection object

        public Forgottenpassword()
        {
            InitializeComponent();
            // Configure your connection object (e.g., using a connection string)
        }

        private void RestorePassword_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string email = Email.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your username and email address.");
                return;
            }

            string newPassword = GenerateRandomPassword(8);
            string hashedPassword = HashPassword(newPassword);

            con.Open();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "UPDATE accounts SET passwd=@password WHERE name=@username AND email=@email";
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    SendNewPasswordEmail(email, newPassword);
                    MessageBox.Show("Password reset successfully. Please check your email for the new password.");
                }
                else
                {
                    MessageBox.Show("Error: Invalid username or email address.");
                }
            }

            con.Close();
        }

        private string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();

            while (0 < length--)
            {
                res.Append(validChars[rnd.Next(validChars.Length)]);
            }

            return res.ToString();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    result.Append(bytes[i].ToString("x2"));
                }

                return result.ToString();
            }
        }

        private void SendNewPasswordEmail(string email, string newPassword)
        {
            // Set up your email sending configuration
            string fromAddress = "youremail@example.com";
            string subject = "Password Reset";
            string body = $"Your new password is: {newPassword}";

            MailMessage message = new MailMessage(fromAddress, email, subject, body);
            SmtpClient smtpClient = new SmtpClient("smtp.example.com"); // Configure your SMTP server address
            smtpClient.Credentials = new System.Net.NetworkCredential("youremail@example.com", "yourpassword"); // Configure your email and password
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
        }
    }
}
