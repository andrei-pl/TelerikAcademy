namespace WCF.ServiceLibrary.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class TextCounter
    {
        public TextCounter(string text)
        {
            this.Text = text;
        }

        [DataMember]
        public string Text { get; set; }
    }
}
