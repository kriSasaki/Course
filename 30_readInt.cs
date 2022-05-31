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
            GetString();
        }

        static void GetString()
        {
            bool isNumberConverted = false;
            while (isNumberConverted == false)
            {
                Console.WriteLine("Введите строку: ");
                string numberInString = Console.ReadLine();
                
                if (isNumberConverted = Int32.TryParse(numberInString, out int number))
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
        }
    }
}
