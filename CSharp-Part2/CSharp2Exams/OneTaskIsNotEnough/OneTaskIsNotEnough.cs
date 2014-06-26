    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
     
    namespace OneIsNotEnough
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Stopwatch sw = new Stopwatch();
                //sw.Start();
                //StreamReader inFile = new StreamReader(@"..\..\input.txt");
                //using (inFile)
                //{
                //    int number = int.Parse(inFile.ReadLine());
                    int number = int.Parse(Console.ReadLine());
                    int step = 2;
                    int[] lamps = new int[number+1];
                    int rezult = 0;
                    for (int i = 1; i <= number; i++)
                    {
                        lamps[i]=i;
                    }
                    int length = number;
                    int endFillPosition = 1;
                    int zeroPosition = 0;
                    for (int i = 1; i <= number; i++)
                    {
                       
                        if ((i-zeroPosition) != 1)
                        {
                            lamps[endFillPosition]=lamps[i];
                            endFillPosition++;
                        }
                        if (i - zeroPosition == step)
                        {
                            zeroPosition += step;
                        }
                        if (i == length)
                        {
                            length=endFillPosition-1;
                            if (length==1)
                            {
                                rezult = lamps[1];
                                break;
                            }
                            endFillPosition = 1;
                            step++;
                            i = 0;
                            zeroPosition = 0;
                        }
                    }
     
                    //string path1 = inFile.ReadLine();
                    //string path2 = inFile.ReadLine();
                    string path1 = Console.ReadLine();
                    string path2 = Console.ReadLine();
                    Console.WriteLine(rezult);
                    MoveTheRobot(path1);
                    MoveTheRobot(path2);
                    //sw.Stop();
                    //Console.WriteLine(sw.ElapsedMilliseconds);
                //}
               
               
            }
            private static void MoveTheRobot(string path1)
            {
                string direction = "Up";
                int currentX = 0;
                int currentY = 0;
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < path1.Length; i++)
                    {
                        switch (path1[i])
                        {
                            case 'S':
                                switch (direction)
                                {
                                    case "Up":
                                        currentY++;
                                        break;
                                    case "Down":
                                        currentY--;
                                        break;
                                    case "Left":
                                        currentX--;
                                        break;
                                    case "Right":
                                        currentX++;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 'R':
                                direction = ChangeDirection(direction, path1[i]);
                                break;
                            case 'L':
                                direction = ChangeDirection(direction, path1[i]);
                                break;
                            default:
                                break;
                        }
                    }
                    if (currentX == 0 && currentY == 0)
                    {
                        Console.WriteLine("bounded");
                        break;
                    }
                }
                if (!(currentX == 0 && currentY == 0))
                {
                    Console.WriteLine("unbounded");
                }
     
            }
     
            private static string ChangeDirection(string direction, char command)
            {
                string outDirection = String.Empty;
                switch (direction)
                {
                    case "Up":
                        if (command == 'R')
                        {
                            outDirection = "Right";
                        }
                        else
                        {
                            outDirection = "Left";
                        }
                        break;
                    case "Down":
                        if (command == 'R')
                        {
                            outDirection = "Left";
                        }
                        else
                        {
                            outDirection = "Right";
                        }
                        break;
                    case "Left":
                        if (command == 'R')
                        {
                            outDirection = "Up";
                        }
                        else
                        {
                            outDirection = "Down";
                        }
                        break;
                    case "Right":
                        if (command == 'R')
                        {
                            outDirection = "Down";
                        }
                        else
                        {
                            outDirection = "Up";
                        }
                        break;
                    default:
                        break;
                }
                return outDirection;
            }
        }
    }

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OneTaskIsNotEnough
//{
//    class OneTaskIsNotEnough
//    {
//        static void Main(string[] args)
//        {
//            int n = int.Parse(Console.ReadLine());
//            int lastLamp = LastLamp(n);
//            string command1 = Console.ReadLine();
//            string command2 = Console.ReadLine();
//            Console.WriteLine(lastLamp + 1);
//            BoundedOrNot(command1);
//            BoundedOrNot(command2);
//        }

//        static void BoundedOrNot(string command)
//        {
//            int[] dx = { 1, 0, -1, 0 };
//            int[] dy = { 0, 1, 0, -1 };

//            int x = 0;
//            int y = 0;
//            int orientation = 0;

//            for (int i = 0; i < 4; i++)
//            {
//                foreach (var item in command)
//                {
//                    if (item == 'S')
//                    {
//                        x += dx[orientation];
//                        y += dy[orientation];
//                    }
//                    else if (item == 'L')
//                    {
//                        orientation -= 1;
//                        orientation /= 4;
//                        orientation %= 4;
//                    }
//                    else if (item == 'R')
//                    {
//                        orientation += 1;
//                        orientation %= 4;
//                    }
//                }
//            }
//            if (x == 0 && y == 0)
//            {
//                Console.WriteLine("bounded");
//            }
//            else
//            {
//                Console.WriteLine("unbounded");
//            }
//        }

//        static int LastLamp(int n)
//        {
//            bool[] isSwitched = new bool[n];
//            int lastLamp = 0;
//            int nextLamp = 0;

//            while (nextLamp < isSwitched.Length - 1)
//            {
//                while (isSwitched[nextLamp])
//                {
//                    nextLamp++;
//                    if (nextLamp == isSwitched.Length)
//                    {
//                        break;
//                    }
//                }
//                int step = nextLamp + 2;
//                for (int i = nextLamp; i < isSwitched.Length; i += step)
//                {
//                    if (!isSwitched[i])
//                    {
//                        lastLamp = i;
//                        isSwitched[i] = true;
//                    }
//                }
//            }
//            return lastLamp;
//        }
//    }
//}
