using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitana_01
{
    class Timer
    {
        private const int DEFAULT_GAME_TIME = 90; // in seconds 
        private const int DEFAULT_X = 60;
        private const int DEFAULT_Y = 8;

        private int timeInterval;
        private int startTime;
        private int currentTime;
        private int endTime;
        private int timeLeft;
        private int X;
        private int Y;

        public Timer()
        {
            initTimer(DEFAULT_GAME_TIME, DEFAULT_X, DEFAULT_Y);
        }

        public Timer(int time)
        {
            initTimer(time, DEFAULT_X, DEFAULT_Y);
        }

        public Timer(int time, int paramX, int paramY) // Timer t = new Timer(40, 60, 8) - if we want to reduce the time for next levels;
        {
            initTimer(time, paramX, paramY);
        }

        private void initTimer(int time, int paramX, int paramY)
        {
            timeInterval = time;

            startTime = getCurrentTime();
            currentTime = startTime;
            endTime = startTime + time;
            //Console.WriteLine("Start time is: " + startTime);
            //Console.WriteLine(endTime);
            X = paramX;
            Y = paramY;
        }

        public void setX(int paramX)
        {
            X = paramX;
        }

        public void setY(int paramY)
        {
            Y = paramY;
        }

        public void setCoord(int paramX, int paramY)
        {
            setX(paramX);
            setY(paramY);
        }

        private int getCurrentTime()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }

        private bool checkTick()
        {
            if (getCurrentTime() > currentTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateTimer()
        {
            if (checkTick())
            {
                currentTime += 1; // increment with 1 second
                timeLeft = timeInterval - (currentTime - startTime);

                if (timeLeft >= 0)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.CursorVisible = false;
                    Console.WriteLine("Time: {0,-5}", timeLeft);
                    if (timeLeft > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false; // NOTE: We return false only if time is over!
                }
            }
            else
            {
                return true;
            }
        }

    }
}
