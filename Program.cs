using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] array = new int[4, 4];
            int sum=0;
            int product = 1;
            int secondLine = 2;
            int firstColumn = 1;
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(1, 10);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            
            for (int i =0;i<array.GetLength(0); i++)
            {
                sum += array[secondLine-1, i];
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                product *= array[i, firstColumn-1];
            }

            Console.WriteLine(sum);
            Console.WriteLine(product);
        }
    }
}
