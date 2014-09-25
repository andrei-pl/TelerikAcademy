namespace _8.FindString
{
    using System;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Write a program that reads a string from the console and finds all products that contain this string. 
    /// Ensure you handle correctly characters like ', %, ", \ and _.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string searchedString = Console.ReadLine();

            if (Regex.IsMatch(searchedString, "[^0-9a-zA-Z]", RegexOptions.CultureInvariant))
            {
                searchedString = "[" + searchedString + "]";
            }

            SqlConnection dbCon = new SqlConnection("Server=(localdb)\\v11.0; Database=Northwind; Integrated Security=true;");
            dbCon.Open();

            using (dbCon)
            {
                SqlParameter searchParameter = new SqlParameter();
                searchParameter.ParameterName = "@searchParameter";
                searchParameter.Value = string.Format("%{0}%", searchedString);

                SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE @searchParameter", dbCon);
                command.Parameters.Add(searchParameter);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string product = (string)reader["ProductName"];
                        Console.WriteLine(product);
                    }
                }
            }
        }
    }
}
