namespace _6.Excel
{
    using System;
    using System.Data.OleDb;
    using System.Data;

    /// <summary>
    /// Create an Excel file with 2 columns: name and score:
    /// Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            OleDbConnection dbCon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\Table.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\";");
            dbCon.Open();

            using (dbCon)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", dbCon);
                OleDbDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double score = (double)reader["Score"];
                        Console.WriteLine("{0} - score: {1}", name, score);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Second Way");
                Console.WriteLine("----------");
                DataTable dataSet = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [Sheet1$]", dbCon);
                adapter.Fill(dataSet);

                foreach (DataRow item in dataSet.Rows)
                {
                    Console.WriteLine("{0} - score: {1}", item.ItemArray[0], item.ItemArray[1]);
                }
            }
        }
    }
}
