namespace _10.SqlLite
{
    using System;
    using System.Data.SQLite;

    /// <summary>
    /// Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).
    /// </summary>
    class Program
    {
        static void Main()
        {
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=..\\..\\Store.db;Version=3;");
            AddBook(3, "JS UI", "Doncho", 2013, "911-22-11", connection);
            FindBook("JS UI", connection);
            FindBook("Doncho world!", connection);
            ShowListOfAllBooks(connection);
        }

        static void AddBook(int id, string title, string author, int year, string isbn, SQLiteConnection mySqlConnection)
        {
            SQLiteCommand command = new SQLiteCommand("INSERT INTO Books (idBooks,title,author,publishDate,isbn) VALUES (@id,@title, @author, @year,@isbn)", mySqlConnection);
            mySqlConnection.Open();
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@isbn", isbn);
            command.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        static void FindBook(string bookTitle, SQLiteConnection connection)
        {
            SQLiteCommand findCommand = new SQLiteCommand
                ("SELECT author,title,publishDate FROM books WHERE title ='" + bookTitle + "';", connection);
            connection.Open();
            var reader = findCommand.ExecuteReader();

            if (reader.HasRows)
            {
                using (reader)
                {
                    while (reader.Read())
                    {
                        string author = (string)reader["author"];
                        string title = (string)reader["title"];
                        string year = (string)reader["publishDate"];

                        Console.WriteLine("The book that you search for was written by {0} in {1} and it's title is {2}", author, year, title);
                    }
                }
            }
            else
            {
                Console.WriteLine("No books matched with searched criteria!");
            }
            connection.Close();
        }

        static void ShowListOfAllBooks(SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT title FROM Books", connection);
            connection.Open();
            var reader = command.ExecuteReader();

            using (reader)
            {
                Console.WriteLine();
                Console.WriteLine("Books in the database:");
                Console.WriteLine("----------------------------------------------");
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
