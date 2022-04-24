using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25__2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minArraySize = 10;
            int maxArraySize = 25;
            int maxNumber = 10;
            int arraySize = random.Next(minArraySize, maxArraySize);
            int[] array = new int[arraySize];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(maxNumber);
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int arrayElement = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = arrayElement;
                    }
                }
            }

            foreach(int numberInArray in array)
            {
                Console.Write(numberInArray);
            }
        }
    }
}
