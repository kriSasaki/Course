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
            string numberInString = null;
            bool isNumberConverted = false;

            while (isNumberConverted == false)
            {
                GetString(ref numberInString);
                if (Int32.TryParse(numberInString, out int number))
                {
                    Console.WriteLine("Число: " + number);
                    Console.ReadKey();
                    isNumberConverted = true;
                }
                else
                {
                    Console.WriteLine("Нельзя сконфертировать");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void GetString(ref string numberInString)
        {
            Console.WriteLine("Введите строку: ");
            numberInString = Console.ReadLine();
        }
    }
}
