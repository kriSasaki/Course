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

            for (int i = 1; i <= number; i++)
            {
                if (i <= number / multipleThree || i <= number / multipleFive)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
