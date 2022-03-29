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
            int fisrtMultiplee = 3;
            int secondMultiple = 5;
            int sum = 0;
             
            for (int i = 0; i <= number; i++)
            {
                if (i % fisrtMultiplee == 0 || i % secondMultiple == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine(number +"   "+sum);
        }
    }
}
