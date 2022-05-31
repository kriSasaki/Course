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
            GetNumber();
        }

        static int GetNumber()
        {
            bool isNumberConverted = false;
            int number = 0;

            while (isNumberConverted == false)
            {
                Console.WriteLine("Введите строку: ");
                string numberInString = Console.ReadLine();
                
                if (isNumberConverted = Int32.TryParse(numberInString, out number))
                {                   
                    Console.WriteLine("Число: " + number);
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("Нельзя сконфертировать");
                }
                Console.ReadKey();
                Console.Clear();
            }
            return number;
        }
    }
}
