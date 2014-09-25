namespace _4.AddProduct
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=(localdb)\\v11.0; Database=Northwind; Integrated Security=true;");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand("INSERT INTO Products VALUES ('Cake', 8, 1, '1 piece', 5.00, 25, 1, 10, 0)", dbCon);
                command.ExecuteNonQuery();

                Console.WriteLine("Successfully added. Now look in your Database! ;)");
            }
        }
    }
}
