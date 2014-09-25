namespace WCF.Client
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using WCF.Client.ServiceReferenceWCF;
    using WCF.ServiceLibrary;
    using WCF.ServiceLibrary.Models;

    class Program
    {
        static void Main(string[] args)
        {
            //start like administrator

            // 2. Create a console-based client for the WCF service above. Use the "Add Service Reference" in Visual Studio.
            TimeServiceClient client = new TimeServiceClient();

            var result = client.GetDayFromData(DateTime.Now);

            Console.WriteLine(result);

            // 3. Create a Web service library which accepts two string as parameters. 
            //It should return the number of times the second string contains the first string. 
            //Test it with the integrated WCF client.
            var url = new Uri("http://localhost:1234/");

            var behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;

            ServiceHost host = new ServiceHost(typeof(StringOperations), url);
            host.Description.Behaviors.Add(behavior);
            host.Open();

            Console.WriteLine("Service working on {0} ", url.AbsoluteUri);
            Console.WriteLine("Enter to close connection");

            StringOperations countWord = new StringOperations();
            int count = countWord.CountWordOccuresInText(new TextCounter("text, text, many many text"), "text");
            Console.WriteLine(count + " times.");
            Console.ReadKey();
            host.Close();
        }
    }
}
