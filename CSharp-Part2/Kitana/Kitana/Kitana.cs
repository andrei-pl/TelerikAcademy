using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Kitana_01
{
    class Kitana
    {
        private static string[] Shuffle(string[] array)
        {
            string[] shuffledArray = new string[array.Length];
            int randomNumber;
            Random random = new Random();
            for (int i = array.Length; i >= 1; i--)
            {
                randomNumber = random.Next(1, i + 1) - 1;
                shuffledArray[i - 1] = array[randomNumber];
                array[randomNumber] = array[i - 1];
            }
            return shuffledArray;
        }
        private static string[,] GetRow(string dificulty)
        {
            string name = "filesTXT/" + dificulty + ".dat";
            string path = "../../" + name;

            string line = string.Empty;
            int counter = 0;
            int linesCount = File.ReadAllLines(path).Count();
            //Console.WriteLine(linesCount); //obshto redove vyv faila
            string[] dificultyRow = new string[linesCount];

            //otvarqme i zapisvame v dificultyRow celiqt fail
            //vseki red v otdelen masiv
            StreamReader sentance = new StreamReader(path);
            while ((line = sentance.ReadLine()) != null)
            {
                dificultyRow[counter] = line;
                counter++;
            }
            sentance.Close();
            //zatvarqme faila
            /*//za pechat
            for (int i = 0; i < linesCount; i++)
            {
                Console.WriteLine(dificultyRow[i]);
            }
            */

            Random randomNumber = new Random();
            int currentDificultyRow = randomNumber.Next(0, linesCount); //vzima sluchaen red
            //Console.WriteLine("random row: " + currentDificultyRow);


            string[] words = dificultyRow[currentDificultyRow].Split(' ');
            string[] shuffled = Shuffle((string[])words.Clone());
            //pechat
            /*
            Console.WriteLine("\noriginal:\n");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("\nshuffled:\n");

            foreach (string word in shuffled)
            {
                Console.WriteLine(word);
            }*/
            string[,] output = new string[2, words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                output[0, i] = words[i];
                output[1, i] = shuffled[i];
            }
            return output;
        }

        private static void ResetGame()
        {
            Console.Clear();
            string dificulty = "easy";
            //dificulty = "medium";
            orderedAndShuffleWord = GetRow(dificulty);
            endfPoints();
            score = 0;
        }

        private static void GameOver(ref string currentWord, ref int wordPosition)                                                  //If key is pressed, start new game
        {
            Console.SetCursorPosition(0, windowHeight - 1);
            for (int i = 0; i < orderedAndShuffleWord.GetLength(1); i++)
            {
                Console.Write(orderedAndShuffleWord[0, i] + "   ");
            }
            ConsoleKeyInfo key = Console.ReadKey(true);
            ResetGame();
            wordPosition = 0;
            currentWord = orderedAndShuffleWord[1, wordPosition];
            wordPositionColumn = Console.WindowWidth / 2 - 7;
            wordPositionRow = 1;
        }

        static void MoveWord(ConsoleKeyInfo key, string word)
        {
            if (key.Key == ConsoleKey.LeftArrow)                                 //check if the word is inside the area, it's moving.
            {
                if (wordPositionColumn > 0)                                   //if is not, he can't go further in order to avoid exception.
                {
                    wordPositionColumn--;
                }
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (wordPositionColumn < Console.WindowWidth - word.Length - 15)
                {
                    wordPositionColumn++;
                }
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (wordPositionRow < windowHeight - 2)
                {
                    wordPositionRow += 2;  //throwing exception when is pressed for a long ???
                }
            }
        }


        static string[,] orderedAndShuffleWord;
        static int wordPositionColumn = Console.WindowWidth / 2 - 7;
        static int wordPositionRow = 1;
        static int windowHeight = Console.WindowHeight;
        static int score = 0;
        
        private static void endfPoints()
        {
            string symbols = "██████";
            for (int i = 0; i < 4; i++)
            {

                PrintAtPosition((2 + i * 10), 30, symbols, ConsoleColor.DarkRed);
            }
            Console.WriteLine();
            
        }
        public static void PrintAtPosition(int column, int row, string text, ConsoleColor color = ConsoleColor.White, ConsoleColor bgColor = ConsoleColor.Black)
        {
            Console.SetCursorPosition(column, row);
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgColor;
            Console.Write(text);
        }

        static void Main()
       {
           Console.WindowHeight = 40;
           ResetGame();
           int wordPositionInWordArray = 0;
           string currentWord = orderedAndShuffleWord[1, wordPositionInWordArray];

           Console.BufferHeight = Console.WindowHeight;  // remove scroll bar

           while (true)
           {
               Console.Clear();
               endfPoints();
                //just to see the result
               Console.SetCursorPosition(0, 0);
               for (int i = 0; i < orderedAndShuffleWord.GetLength(1); i++)
               {
                   Console.Write(orderedAndShuffleWord[1, i] + " ");
                   
               }
               Console.WriteLine();
               

               for (int i = 0; i < windowHeight; i++)
               {
                   Console.SetCursorPosition(Console.WindowWidth - 15, i);
                   Console.Write('|');
                  
               }
               
               if (wordPositionRow == Console.WindowHeight - 1)
               {
                   if (wordPositionInWordArray == orderedAndShuffleWord.GetLength(1) - 1)
                   {
                       GameOver(ref currentWord, ref wordPositionInWordArray);
                       continue;
                   }
                   wordPositionInWordArray++;
                   currentWord = orderedAndShuffleWord[1, wordPositionInWordArray];
                   wordPositionRow = 1;
                   wordPositionColumn = Console.WindowWidth / 2 - 7;
                   
               }
               
               Console.SetCursorPosition(wordPositionColumn, wordPositionRow);
               Console.Write(currentWord);
               while (Console.KeyAvailable)
               {
                   ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                   // while (Console.KeyAvailable) Console.ReadKey(true);
                   MoveWord(pressedKey, currentWord);
               }
               wordPositionRow++;
               
               
               Thread.Sleep(1000);
               
           }
        }
    }
}
