using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24__2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[10];
            int maxNumber=10;
            int number=0;
            int amount = 1;

            for (int i =0;i<numbers.Length;i++)
            {
                numbers[i] = random.Next(maxNumber);
                Console.Write(numbers[i] + " ");
            }
            for(int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    number = numbers[i];
                    amount++;
                }
                else
                {
                    break;
                }
            }
            if (amount == 1)
            {
                Console.WriteLine("---");
            }
            else
            {
                Console.WriteLine("\n" + number + "  " + amount);
            }
        }
    }
}
