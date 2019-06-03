using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionTutor
{
    class Program
    {
        static void Main(string[] args)
        {
            DivisionTutor tutor = new DivisionTutor();

            float input = 0;
            Console.WriteLine("Welcome to Division Tutor");
            Console.WriteLine("try to enter the correct answer to the division questions");
            Console.WriteLine("enter 0 to quit");
            do
            {
                bool answeredCorrectly = false;
                tutor.GenerateQuestion();
                do
                {

                    float.TryParse(Console.ReadLine(), out input);
                    answeredCorrectly = tutor.CheckAnswer(input);
                    if (!answeredCorrectly)
                    {
                        Console.WriteLine("incorrect try again");
                    }
                    else
                    {
                        Console.WriteLine("correct");
                    }

                } while (!answeredCorrectly);

                
            } while (input != 0);
        }
    }

    class DivisionTutor
    {
        private
        int num1;
        int num2;

        float answer;

        public
        int Min = 1;
        int Max = 10;

        //why
        int RandomNumber(int min, int max)
        {
            int randSeed = (int)DateTime.Now.Millisecond;
            Console.WriteLine(randSeed);
            Random rnd = new Random(randSeed);
           
            return rnd.Next(min, max);
        }
        public void GenerateQuestion()
        {
            num1 = RandomNumber(Min, Max);
            
            num2 = RandomNumber(Min, Max);

            double num = (double)num1 / (double)num2;
            //answer =Math.Round(num,2, MidpointRounding.AwayFromZero);
            DisplayQuestion(num1, num2);
            Math.Round(2.035, 2, MidpointRounding.AwayFromZero)
        }

        void DisplayQuestion(int divisor,int dividend)
        {
            Console.WriteLine(divisor + "/" + dividend + "=");

        }

        public bool CheckAnswer(float answerToCheck)
        {

            return answerToCheck == answer;
        }

    }
}
