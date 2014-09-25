namespace _5.ReceiveImages
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    /// <summary>
    /// Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
    /// </summary>
    class Program
    {
        const string FILE_LOCATION = @"..\";
        const string FILE_EXTENSION = @".jpg";

        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=(localdb)\\v11.0; Database=Northwind; Integrated Security=true;");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT Picture, CategoryID, CategoryName FROM Categories", dbCon);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    byte[] image;
                    int categoryId;
                    string categoryName;

                    while (reader.Read())
                    {
                        image = (byte[])reader["Picture"];
                        categoryId = (int)reader["CategoryID"];
                        categoryName = (string)reader["CategoryName"];

                        int header = 78;                                            //little game with headers to save pictures properly
                        byte[] imgData = new byte[image.Length - header];
                        Array.Copy(image, 78, imgData, 0, image.Length - header);

                        ExtractImage(imgData, FILE_LOCATION + categoryId + FILE_EXTENSION);
                    }
                }

                Console.WriteLine("Images saved successfully!");
            }
        }

        static void ExtractImage(byte[] image, string location)
        {
            FileStream stream = new FileStream(location, FileMode.Create);

            using (stream)
            {
                stream.Write(image, 0, image.Length);
            }
        }
    }
}
