using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace LibraryApp
{
    public class BookRepository
    {
        public static List<Book> GetAll()
        {
            var list = new List<Book>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Books";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Book
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Autor"].ToString(),
                        ISBN = reader["ISBN"].ToString(),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    });
                }
            }
            return list;
        }

        public static Book GetById(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Books WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Book
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(), 
                        ISBN = reader["ISBN"].ToString(),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        ImageUrl = reader["ImageUrl"] == DBNull.Value ? null : reader["ImageUrl"].ToString()
                    };
                }
            }

            return null; 
        }

        public static void Add(Book book)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO Books (Title, Author, ISBN, Quantity, ImageUrl)
                         VALUES (@Title, @Author, @ISBN, @Quantity, @ImageUrl)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                cmd.Parameters.AddWithValue("@ImageUrl", book.ImageUrl);
                cmd.Parameters.AddWithValue("@Id", book.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
