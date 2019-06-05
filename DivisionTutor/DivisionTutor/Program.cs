using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DivisionTutor
{
    class Program
    {
        static void Main(string[] args)
        {
            DivisionTutor tutor = new DivisionTutor();

            float input = 0;

            //Instructions
            Console.WriteLine("Welcome to Division Tutor");
            Console.WriteLine("Try to enter the correct answer to the division questions (out to 2 decimal places)");
            Console.WriteLine("Enter 0 to quit");

            //loops untill they input 0 to quit
            do
            {
                bool answeredCorrectly = false;
                tutor.GenerateQuestion();

                //loops untill they answer the question correctly
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

                } while (!answeredCorrectly && input !=0);

                
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


        /// <summary>
        /// Generates a Question with 2 random numbers and displays the question
        /// </summary>
        public void GenerateQuestion()
        {
            num1 = RandomNumber(Min, Max);
            // had to make it wait because it was seeding the same milisecond and returning the same number
            Thread.Sleep(1);
            num2 = RandomNumber(Min, Max);

            //round to a double
            double num = (double)num1 / (double)num2;
            answer = (float)Math.Round(num, 2, MidpointRounding.AwayFromZero);
            DisplayQuestion(num1, num2);
        }

        /// <summary>
        /// Generates a random number between 2 numbers
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        int RandomNumber(int min, int max)
        {
            int randSeed = (int)DateTime.Now.Millisecond;    
            Random rnd = new Random(randSeed);
           
            return rnd.Next(min, max);
        }


        /// <summary>
        /// Displays the question with the correct syntax
        /// </summary>
        /// <param name="divisor"></param>
        /// <param name="dividend"></param>
        void DisplayQuestion(int divisor,int dividend)
        {
            Console.WriteLine(divisor + "/" + dividend + "=");

        }

        //returns wether the answer is correct or not
        public bool CheckAnswer(float answerToCheck)
        {
            return answerToCheck == answer;
        }

    }
}
