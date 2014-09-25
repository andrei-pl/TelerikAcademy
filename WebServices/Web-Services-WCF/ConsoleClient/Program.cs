namespace ConsoleClient
{
    using ConsoleClient.StringOperations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            // 4. Host the latter service in IIS.

            StringOperationsClient client = new StringOperationsClient();
            int number = client.CountWordOccuresInTextAsync(new TextCounter(){ Text = "text text some text many many texts"}, "text").Result;

            Console.WriteLine(number);

            client.CountWordOccuresInTextAsync(new TextCounter(){ Text = "text text some text many many texts"}, "text").ContinueWith((result) => Console.WriteLine(result));
        }
    }
}
