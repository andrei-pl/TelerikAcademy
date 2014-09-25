namespace _7.NewRowsInExcel
{
    using System;
    using System.Data.OleDb;

    /// <summary>
    /// Implement appending new rows to the Excel file.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            OleDbConnection dbCon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\Table.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\";");
            dbCon.Open();

            using (dbCon)
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO [Sheet1$] VALUES('Ivaylo Kenov','25')", dbCon);
                OleDbDataReader reader = command.ExecuteReader();

                Console.WriteLine("Successfully addded. Now look in the excel file!");
            }
        }
    }
}
