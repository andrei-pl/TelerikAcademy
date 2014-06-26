using Gsm.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gsm.Software
{
    class GSMCallHistoryTest
    {
        //12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
        //Create an instance of the GSM class.
        //Add few calls.
        //Display the information about the calls.
        //Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
        //Remove the longest call from the history and calculate the total price again.
        //Finally clear the call history and print it.

        public GSM GSMTest { get; private set; }
        private List<Call> listOfCalls;
       
        public GSMCallHistoryTest(GSM gsm)
        {
            GSMTest = gsm;
            listOfCalls = GSMTest.CallHistory;
        }

        public void AddCall(Call call)
        {
            listOfCalls.Add(call);
        }

        public void RemoveCall(Call call)
        {
            listOfCalls.Remove(call);
        }

        public void RemoveCall(int index)
        {
            listOfCalls.RemoveAt(index);
        }

        public void ClearCalls()
        {
            listOfCalls.Clear();
        }

        private string PrintCallsAndHistory()
        {
            List<string> info = new List<string>();
            foreach (var item in listOfCalls)
            {
                info.Add(item.Date + " " + item.DialedPhone + " " + item.Duration);
            }
            info.Add(GSMTest.GetTotalPrice().ToString());
            return String.Join(Environment.NewLine, info);
        }

        public void RemoveLongestCall()
        {
            int maxDuration = 0;
            for (int i = 0; i < listOfCalls.Count; i++)
            {
                if (listOfCalls[i].Duration.TotalSeconds > maxDuration)
                {
                    maxDuration = i;
                }
            }
            RemoveCall(maxDuration);
        }

        public override string ToString()
        {
            if (listOfCalls.Count == 0)
            {
                return "No history available.";
            }

            return PrintCallsAndHistory();
        }
    }
}
