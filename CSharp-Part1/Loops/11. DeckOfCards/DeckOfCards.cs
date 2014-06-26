using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.DeckOfCards
{
    //Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
    //The cards should be printed with their English names. Use nested for loops and switch-case.

    class DeckOfCards
    {
        static void Main(string[] args)
        {
            string[] rankCards = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
 
            for (int i = 0; i < rankCards.Length; i++)
            {
               for (int j = 1; j <= 4; j++)
                {
                    switch (j)
                    {
                        case 1:
                            Console.WriteLine(rankCards[i] + " of spades");
                            break;
                        case 2:
                            Console.WriteLine(rankCards[i] + " of diamonds");
                            break;
                        case 3:
                            Console.WriteLine(rankCards[i] + " of hearts");
                            break;
                        case 4:
                            Console.WriteLine(rankCards[i] + " of clubs");
                            break;
                    }
                }
            }
        }
    }
}
