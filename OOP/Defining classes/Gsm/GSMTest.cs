using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gsm.Hardware;
using Gsm.Software;

namespace Gsm
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            //7. Write a class GSMTest to test the GSM class:
            //Create an array of few instances of the GSM class.
            //Display the information about the GSMs in the array.
            //Display the information about the static property IPhone4S.

            GSM firstMobile = new GSM("XperiaS", "Sony", 700M, null, null, new Display(4.3, 8000000));
            GSM secondMobile = new GSM("Asha", "Nokia", 300M, null, null, new Display(2.5, 2000000));
            GSM thirdMobile = new GSM("GalaxyS4", "Samsung", 1000M, "bai Pesho", new Battery(Battery.BatteryType.LiIon, 0, 0), new Display(5, 16000000));
            GSMCallHistoryTest firstMobileCall = new GSMCallHistoryTest(firstMobile);
            GSMCallHistoryTest secondMobileCall = new GSMCallHistoryTest(secondMobile);
            GSMCallHistoryTest thirdMobileCall = new GSMCallHistoryTest(thirdMobile);

            Console.WriteLine(firstMobile.ToString()); Console.WriteLine();
            Console.WriteLine(secondMobile.ToString()); Console.WriteLine();
            Console.WriteLine(thirdMobile.ToString()); Console.WriteLine();
            Console.WriteLine(Hardware.GSM.IPhone4S.ToString());
            Console.WriteLine();

            firstMobileCall.AddCall(new Call(DateTime.Now, "0888777666", new TimeSpan(0, 0, 59)));
            secondMobileCall.AddCall(new Call(DateTime.Now, "0888111222", new TimeSpan(0, 2, 59)));
            thirdMobileCall.AddCall(new Call(DateTime.Now, "032222111", new TimeSpan(0, 1, 12)));
            firstMobileCall.AddCall(new Call(DateTime.Now, "023334444", new TimeSpan(1, 0, 0)));

            Console.WriteLine(firstMobileCall.ToString());
            Console.WriteLine();
            Console.WriteLine(secondMobileCall.ToString());
            Console.WriteLine();
            Console.WriteLine(thirdMobileCall.ToString());
            Console.WriteLine();


            firstMobileCall.RemoveLongestCall();
            Console.WriteLine(firstMobileCall.ToString());
            Console.WriteLine();
            thirdMobileCall.ClearCalls();
            Console.WriteLine(thirdMobileCall.ToString());

        }
    }
}
