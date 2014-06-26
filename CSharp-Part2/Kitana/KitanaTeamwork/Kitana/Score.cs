using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitana_01;

namespace Kitana_01
{
    class Score
    {
        private const int INCREMENT_VALUE = 10;
        private const int DEFAULT_X = 60;
        private const int DEFAULT_Y = 6;

        private double currentScore;
        private double finalscore;
        private int X;
        private int Y;
        

        public Score()
        {
            currentScore = 0;
            X = DEFAULT_X;
            Y = DEFAULT_Y;
        }
        public double CurrentScore
        {
            get { return currentScore; }
            set
            {
                currentScore = value;

            }
        }
        public double Finalscore
        {
            get { return finalscore; }
            set
            {
                finalscore = value;

            }
        }
        public Score(int paramX, int paramY)
        {
            currentScore = 0;
            X = paramX;
            Y = paramY;

        }

        public double get()
        {
            return currentScore;
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

        //adds 10 points to the current score (on a new correctly guessed word position)
        public void increment()
        {
            currentScore += INCREMENT_VALUE;
            finalscore += INCREMENT_VALUE;
        }

        //penalty - lose half of the points (when you hit a rock?)
        public void decrement()
        {
            if (currentScore > 0)
            {
                currentScore /= 2;
                Finalscore /= 2;
            }
        }

        public void print()
        {
            Console.SetCursorPosition(X, Y);
            Console.CursorVisible = false;
            Console.WriteLine("Score: {0,-10}", currentScore);
            Console.SetCursorPosition(X , Y + 4);
            Console.WriteLine("Total: {0,-10}", Finalscore);
        }

        
    }
}
