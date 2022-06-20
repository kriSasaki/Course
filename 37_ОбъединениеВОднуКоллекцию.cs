using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_ОбъединениеВОднуКоллекцию
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int[] array1 = { 3, 5, 8 };
            int[] array2 = { 3, 2 };

            AddNumberInList(numbers, array1);
            AddNumberInList(numbers, array2);

            foreach(int number in numbers)
            {
                Console.Write(number);
            }
        }

        static void AddNumberInList(List<int> numders, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (numders.Contains(array[i]) == false)
                {
                    numders.Add(array[i]);
                }
            }
        }
    }
}
