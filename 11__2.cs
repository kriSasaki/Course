using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxNumber = 100;
            int number = random.Next(maxNumber);
            int multipleThree = 3;
            int multipleFive = 5;
            int sum = 0;
            bool IsAllMultiplefound = false;

            for (int i = 1; i <= number / multipleThree; i += 1)
            {
                sum += multipleThree;
                if (i == number / multipleThree)
                {
                    Console.WriteLine(sum);
                    IsAllMultiplefound = true;
                }
            }
            if (!IsAllMultiplefound)
            {
                sum = 0;
                for (int i = 1; i <= number / multipleFive; i += 1)
                {
                    sum += multipleFive;
                    if (i == number / multipleFive)
                    {
                        Console.WriteLine(sum);
                    }
                }
            }
        }
    }
}
