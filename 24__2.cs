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
            int[] numbers = new int[30];
            int maxNumberInArray=10;
            int number=numbers[0];
            int amountOfNumbers = 1;
            int maxSequence = -1;
            int repeatingNumber = 0;

            for (int i=0;i<numbers.Length;i++)
            {
                numbers[i] = random.Next(maxNumberInArray);
                Console.Write(numbers[i] + " ");
            }
            
            for (int i = 1; i < numbers.Length; i++)
            {
                if (number == numbers[i])
                {
                    amountOfNumbers++;
                }
                
                else 
                {
                    if (amountOfNumbers > maxSequence)
                    {
                        maxSequence = amountOfNumbers;
                        repeatingNumber = number;
                    }
                    amountOfNumbers = 1;
                    number = numbers[i];
                }
            }
      
            if (amountOfNumbers>maxSequence)
            {
                maxSequence = amountOfNumbers;
            }
            Console.WriteLine("\n" + repeatingNumber + "  " + maxSequence);
        }
    }
}
