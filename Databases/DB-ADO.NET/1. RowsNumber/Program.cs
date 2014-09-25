namespace _1.RowsNumber
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // !!! Всички задачи са ми правени на localdb сървъра, за това ако си работил/а на "." по-добре промени адреса преди каквито и да е проверки. !!!
            SqlConnection SqlCon = new SqlConnection("Server=.; Database=NorthWind; Integrated Security=true");
            SqlCon.Open();
            using (SqlCon)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", SqlCon);

                int result = (int)command.ExecuteScalar();
                Console.WriteLine("The Category table has " + result + " rows.");
            }
            //SqlCon.Close();
        }
    }
}
