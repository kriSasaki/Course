using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };

            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("Введите количество сдвигов: ");
            int amount = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                int firstNumber = array[0];
                for (int j = array[0]; j < array.Length; j++)
                {
                    array[j-1] = array[j];
                }
                array[array.Length-1] = firstNumber;
            }

            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
        }
    }
}
