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
            Random rand = new Random();
            int[] array = new int[30];
            string localMaximum = "";

            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = rand.Next(10);
                Console.Write(array[i]);

                if (i==array.GetLength(0)-1 && array[0]>array[1])
                {
                    localMaximum += array[0];
                }

                if (i == array.GetLength(0) - 1)
                {
                    for (int j = 1; j < array.GetLength(0); j++)
                    {
                        if (array[j]>array[j-1]&& array[j] > array[j + 1])
                        {
                            localMaximum += array[j];
                        }
                    }
                }
                
                if (i == array.GetLength(0) - 1 && (array[array.GetLength(0)-1] > array[array.GetLength(0) - 2]))
                {
                    localMaximum += array[array.GetLength(0) - 1];
                }
            }
            Console.WriteLine("\n"+localMaximum);
        }
    }
}
