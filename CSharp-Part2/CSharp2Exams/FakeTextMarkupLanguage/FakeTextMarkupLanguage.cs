using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FakeTextMarkupLanguage
{
    class FakeTextMarkupLanguage
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] line = new string[n];
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>();
                
            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("<lower>", "</lower>");
            tags.Add("<upper>", "</upper>");
            tags.Add("<rev>", "</rev>");
            tags.Add("<toggle>", "</toggle>");

            for (int i = 0; i < line.Length; i++)
            {
                line[i] = Console.ReadLine();
                line[i] = Regex.Replace(line[i], @"<del>(.*?)</del>", "");

                StringBuilder text = new StringBuilder();

                for (int j = 0; j < line[i].Length;)
                {
                    while (line[i][j] != '<')                                        //
                    {                                                                //
                        text.Append(line[i][j]);                                     //
                        j++;
                        if (j == line[i].Length)
                        {
                            break;
                        }
                    }
                    if (text.Length != 0)
                    {
                        if (stack.Count != 0)
                        {
                            if (!tags.ContainsKey(stack.Peek()))
                            {
                                text.Insert(0, stack.Pop(), 1);
                            }
                            stack.Push(text.ToString());
                            text.Clear();
                        }
                        else
                        {
                            queue.Enqueue(text.ToString());
                            text.Clear();
                        }
                    }
                    else if (line[i][j] == '<')
                    {
                        while (line[i][j] != '>')
                        {                                                                //if stack is empty go in queue
                            text.Append(line[i][j]);                              //else go in stack, if has a word, first concatenate them
                            j++;                                                         //
                        }                                                                //if is command go to stack
                        text.Append(line[i][j]);                                  //if it closing tag tale the word from stack
                        j++;        
                        
                        if(tags.ContainsKey(text.ToString()))
                        {
                            stack.Push(text.ToString());
                            text.Clear();
                        }
                        else if (tags.ContainsValue(text.ToString()))
                        {
                            string popText = stack.Pop();
                            if (stack.Count != 0 && !tags.ContainsKey(stack.Peek()))
                            {
                                popText = stack.Pop() + popText;
                            }
                            if (text.ToString() == "</lower>") 
                            {
                                popText = popText.ToLower();
                                stack.Pop();
                            }
                            else if (text.ToString() == "</upper>") 
                            {
                                popText = popText.ToUpper();
                                stack.Pop();
                            }
                            else if (text.ToString() == "</rev>") 
                            {
                                char[] charArray = popText.ToCharArray();
                                Array.Reverse(charArray);
                                popText = new string(charArray);
                                stack.Pop();
                            }
                            else if (text.ToString() == "</toggle>")
                            {
                                StringBuilder toggled = new StringBuilder();

                                for (int t = 0; t < popText.Length; t++)
                                {
                                    if (popText[t] - 'A' < 26)
                                    {
                                        toggled.Append(popText[t].ToString().ToLower());
                                    }
                                    else
                                    {
                                        toggled.Append(popText[t].ToString().ToUpper());
                                    }
                                }
                                popText = toggled.ToString();
                                stack.Pop();
                            }
                            if (stack.Count != 0 && tags.ContainsKey(stack.Peek()))
                            {
                                stack.Push(popText);
                                text.Clear();
                            }
                            else
                            {
                                if (stack.Count != 0)
                                {
                                    stack.Push(popText);
                                    text.Clear();
                                }
                                else
                                {
                                    queue.Enqueue(popText);
                                    text.Clear();
                                }
                            }
                        }
                    }       
                }
                while (queue.Count != 0)
                {
                    Console.Write(queue.Dequeue());
                }
                Console.WriteLine();
            }
        }
    }
}
	

    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text.RegularExpressions;
     
    //namespace Tests
    //{
    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //            int n = int.Parse(Console.ReadLine());
    //            string pattern = @"<(?<tag>.*?)>(?<text>[^<]*?)</\k<tag>>";            
    //            string lines = string.Empty;
     
    //            for (int count = 0; count < n; count++) lines += "\n" + Console.ReadLine();
     
    //            Match match = Regex.Match(lines, pattern);
    //            while (match.Success)
    //            {
    //                lines = lines.Replace(match.Value, Change(match.Groups["tag"].Value, match.Groups["text"].Value));
    //                match = Regex.Match(lines, pattern);
    //            }
    //            Console.WriteLine(lines);
    //        }
     
    //        static string Change(string action, string text)
    //        {
    //            switch (action)
    //            {
    //                case "upper":
    //                    {
    //                        return text.ToUpper();
    //                    }
    //                case "lower":
    //                    {
    //                        return text.ToLower();
    //                    }
    //                case "toggle":
    //                    {
    //                        char[] result = text.ToCharArray();
    //                        for (int i = 0; i < result.Length; i++)
    //                        {
    //                            if (char.IsLower(result[i])) result[i] = char.ToUpper(result[i]);
    //                            else if (char.IsUpper(result[i])) result[i] = char.ToLower(result[i]);
    //                        }
    //                        return (new string(result));
    //                    }
    //                case "rev":
    //                    {
    //                        return new string(text.Reverse().ToArray());
    //                    }
    //            }
    //            return string.Empty;
    //        }
    //    }
    //}

