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
            int sumOfmultipleThree = 0;
            int sumOfmultipleFive = 0;

            for (int i = 1; i <= number/ multipleThree; i += 1)
            {
                sumOfmultipleThree += multipleThree;
            }
            for (int i = 1; i <= number / multipleFive; i += 1)
            {
                sumOfmultipleFive += multipleFive;
            }
            Console.WriteLine(sumOfmultipleThree + "  " + sumOfmultipleFive);
        }
    }
}
