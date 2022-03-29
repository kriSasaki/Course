using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 1;
            int maxNumber = 27;
            int number = random.Next(minNumber, maxNumber);
            int maxLimit = 999;
            int minLimit = 100;
            int amount = 0;

            for(int i=0; i <= maxLimit; i += number)
            {
                if (i >= minLimit)
                {
                    amount += 1;
                }
            }
            Console.WriteLine(amount);
        }
    }
}
