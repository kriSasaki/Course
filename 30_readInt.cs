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
            int number = 0;

            while (isNumberConverted == false)
            {
                GetString(ref numberInString, ref isNumberConverted, ref number);
                if (isNumberConverted)
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

        static void GetString(ref string numberInString, ref bool checkTheString, ref int number)
        {
            Console.WriteLine("Введите строку: ");
            numberInString = Console.ReadLine();
            checkTheString = Int32.TryParse(numberInString, out number);
        }
    }
}
