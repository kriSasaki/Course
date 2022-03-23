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
            int multiple = 3;
            int sum = 0;

            for (int i = 1; i <= number/multiple; i += 1)
            {
                sum += multiple;
            }
            Console.WriteLine(sum);
        }
    }
}
