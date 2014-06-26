using System;

namespace Poker
{
    class Poker
    {
        static void Main(string[] args)
        {
            byte[] cards = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
           
            for (int i = 0; i < 5; i++)
            {
                string card = Console.ReadLine();
                if (card == "A") cards[0]++;
                if (card == "2") cards[1]++;
                if (card == "3") cards[2]++;
                if (card == "4") cards[3]++;
                if (card == "5") cards[4]++;
                if (card == "6") cards[5]++;
                if (card == "7") cards[6]++;
                if (card == "8") cards[7]++;
                if (card == "9") cards[8]++;
                if (card == "10") cards[9]++;
                if (card == "J") cards[10]++;
                if (card == "Q") cards[11]++;
                if (card == "K") cards[12]++;
            }

            bool isFiveOfKind = false;
            bool isFourOfKind = false;
            bool isThreeOfkind = false;
            bool isOnePair = false;
            bool isTwoPairs = false;

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == 5)
                {
                    isFiveOfKind = true;
                }
                if (cards[i] == 4)
                {
                    isFourOfKind = true;
                }
                if (cards[i] == 3)
                {
                    isThreeOfkind = true;
                }
                if (cards[i] == 2)
                {
                    if (isOnePair == false)
                    {
                        isOnePair = true;
                    }
                    else
                    {
                        isTwoPairs = true;
                    }
                }
            }
            if (isOnePair || isTwoPairs)
            {
                if (isOnePair && isTwoPairs)
                {
                    Console.WriteLine("Two Pairs");
                }
                else
                {
                    if (isThreeOfkind)
                    {
                        Console.WriteLine("Full House");
                    }
                    else
                    {
                        Console.WriteLine("One Pair");
                    }
                }
            }
            else if (isThreeOfkind)
            {
                Console.WriteLine("Three of a Kind");
            }
            if (isFourOfKind)
            {
                Console.WriteLine("Four of a Kind");
            }
            if (isFiveOfKind)
            {
                Console.WriteLine("Impossible");
            }
            bool straight = false;
            if (cards[0] == 1 && cards[1] == 1 && cards[2] == 1 && cards[3] == 1 && cards[4] == 1) straight = true;
            if (cards[1] == 1 && cards[2] == 1 && cards[3] == 1 && cards[4] == 1 && cards[5] == 1) straight = true;
            if (cards[2] == 1 && cards[3] == 1 && cards[4] == 1 && cards[5] == 1 && cards[6] == 1) straight = true;
            if (cards[3] == 1 && cards[4] == 1 && cards[5] == 1 && cards[6] == 1 && cards[7] == 1) straight = true;
            if (cards[4] == 1 && cards[5] == 1 && cards[6] == 1 && cards[7] == 1 && cards[8] == 1) straight = true;
            if (cards[5] == 1 && cards[6] == 1 && cards[7] == 1 && cards[8] == 1 && cards[9] == 1) straight = true;
            if (cards[6] == 1 && cards[7] == 1 && cards[8] == 1 && cards[9] == 1 && cards[10] == 1) straight = true;
            if (cards[7] == 1 && cards[8] == 1 && cards[9] == 1 && cards[10]== 1 && cards[11] == 1) straight = true;
            if (cards[8] == 1 && cards[9] == 1 && cards[10] == 1 && cards[11] == 1 && cards[12] == 1) straight = true;
            if (cards[9] == 1 && cards[10] == 1 && cards[11] == 1 && cards[12] == 1 && cards[0] == 1) straight = true;

            if (straight)
            {
                Console.WriteLine("Straight");
            }
            if (!isFiveOfKind && !isFourOfKind && !isThreeOfkind && !isTwoPairs && !isOnePair && !straight)
            {
                Console.WriteLine("Nothing");
            }
        }
    }
}
