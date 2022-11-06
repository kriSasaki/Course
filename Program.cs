using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _52_CriminalSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal> { new Criminal("Резня", true, 150, 70, "Мексиканец"), new Criminal("Афро", false, 190, 80, "Американец"), new Criminal("Фелисье́н", false, 160, 110, "Руандиец"), new Criminal("Семен", false, 170, 90, "Русский"), new Criminal("Хоакин", false, 190, 90, "Мексиканец"), new Criminal("А", true, 190, 90, "Русский"), new Criminal("Б", false, 160, 50, "Русский") };
            bool isWorking= true;

            while (isWorking)
            {
                Console.WriteLine("Все преступники");

                foreach(var criminal in criminals)
                {
                    Console.WriteLine($"{criminal.Name}, рост - {criminal.Height}, вес - {criminal.Weight}, {criminal.Nationality}");
                }

                Console.Write("\nСортировка не пойманных преступников\nВведите рост преступника: ");
                int height = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите вес преступника: ");
                int weight = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите национальность преступника: ");
                string nationality = Console.ReadLine();

                var filteredCriminals = criminals.Where(criminal => criminal.IsPrisoner == false && criminal.Height == height && criminal.Weight == weight && criminal.Nationality == nationality);
                Console.WriteLine("\nСписки не пойманных преступников\n");

                foreach(var criminal in filteredCriminals)
                {
                    Console.WriteLine($"{criminal.Name}, рост - {criminal.Height}, вес - {criminal.Weight}, {criminal.Nationality}");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public bool IsPrisoner { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public Criminal(string name, bool isPrisoner, int height, int weight, string nationality)
        {
            Name = name;
            IsPrisoner = isPrisoner;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }
    }
}
