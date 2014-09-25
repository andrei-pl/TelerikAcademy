namespace _3.ProductsInCategories
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Write a program that retrieves from the Northwind database all product categories and the names of the products in each category. 
    /// Can you do this with a single SQL query (with table join)?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=(localdb)\\v11.0; Database=Northwind; Integrated Security=true;");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c INNER JOIN Products p ON (p.CategoryID = c.CategoryID)" +
                 "GROUP BY c.CategoryName, p.ProductName", dbCon);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    string currentCategory = default(string);
 
                    while (reader.Read())
                    {
                        string category  = (string)reader["CategoryName"];
                        string product = (string)reader["ProductName"];
                        if (currentCategory != category)
                        {
                            Console.WriteLine();
                            Console.WriteLine(category.ToUpper());
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine();
                            currentCategory = category;
                        }
                        else
                        {
                            Console.WriteLine("\t {0}", product);
                        }
                    }
                }
            }
        }
    }
}
