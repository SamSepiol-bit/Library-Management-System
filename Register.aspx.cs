using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace LibraryApp
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            string passwordHash = ComputeSha256Hash(password);

            var librarian = new Librarian
            {
                FullName = fullName,
                Email = email,
                PasswordHash = passwordHash
            };

            bool success = LibrarianRepository.Register(librarian);
            if (success)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblMessage.Text = "Registration failed. Email may already be in use.";
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
