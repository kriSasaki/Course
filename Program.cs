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
            int[,] A = new int[10, 10];
            int largestNumber = int.MinValue;
            int[] coordinates = new int[2];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    A[i, j] = rand.Next(1, 10);
                    Console.Write(A[i, j] + " ");
                    if (A[i, j] > largestNumber)
                    {
                        largestNumber = A[i, j];
                        coordinates[0] = i;
                        coordinates[1] = j;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(largestNumber);

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    A[coordinates[0], coordinates[1]] = 0;
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
