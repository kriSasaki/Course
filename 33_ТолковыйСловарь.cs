using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_ТолковыйСловарь
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Мебель", "Стул");
            dictionary.Add("Еда", "Хлеб");
            dictionary.Add("Животное", "Кошка"); 
            dictionary.Add("Страна", "Германия");
            dictionary.Add("Планета", "Земля");

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Введите слово: ");
                string inputWord = Console.ReadLine();

                if (dictionary.ContainsKey(inputWord))
                {
                    Console.WriteLine($"Значение: {dictionary[inputWord]}.");
                }
                else
                {
                    Console.WriteLine("Ошибка.");
                }
                Console.Clear();
            }
        }
    }
}
