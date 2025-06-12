using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace LibraryApp
{
    public class LibrarianRepository
    {
        public static bool Register(Librarian librarian)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Librarians (FullName, Email, PasswordHash) " + "VALUES @FullName, @Email, @PasswordHash)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", librarian.FullName);
                cmd.Parameters.AddWithValue("@Email", librarian.Email);
                cmd.Parameters.AddWithValue("@PasswordHash", librarian.PasswordHash);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static Librarian Login(string email, string passwordHash)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Librarians WHERE Email = @Email " + "AND PasswordHash = @PasswordHash";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    return new Librarian
                    {
                        Id = (int)reader["Id"],
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString()
                    };
                }
            }
            return null;
        }
    }
}
