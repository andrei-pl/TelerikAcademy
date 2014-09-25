using MySql.Data.MySqlClient;
using System;

namespace _9.MySql
{

    /// <summary>
    /// Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool . 
    /// Create a MySQL database to store Books (title, author, publish date and ISBN). 
    /// Write methods for listing all books, finding a book by name and adding a book.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Books.mwb са моделите, а StoreDB.sql е базата данни
        /// </summary>
        static MySqlConnection mySqlCon = new MySqlConnection(@"Server=localhost;Port=3306;Database=store;Uid=root;Pwd=12345678;");

        static void Main()
        {
            //AddBook("JS APPS", "Doncho", "2013", "987-222-14", mySqlCon); // ISBN is unique
            FindBook("JS APPS", mySqlCon);
            FindBook("Pod Igoto", mySqlCon);
            ShowListOfAllBooks(mySqlCon);
        }

        static void AddBook(string title, string author, string year, string ISBN, MySqlConnection mySqlConnection)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO books (title,author,publishDate,ISBN) VALUES (@title, @author, @year,@ISBN)", mySqlConnection);
            mySqlConnection.Open();
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@ISBN", ISBN);
            command.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        static void FindBook(string bookTitle, MySqlConnection connection)
        {
            MySqlCommand findCommand = new MySqlCommand
                ("SELECT author,title,publishDate FROM books WHERE title ='" + bookTitle + "';", connection);
            connection.Open();
            var reader = findCommand.ExecuteReader();

            using (reader)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string author = (string)reader["author"];
                        string title = (string)reader["title"];
                        string year = (string)reader["publishDate"];

                        Console.WriteLine("The book that you search for was written by {0} in {1} and it's title is {2}", author, year, title);
                    }
                }
                else
                {
                    Console.WriteLine("No bokks matched!");
                }
            }

            connection.Close();
        }


        static void ShowListOfAllBooks(MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand("SELECT title FROM Books", connection);
            connection.Open();
            var reader = command.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("Books in the database:");
                while (reader.Read())
                {
                    string bookTitle = (string)reader["title"];
                    Console.WriteLine(bookTitle);
                }
            }
            connection.Close();
        }
    }
}
