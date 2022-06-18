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

            while (isWork)
            {
                foreach (int i in numbers)
                {
                    Console.Write(i + "|");
                }

                Console.Write("\nadd - добавить число, sum - сумма, exit - выход" +
                    "\nВведите команду: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "add":
                        AddNumber(numbers);
                        break;
                    case "sum":
                        SumOfNumbers(numbers);
                        break;
                    case "exit":
                        isWork = false;
                        break;
                }
                Console.Clear();
            }
        }

        static void AddNumber(List<int> numbers)
        {
            bool isNumberAdded = false;
            int number;

            while (isNumberAdded == false)
            {
                Console.Write("Введите число: ");
                string checkNumber = Console.ReadLine();

                if (Int32.TryParse(checkNumber, out number))
                {
                    numbers.Add(number);
                    isNumberAdded = true;
                }
                Console.Clear();
            }
        }

        static void SumOfNumbers(List<int>  numbers)
        {
            int sum = numbers.Sum();
            Console.WriteLine("Сумма всех чисел: " + sum);
            Console.ReadKey();
        }
    }
}
