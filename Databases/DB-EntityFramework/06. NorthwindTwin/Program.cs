namespace _06.NorthwindTwin
{
    using System;
    using System.Linq;
    using NorthwindDB;
    using System.Data.Entity.Infrastructure;
    using System.IO;
    using System.Data.SqlClient;

    /// <summary>
    /// Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. 
    /// Find for the API for schema generation in MSDN or in Google.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IObjectContextAdapter context = new NorthwindEntities();
            string cloneNorthwind = context.ObjectContext.CreateDatabaseScript();

            string createNorthwindCloneDB = "CREATE DATABASE NorthwindTwin ON PRIMARY " +
                                            "(NAME = NorthwindTwin, " +
                                            "FILENAME = 'D:\\NorthwindTwin.mdf', " +
                                            "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                                            "LOG ON (NAME = NorthwindTwinLog, " +
                                            "FILENAME = 'D:\\NorthwindTwin.ldf', " +
                                            "SIZE = 1MB, " +
                                            "MAXSIZE = 5MB, " +
                                            "FILEGROWTH = 10%)";

            SqlConnection dbConForCreatingDB = new SqlConnection(
                "Server=.; " +
                "Database=master; " +
                "Integrated Security=true");

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                SqlCommand createDB = new SqlCommand(createNorthwindCloneDB, dbConForCreatingDB);
                createDB.ExecuteNonQuery();
            }

            SqlConnection dbConForCloning = new SqlConnection(
                "Server=.; " +
                "Database=NorthwindTwin; " +
                "Integrated Security=true");

            dbConForCloning.Open();

            using (dbConForCloning)
            {
                SqlCommand cloneDB = new SqlCommand(cloneNorthwind, dbConForCloning);
                cloneDB.ExecuteNonQuery();
            }
        }
    }
}
