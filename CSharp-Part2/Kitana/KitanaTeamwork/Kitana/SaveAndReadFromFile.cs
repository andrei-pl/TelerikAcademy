﻿using System;
using System.Web;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Permissions;



namespace Kitana_01
{

    public class SaveReadToFile
    {
        [STAThread]
        public static void Serialize(Object obj, String pathFile)
        {
            FileStream fs = new FileStream(pathFile, FileMode.Create);

            try
            {
                // Construct a BinaryFormatter and use it  
                // to serialize the data to the stream.
                BinaryFormatter formatter = new BinaryFormatter();

                // Serialize element.
                formatter.Serialize(fs, obj);
            }
            catch (SerializationException e)
            {
                //Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw new FieldAccessException("Failed to deserialize. Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        public static Object Deserialize(string pathFile)
        {
            // Open the file containing the data that you want to deserialize.
            FileStream fs = null;
            Object obj = new Object();
            obj = null;
            try
            {
                // Construct a BinaryFormatter and use it  
                // to serialize the data to the stream.
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and  
                // assign the reference to the local variable.
                if (File.Exists(pathFile))
                {

                    fs = new FileStream(pathFile, FileMode.Open);
                    obj = formatter.Deserialize(fs);
                }
            }
            catch (SerializationException e)
            {
                //Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw new FieldAccessException("Failed to deserialize. Reason: " + e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }

            }

            return obj;
        }
    }
}