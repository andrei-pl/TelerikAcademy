namespace WCF.ServiceLibrary
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    using WCF.ServiceLibrary.Models;

    public class StringOperations : IStringOperations
    {

        public int CountWordOccuresInText(TextCounter text, string searchedWord)
        {
            int counter = 0;
            var index = text.Text.IndexOf(searchedWord);

            while(index != -1)
            {
                counter++;
                index = text.Text.IndexOf(searchedWord, index + 1);
            }

            return counter;
        }
    }
}
