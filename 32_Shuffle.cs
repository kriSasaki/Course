using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Shuffle(array);
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();
            int randomElement;
            int shuffledElement;

            for(int i = array.Length - 1; i >= 0; i--)
            {
                randomElement = random.Next(i);
                shuffledElement = array[randomElement];
                array[randomElement] = array[i];
                array[i] = shuffledElement;
                Console.Write(array[i]);
            }             
        }
    }
}
