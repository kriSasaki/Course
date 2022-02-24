using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] array = new int[10, 10];
            int largestNumber = int.MinValue;
            int[] coordinatesOfLargestNumber = new int[2];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array[i, j] = rand.Next(1, 10);
                    Console.Write(array[i, j] + " ");
                    if (array[i, j] > largestNumber)
                    {
                        largestNumber = array[i, j];
                        coordinatesOfLargestNumber[0] = i;
                        coordinatesOfLargestNumber[1] = j;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(largestNumber);
            array[coordinatesOfLargestNumber[0], coordinatesOfLargestNumber[1]] = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
