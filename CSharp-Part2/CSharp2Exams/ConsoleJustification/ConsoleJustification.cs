using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJustification
{
    class ConsoleJustification
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string[] strings = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < strings.Length; j++)
                {
                    list.Add(strings[j]);
                }
            }
            int item = 0;
            while (item < list.Count)                                                             //Докато не се изчерпят елементите
            {                                                                                     //
                int itemsPerRow = 1;                                                              //взинаги ще има поне един взет елемент;
                string listOfCurrentWords = list[item];                                           //взимаме следващия подред елемент в списъка;
                int lengthWords = listOfCurrentWords.Length;                                      //взимаме дължината на думата
                for (int j = item + 1; j < list.Count; j++)                                       //
                {                                                                                 //и докато не се изчерпи списъка 
                    if (lengthWords + list[j].Length + 1 <= w)                                    //или дължината на изречението съединено
                    {                                                                             //с един интервал между думите не стане по-голямо 
                        listOfCurrentWords = listOfCurrentWords + " " + list[j];                  //от зададената дължина за един ред, се взимат нови думи
                        itemsPerRow++;                                                            //и се слепват за предишните с интервал
                        lengthWords = listOfCurrentWords.Length;                                  //
                    }                                                                             //
                    else                                                                          //
                    {                                                                             //
                        break;                                                                    //
                    }                                                                             //
                }                                                                                 //
                if (itemsPerRow == 1 || listOfCurrentWords.Length == w)                           //След като горното условие е привършило ако
                {                                                                                 //полученото изречение е равно на зададената дължина
                    Console.Write(listOfCurrentWords);                                            //или взетия елемент е само един, тогава се изписва
                }                                                                                 //без никакви други условия
                else                                                                              //
                {                                                                                 //иначе
                    int missingSpaces = w - listOfCurrentWords.Length;                            //смятаме колко липсващи интервала остават
                    int spacesBetweenWords = missingSpaces / (itemsPerRow - 1);                   //пресмятаме по колко интервала се падат между всяка дума
                    int rightIntervals = missingSpaces % (itemsPerRow - 1);                       //смятаме колко са левите думи, на които трябва да им се 
                    for (int word = 0; word < itemsPerRow; word++)                                //предаде един допълнителен интерввал
                    {                                                                             //
                        if (word == 0)                                                            //
                        {                                                                         //
                            Console.Write(list[item + word]);                                     //първата дума се изписва винаги без други условия
                        }                                                                         //
                        else if (rightIntervals > 0)                                              //
                        {                                                                         //ако има думи, на които трябва да се предаде допълнителен
                            Console.Write(list[item + word].PadLeft(list[item + word].Length + spacesBetweenWords + 2, ' '));               //интервал
                            rightIntervals--;                                                     //се предвава +1 повече
                        }                                                                         //и бройката им се намаля
                        else                                                                      //
                        {                                                                         //индекса е item (първи взет елемент от поредицата) + word
                            Console.Write(list[item + word].PadLeft(list[item + word].Length + spacesBetweenWords + 1, ' '));
                        }                                                                         //(следващия елемент от нужните itemsPerRow)
                    }                                                                             //
                }                                                                                 //
                    Console.WriteLine();                                                          //
                    item += itemsPerRow;                                                          //За да получим ледващия елемент, с който ще се работи
            }                                                                                     //трябва да увеличим item с itemsPerRow (вече използваните
        }                                                                                                                                   //елементи)
    }
}
