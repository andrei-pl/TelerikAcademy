using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Kitana_01;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
namespace Kitana_01
{
    class Kitana
    {
        
        private const int Game_Field_Width = 106;
        private const int Game_Field_Height = 40;
        public static List<Player> players = new List<Player>();

        // Geri:
        private static Timer timer;
        private static Score score;
        private static string ChooseDifficulty()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(25, 10);
            Console.WriteLine("Choose difficulty:");
            string difficultMenuChooseOne = "1.Easy";
            string difficultMenuChooseTwo = "2.Medium";
            string difficultMenuChooseThree = "3.Hard";
            Console.SetCursorPosition(25, 13);
            Console.WriteLine(difficultMenuChooseOne);
            Console.SetCursorPosition(25, 16);
            Console.WriteLine(difficultMenuChooseTwo);
            Console.SetCursorPosition(25, 19);
            Console.WriteLine(difficultMenuChooseThree);
            Console.SetCursorPosition(45, 10);
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            int errorMessage = 25;
            while (key.KeyChar != '1' && key.KeyChar != '2' && key.KeyChar != '3')
            {
                Console.SetCursorPosition(20, errorMessage);
                Console.WriteLine("Invalid difficulty level! Choose 1, 2 or 3.");
                Console.SetCursorPosition(45, 10);
                key = Console.ReadKey();
                Console.WriteLine();
                //errorMessage++;
                if (errorMessage >= windowHeight - 5)
                {
                    errorMessage = windowHeight - 7;
                }
            }

            string difficulty = null;
            if (key.KeyChar == '1')
            {
                difficulty = "easy";
            }
            else if (key.KeyChar == '2')
            {
                difficulty = "medium";
            }
            else if (key.KeyChar == '3')
            {
                difficulty = "hard";
            }
            
            return difficulty;
        }
        private static string currentDifficulty = null;//Nikola

        public static void PrepareGame()
        {


            //players = (List<Player>)SaveReadToFile.Deserialize(@"../../serialization/playerscore.bin");
            //for (int i = 0; i < players.Count; i++)
            //{
            //    Console.SetCursorPosition(Game_Field_Width / 3 + 35, Game_Field_Height / 2);
            //    Console.WriteLine(playerr[i].ToString());
            //}


            Player playerr = (Player)SaveReadToFile.Deserialize(@"../../serialization/playerScore.bin");
            Console.SetCursorPosition(Game_Field_Width / 3 + 35, Game_Field_Height / 2);
            Console.WriteLine(playerr.ToString());
           

            Console.SetCursorPosition(Game_Field_Width / 3, Game_Field_Height / 2);
            Console.Write("Enter your name: ");
            string playerNamee = Console.ReadLine();
            if (playerNamee == playerr.FirstName)
            {
                Fscore = playerr.TotalScore;
            }
            string playerNamePath = @"../../filesTXT/PlayerName.dat";
            using (StreamWriter playerName = new StreamWriter(playerNamePath))
            {
                playerName.WriteLine(playerNamee);
            }            
            Console.Clear();
        }

