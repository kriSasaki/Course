using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[30];
            string localMaximum = "";
            int i;

            for (i = 0; i < array.GetLength(0); i++)
            {
                array[i] = random.Next(10);
                Console.Write(array[i]);
            }

            if (array[0] > array[1])
            {
                localMaximum += array[0];
            }

            for (int j = 1; j < array.GetLength(0)-1; j++)
            {
                if (array[j] > array[j - 1] && array[j] > array[j + 1])
                {
                    localMaximum += array[j];
                }
            }

            if (array[array.GetLength(0) - 1] > array[array.GetLength(0) - 2])
            {
                localMaximum += array[array.GetLength(0) - 1];
            }

            Console.WriteLine("\n" + localMaximum);
        }
    }
}
