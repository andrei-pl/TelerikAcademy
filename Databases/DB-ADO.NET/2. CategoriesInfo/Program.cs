namespace _2.CategoriesInfo
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Write a program that retrieves the name and description of all categories in the Northwind DB.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=(localdb)\\v11.0; Database=Northwind; Integrated Security=true;");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0} - {1}", name, description);
                    }
                }
            }
        }
    }
}
