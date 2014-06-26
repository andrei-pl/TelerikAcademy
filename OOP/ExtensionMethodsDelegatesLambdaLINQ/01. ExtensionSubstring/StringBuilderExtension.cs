namespace _01.ExtensionSubstring
{
    using System;
    using System.Text;

    public static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder text, int startIndex, int length)
        {
            StringBuilder result = new StringBuilder(text.ToString(startIndex, length));

            return result;
        }
    }
}