        private static string[] Shuffle(string[] array) //Nikola
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
        private static string[,] GetRow(string dificulty) //Nikola
        {
            string name = "filesTXT/" + dificulty + ".dat";
            string path = "../../" + name;

            string line = string.Empty;
            int counter = 0;
            int linesCount = File.ReadAllLines(path).Count();
            //Console.WriteLine(linesCount); //total count in files
            string[] dificultyRow = new string[linesCount];

            //open and save in dificultyRow the whole file
            //every row in different array
            StreamReader sentance = new StreamReader(path);
            while ((line = sentance.ReadLine()) != null)
            {
                dificultyRow[counter] = line;
                counter++;
            }
            sentance.Close();
            //close file


            Random randomNumber = new Random();
            int currentDificultyRow = randomNumber.Next(0, linesCount); //take random row
            //Console.WriteLine("random row: " + currentDificultyRow);


            string[] words = dificultyRow[currentDificultyRow].Split(' ');
            string[] shuffled = Shuffle((string[])words.Clone());

            //for output[2,i]
            string[] whichNumber = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (shuffled[j]==words[i])
                    {
                        whichNumber[j] = Convert.ToString(i);
                    }
                }
            }
            

            string[,] output = new string[3, words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                output[0, i] = words[i];
                output[1, i] = shuffled[i];
                output[2, i] = whichNumber[i];
            }
            return output;
        }
 
        // added difficulty level to method.
        private static void ResetGame(string difficulty, ref string currentWord, ref int wordPosition, string playerName)
        {
            Console.Clear();
            isOccupied = new bool[40 - 2, 106 - 15];
            
            //string dificulty = "easy";
            //dificulty = "medium";
            orderedAndShuffleWord = GetRow(difficulty);
            Console.ForegroundColor = ConsoleColor.DarkRed;

            endPoints(difficulty);
            //just to see the result
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < orderedAndShuffleWord.GetLength(1); i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(orderedAndShuffleWord[1, i] + " ");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;

            for (int i = 0; i < windowHeight; i++)
            {
                PrintAtPosition(Console.WindowWidth - 15, i, "░", ConsoleColor.DarkRed);
            }

            Console.SetCursorPosition(startingPositionX + 17, startingPositionY + 5);
            Stone(startingPositionX + 17, startingPositionY + 5);

            Console.SetCursorPosition(startingPositionX + 40, startingPositionY + changePositionOne);
            Stone(startingPositionX + 40, startingPositionY + changePositionOne);
            Console.SetCursorPosition(startingPositionX + 63, startingPositionY + changePositionTwo);
            Stone(startingPositionX + 63, startingPositionY + changePositionTwo);

            PrintAtPosition(93, 4, "Player: " + playerName, ConsoleColor.White);
            if(difficulty == "easy")
            {
                speed = 10;
            }
            else if (difficulty == "medium")
            {
                speed = 9;
            }
            else
            {
                speed = 8;
            }

            wordPosition = 0;
            currentWord = orderedAndShuffleWord[1, wordPosition];
            wordPositionColumn = 106 / 2 - 7;
            wordPositionRow = 1;
            // Geri:
            timer = new Timer(60, 93, 8);
            score = new Score(93, 6);
            score.Finalscore = Fscore;
            score.print();
        }

        private static void GameOver(ref string currentWord, ref int wordPosition, string playerName)     //Andrey                                         //If key is pressed, start new game
        {

            
            for (int i = 0; i < orderedAndShuffleWord.GetLength(1); i++)
            {
                //PrintAtPosition((3 + i * 10), 40 - 1, orderedAndShuffleWord[0, i], ConsoleColor.Blue); //Nikola. Should change this to be centered like the plates
                
                //new from here  //logic like in the method endPoints()

                if (currentDifficulty == "easy")
                {

                    PrintAtPosition((20 + i * 15), 40 - 1, orderedAndShuffleWord[0, i], ConsoleColor.Blue);
                }
                else if (currentDifficulty == "medium")
                {

                    PrintAtPosition((10 + i * 15), 40 - 1, orderedAndShuffleWord[0, i], ConsoleColor.Blue);
                }
                else
                {

                    PrintAtPosition((5 + i * 15), 40 - 1, orderedAndShuffleWord[0, i], ConsoleColor.Blue);
                }
                 
                //to here
                
            }
            //Fscore = score.Finalscore;
            gameOverSound();
            //ConsoleKeyInfo key = Console.ReadKey(true);
            Console.SetCursorPosition(0, 1);
            string difficulty = ChooseDifficulty();
            Player player = new Player(playerName, Fscore);

            //List<Player> players = new List<Player>();
            //players.Add(player);
            SaveReadToFile.Serialize(player, @"../../serialization/playerScore.bin");
            
            ResetGame(difficulty, ref currentWord, ref wordPosition, playerName);
            currentDifficulty = difficulty;
        }

        static bool MoveWord(ConsoleKeyInfo key, string word)  //Andrey
        {
            if (key.Key == ConsoleKey.LeftArrow)                                 //check if the word is inside the area, it's moving.
            {
                if (wordPositionColumn > 0 && isOccupied[wordPositionRow, wordPositionColumn - 1] == false)     //if is not, he can't go further in order to avoid exception.
                {
                    wordPositionColumn--;
                    
                    
                }
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (wordPositionColumn < Console.WindowWidth - word.Length - 15 && isOccupied[wordPositionRow,wordPositionColumn + word.Length] == false)
                {
                    wordPositionColumn++;
                    
                }
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                
                if (wordPositionRow < windowHeight - 3)
                {
                    for (int i = wordPositionColumn; i < wordPositionColumn + word.Length; i++)
                    {
                        if (isOccupied[wordPositionRow + 1, i] == true)
                        {
                            //wordPositionRow--;
                            return false;
                        }
                    }
                    wordPositionRow++;  //fixed throwing exeption when DownArrow is held for a long, by simoto
                    
                }
            }
            return true;
        }

        //static int windowWidth = 106;
        static string[,] orderedAndShuffleWord;
        static int wordPositionColumn = 106 / 2 - 7;
        static int wordPositionRow = 1;
        static int windowHeight = 40 ;
        
        
        // Geri: deprecated -> static int score = 0;
        static int currentPoints;
        
        private static void endPoints(string difficulty) // Ivan
        {
            string symbols = "▓██████▓";


            for (currentPoints = 0; currentPoints < orderedAndShuffleWord.GetLength(1); currentPoints++)
            {
                if (difficulty == "easy")
                {

                    PrintAtPosition((20 + currentPoints * 15), 39 - 1, symbols, ConsoleColor.DarkRed);
                }
                else if (difficulty == "medium")
                {

                    PrintAtPosition((10 + currentPoints * 15), 39 - 1, symbols, ConsoleColor.DarkRed);
                }
                else
                {

                    PrintAtPosition((5 + currentPoints * 15), 39 - 1, symbols, ConsoleColor.DarkRed);
                }
                            
            }
            Console.WriteLine();   
        }

        private static void countDown()// Ivan
        {

            for (int a = 5; a >= 0; a--)
            {
                PrintAtPosition(93, 2, "Start in: " + a, ConsoleColor.White);
                //Console.Beep();
                countDownSound();
                Thread.Sleep(1000);
                
            }
            PrintAtPosition(93, 2, "           ", ConsoleColor.White);
            
        }
        public static void countDownSound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer(@"..\..\sounds\trprsht1.wav");
                player.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file can't be found!");
            }

        }
        public static void stoneWordSound()
        {
            try
            {
                SoundPlayer player1 = new SoundPlayer(@"..\..\sounds\expl2.wav");
                player1.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file can't be found!");
            }

        }
        public static void gameOverSound()
        {
            try
            {
                SoundPlayer player1 = new SoundPlayer(@"..\..\sounds\gameover.wav");
                player1.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file can't be found!");
            }

        }
        public static void wordEndSound()
        {
            try
            {
                SoundPlayer player3 = new SoundPlayer(@"..\..\sounds\wlkrsht2.wav");
                player3.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The sound file can't be found!");
            }

        } 
         
        public static void PrintAtPosition(int column, int row, string text, ConsoleColor color = ConsoleColor.White, ConsoleColor bgColor = ConsoleColor.Black) // ivan
        {
            Console.SetCursorPosition(column, row);
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgColor;
            Console.Write(text);
        }
        static int RandomGenerator()
        {
            Random rand = new Random();
            int random = rand.Next(5, 10);
            int randomNumber = random;
            return randomNumber;
        }
        private static void Hint(int startingPositionX, int startingPositionY)
        {
            //Inputs
            Console.ForegroundColor = ConsoleColor.DarkRed;
            int width = 8;
            char widthChar = '-';
            int height = 3;
            char heightChar = '|';
            int[,] hintBox = new int[height, width];
            int currentRow = 0;
            int currentCol = 0;
            char h = 'H';
            char i = 'I';
            char n = 'N';
            char t = 'T';
            int count = 2;
            string space = " ";

            //Solution
            while (true)
            {
                hintBox[currentRow, currentCol] = 1;
                currentCol++;
                if (currentCol >= width)
                {
                    currentCol--;
                    currentRow++;
                    break;
                }
            }
            while (true)
            {
                hintBox[currentRow, currentCol] = -1;
                if (currentRow >= (height / 2))
                {
                    currentRow++;
                    break;
                }
            }
            while (true)
            {
                hintBox[currentRow, currentCol] = 1;
                currentCol--;
                if (currentCol < 0)
                {
                    currentCol++;
                    currentRow--;
                    break;
                }
            }
            while (true)
            {
                hintBox[currentRow, currentCol] = -1;
                if (currentRow <= (height / 2))
                {
                    break;
                }
            }
            currentRow = 1;
            currentCol = 2;
            while (true)
            {
                hintBox[currentRow, currentCol] = count;
                currentCol++;
                count++;
                if (currentCol >= width - 2)
                {
                    break;
                }
            }

            //Printing
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (hintBox[row, col] == 1)
                    {
                        Console.Write(widthChar);
                    }
                    else if (hintBox[row, col] == -1)
                    {
                        Console.Write(heightChar);
                    }
                    else if (hintBox[row, col] == 2)
                    {
                        Console.Write(h);
                    }
                    else if (hintBox[row, col] == 3)
                    {
                        Console.Write(i);
                    }
                    else if (hintBox[row, col] == 4)
                    {
                        Console.Write(n);
                    }
                    else if (hintBox[row, col] == 5)
                    {
                        Console.Write(t);
                    }
                    else if (hintBox[row, col] == 0)
                    {
                        Console.Write(space);
                    }
                }
                Console.WriteLine();
                Console.SetCursorPosition(startingPositionX, startingPositionY + row + 1);
            }
        }
        private static void Stone(int startingPositionX, int startingPositionY)
        {
            //Inputs
            Console.ForegroundColor = ConsoleColor.DarkRed;
            int width = 9;
            char widthChar = '-';
            int height = 3;
            char heightChar = '|';
            int[,] stoneBox = new int[height, width];
            int currentRow = 0;
            int currentCol = 0;
            char s = 'S';
            char t = 'T';
            char o = 'O';
            char n = 'N';
            char e = 'E';
            int count = 2;
            string space = " ";

            //Solution
            while (true)
            {
                stoneBox[currentRow, currentCol] = 1;
                currentCol++;
                if (currentCol >= width)
                {
                    currentCol--;
                    currentRow++;
                    break;
                }
            }
            while (true)
            {
                stoneBox[currentRow, currentCol] = -1;
                if (currentRow >= (height / 2))
                {
                    currentRow++;
                    break;
                }
            }
            while (true)
            {
                stoneBox[currentRow, currentCol] = 1;
                currentCol--;
                if (currentCol < 0)
                {
                    currentCol++;
                    currentRow--;
                    break;
                }
            }
            while (true)
            {
                stoneBox[currentRow, currentCol] = -1;
                if (currentRow <= (height / 2))
                {
                    break;
                }
            }
            currentRow = 1;
            currentCol = 2;
            while (true)
            {
                stoneBox[currentRow, currentCol] = count;
                currentCol++;
                count++;
                if (currentCol >= width - 2)
                {
                    break;
                }
            }

            //Printing
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (stoneBox[row, col] == 1)
                    {
                        Console.Write(widthChar);
                    }
                    else if (stoneBox[row, col] == -1)
                    {
                        Console.Write(heightChar);
                    }
                    else if (stoneBox[row, col] == 2)
                    {
                        Console.Write(s);
                    }
                    else if (stoneBox[row, col] == 3)
                    {
                        Console.Write(t);
                    }
                    else if (stoneBox[row, col] == 4)
                    {
                        Console.Write(o);
                    }
                    else if (stoneBox[row, col] == 5)
                    {
                        Console.Write(n);
                    }
                    else if (stoneBox[row, col] == 6)
                    {
                        Console.Write(e);
                    }
                    else if (stoneBox[row, col] == 0)
                    {
                        Console.Write(space);
                    }
                    isOccupied[startingPositionY + row, startingPositionX + col] = true;
                }
                Console.WriteLine();
                Console.SetCursorPosition(startingPositionX, startingPositionY + row + 1);
            }
        }

        private static bool WordsOnPlate(ref bool[,] isOccupied, int currentRow, 
            int currentCol, ref string currentWord, ref int wordPositionInWordArray, int currentIndex, string playerName, string difficulty)        //Andrey
        {
            if (currentRow < 40 - 3)
            {
                
                for (int i = wordPositionColumn; i < currentWord.Length + wordPositionColumn; i++)
                {
                    
                    if (isOccupied[currentRow + 1, i] == true)                  //if down cell is occupied, then Add the word to the last row
                    {
                        stoneWordSound();
                        AddWordToWindow(isOccupied, currentRow, currentCol, ref currentWord, ref wordPositionInWordArray, playerName);
                        return true;

                    }                   
                }
            }
            if (currentRow >= 40 - 3)         //add the word if reached bottom line
            {
                wordEndSound();
                if (currentDifficulty == "easy")
                {

                    if ((currentCol - 15) / 15 == currentIndex /*|| (currentCol + currentWord.Length - 3) / 20 == currentIndex*/) //Nikola
                    {
                        score.increment();
                        score.print();
                       
                    }


                }
                else if (currentDifficulty == "medium")
                {

                    if ((currentCol-5) / 15 == currentIndex || (currentCol-7) / 15 == currentIndex /*|| (currentCol + currentWord.Length - 3) / 20 == currentIndex*/) //Nikola
                    {
                        score.increment();
                        score.print();
                        
                    }

                }
                else if (currentDifficulty == "hard")
                {

                    if ((currentCol) / 15 == currentIndex /*|| (currentCol + currentWord.Length - 3) / 20 == currentIndex*/) //Nikola
                    {
                        score.increment();
                        score.print();
                        
                    }

                }


                Fscore = score.Finalscore;
                AddWordToWindow(isOccupied, currentRow, currentCol, ref currentWord, ref wordPositionInWordArray, playerName);
               
                return true;
            }
            return false;
        }

        private static void AddWordToWindow(bool[,] isOccupied, int currentRow, 
            int currentCol, ref string currentWord, ref int wordPositionInWordArray, string playerName)        //Andrey
        {
            for (int j = wordPositionColumn; j < currentWord.Length + wordPositionColumn; j++)
            {
                isOccupied[currentRow, j] = true;
            }
            if (wordPositionInWordArray == orderedAndShuffleWord.GetLength(1) - 1)
            {
                GameOver(ref currentWord, ref wordPositionInWordArray, playerName);
            }
            else
            {
                wordPositionInWordArray++;
            }
            currentWord = orderedAndShuffleWord[1, wordPositionInWordArray];
            wordPositionRow = 1;
            wordPositionColumn = 106 / 2 - 7;
        }

         static bool[,] isOccupied = new bool[40 - 2, 106 - 15];
         static Random rand;
         static int random;
         static int startingPositionY;
         static int startingPositionX;
         static int changePositionOne;
         static int changePositionTwo;
         static int speed;
         public static double Fscore;
         //public static string playerNamee = "";

        static void Main()
       {
           Console.WindowHeight = Game_Field_Height;
           Console.WindowWidth = Game_Field_Width;
           Console.BufferHeight = Game_Field_Height;  // remove scroll bar
           // Geri:
           string playerName = "";
           
           PrepareGame();
           string difficulty = ChooseDifficulty();
           currentDifficulty = difficulty; //Nikola
           
           int prevPositionWordRow = 1;
           int prevPositionWordCol = 106 / 2 - 7;
           using (StreamReader readPlayerName = new StreamReader(@"../../filesTXT/PlayerName.dat"))
           {
               playerName = readPlayerName.ReadLine();
           }
           Console.SetCursorPosition(Game_Field_Width / 3, Game_Field_Height / 2);
           Console.Write("Difficulty choosen: " + difficulty + ". Press any key to start the game!");
           Console.ReadKey();
           
           
           rand = new Random();
           random = rand.Next(9, 15);
           startingPositionY = random;
           random = rand.Next(4, 6);
           startingPositionX = random;
           changePositionOne = rand.Next(10);
           changePositionTwo = rand.Next(10);
           orderedAndShuffleWord = GetRow(difficulty);
           
           int wordPositionInWordArray = 0;
           string currentWord = orderedAndShuffleWord[1, wordPositionInWordArray];
           int currentIndex = int.Parse(orderedAndShuffleWord[2, wordPositionInWordArray]);

           ResetGame(difficulty, ref currentWord, ref wordPositionInWordArray, playerName);
           countDown();
           
           // Geri:
            //create score object:
           score = new Score(93, 6);
           
           score.Finalscore = Fscore;
           // - create timer object:
           timer = new Timer(60, 93, 8);
           
           score.print(); // <- Geri.
           
           int counter = 7;
           int countHints = 0; // Counts how many times the player used the hint.
           int hintTurnIntoStone = 0;

           while (true)
           {
               try
               {
                   if (countHints == 1)
                   {
                       if (hintTurnIntoStone == 35)
                       {
                           Console.SetCursorPosition(startingPositionX, startingPositionY);
                           Stone(startingPositionX, startingPositionY);
                       }
                       hintTurnIntoStone++;
                   }
                   else
                   {
                       Console.SetCursorPosition(startingPositionX, startingPositionY); // Moved the drawing of the stones and the hint here 
                       // because otherwise they are getting erased when a word passed over them.  // Aleksandar
                       Hint(startingPositionX, startingPositionY);
                       if ((wordPositionColumn >= startingPositionX) && (wordPositionColumn < startingPositionX + 8))
                       {
                           if ((wordPositionRow >= startingPositionY) && (wordPositionRow < startingPositionY + 3))
                           {
                               if (countHints == 0)
                               {
                                   Console.WriteLine("Box № {0}", currentIndex + 1); // Show the correct box to put the word.  // Aleksandar
                                   Thread.Sleep(1000);
                                   Console.SetCursorPosition(startingPositionX, startingPositionY + 3);
                                   Console.WriteLine("        ");
                               }
                               countHints++;
                           }
                       }
                   }

                   counter++;
                   for (int i = prevPositionWordCol; i < prevPositionWordCol + currentWord.Length; i++)
                   {
                       PrintAtPosition(i, prevPositionWordRow, " ");
                   }
                   PrintAtPosition(wordPositionColumn, wordPositionRow, currentWord);

                   if (WordsOnPlate(ref isOccupied, wordPositionRow, wordPositionColumn,
                       ref currentWord, ref wordPositionInWordArray, currentIndex, playerName, difficulty) == true)
                   {
                       currentIndex = int.Parse(orderedAndShuffleWord[2, wordPositionInWordArray]);
                       speed--;
                       continue;
                   }

                   prevPositionWordCol = wordPositionColumn;
                   prevPositionWordRow = wordPositionRow;
                   bool stopMovingDown = false;

                   while (Console.KeyAvailable)
                   {
                       ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                       if (!MoveWord(pressedKey, currentWord))
                       {
                           while (Console.KeyAvailable) pressedKey = Console.ReadKey(true);
                           stopMovingDown = true;
                           break;
                       }
                   }
                   if (stopMovingDown)
                   {
                       continue;
                   }

                   if (counter % speed == 0)
                   {
                       wordPositionRow++;
                   }
                   //maybe this can fix DownArrow exception
                   if (wordPositionRow >= windowHeight - 2)
                   {
                       wordPositionRow = windowHeight - 3;
                   }

                   // Geri:
                   // Output time:
                   if (!timer.updateTimer())
                   {
                       Console.SetCursorPosition(20, 10);
                       Console.WriteLine("GAME OVER!!!");
                       Console.SetCursorPosition(20, 11);
                       Console.WriteLine("Time is up!");
                       
                       gameOverSound();

                       //Fscore = score.CurrentScore;
                       

                       //Player player = new Player(playerr, score.Finalscore);
                       while (true)
                       {
                           if (Console.KeyAvailable)
                           {
                               System.Environment.Exit(1);
                           }
                       }
                   }

                   // Geri - SCORE DEMO - start:
                   /*
                   score.increment();

                   if (score.get() % 500 == 0)
                   {
                       score.decrement();
                   }
                   // SCORE DEMO - end.
                    */

                   Thread.Sleep(100);
               }
               catch (IndexOutOfRangeException)
               {
                   PrintAtPosition(10, 25, "Something goes wrong.");
                   GameOver(ref currentWord, ref wordPositionInWordArray, playerName);
               }
               catch (Exception)
               {
                   PrintAtPosition(10, 25, "Something goes wrong.");
                   GameOver(ref currentWord, ref wordPositionInWordArray, playerName);
               }
           }
        }
    }
}