using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_ДинамическийМассив
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool isWork = true;
            int sum = 0;

            while (isWork)
            {
                int number;
                
                foreach (int numberInNumbers in numbers)
                {
                    Console.Write(numberInNumbers + "|");
                }
                
                Console.Write("\nВведите число, либо sum - сумма, либо exit - выход" +
                    "\n");
                string command = Console.ReadLine();

                if (Int32.TryParse(command, out number))
                {
                    numbers.Add(number);
                }
                else if (command == "sum")
                {
                    SumOfNumbers(numbers, out sum);
                }
                else if(command == "exit")
                {
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Ошибка!!!");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }


        static void SumOfNumbers(List<int>  numbers, out int sum)
        {
            sum = numbers.Sum();
            Console.WriteLine("\nСумма всех чисел: " + sum);
            Console.ReadKey();
        }
    }
}
