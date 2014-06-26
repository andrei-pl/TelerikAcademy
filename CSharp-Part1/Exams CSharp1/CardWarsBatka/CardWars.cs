using System;
using System.Numerics;

namespace CardWarsBatka
{
    class CardWars
    {
        static void Main(string[] args)
        {
           
            BigInteger player1Score = 0;
            BigInteger player2Score = 0;
            int player1WinGames = 0;
            int player2WinGames = 0;
            bool player1X = false;
            bool player2X = false;
            int n = 0;
            do
            {
                n = Int32.Parse(Console.ReadLine());
            } while (n < 1 || n > 100);

            for (int i = 0; i < n; i++)
            {
                int player1GamePoints = 0;
                int player2GamePoints = 0;
              
                for (int j = 0; j < 3; j++)
                {
                    string player1Card = Console.ReadLine();
                    switch (player1Card)
                    {
                        case "J": player1GamePoints += 11; break;
                        case "Q": player1GamePoints += 12; break;
                        case "K": player1GamePoints += 13; break;
                        case "A": player1GamePoints += 1; break;
                        case "X": player1X = true; break;
                        case "Y": player1Score -= 200; break;
                        case "Z": player1Score *= 2; break;
                        default: player1GamePoints += 12 - Convert.ToInt32(player1Card); break;
                    }
                }
                for (int j = 0; j < 3; j++)
                {
                    string player2Card = Console.ReadLine();
                    switch (player2Card)
                    {
                        case "J": player2GamePoints += 11; break;
                        case "Q": player2GamePoints += 12; break;
                        case "K": player2GamePoints += 13; break;
                        case "A": player2GamePoints += 1; break;
                        case "X": player2X = true; break;
                        case "Y": player2Score -= 200; break;
                        case "Z": player2Score *= 2; break;
                        default: player2GamePoints += 12 - Convert.ToInt32(player2Card); break;
                    }
                }
                if (player1X && player2X)
                {
                    player1Score += 50;
                    player2Score += 50;
                }
                if (player1X == true && player2X == false)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                    return;
                } 
                if (player1X == false && player2X == true)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                    return;
                }
                if (player1GamePoints > player2GamePoints)
                {
                    player1Score += player1GamePoints;
                    player1WinGames++;
                }
                else if (player2GamePoints > player1GamePoints)
                {
                    player2Score += player2GamePoints;
                    player2WinGames++;
                }
                player1X = false;
                player2X = false;

            }
            if (player1Score > player2Score)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: " + player1Score);
                Console.WriteLine("Games won: " + player1WinGames);
            }
            else if (player1Score < player2Score)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: " + player2Score);
                Console.WriteLine("Games won: " + player2WinGames);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: " + player1Score);
            }
        }
    }
}
