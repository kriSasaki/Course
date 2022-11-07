using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _56_DefinitionOfAnExpiredProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.ShowCans(storage.GetCans());
            Console.WriteLine("\nПропавшие консервы:\n");
            storage.FilterExpiredCans();
        }
    }

    class Storage
    {
        private List<Can> _cansOfStew = new List<Can>();
        private int _year = 2022;

        public Storage()
        {
            _cansOfStew.Add(new Can("Коровка", 1937, 5));
            _cansOfStew.Add(new Can("Микоян", 2020, 2));
            _cansOfStew.Add(new Can("Честный продукт", 2019, 5));
            _cansOfStew.Add(new Can("Гродфуд", 2018, 3));
            _cansOfStew.Add(new Can("Совок", 2021, 1));
        }

        public void ShowCans(List<Can> cans)
        {
            foreach(var can in cans)
            {
                Console.WriteLine($"{can.Title}, год производства - {can.YearOfProduction}, срок хранения {can.ExpirationDate}");
            }
        }

        public void FilterExpiredCans()
        {
            var expiredCans = _cansOfStew.Where(can => _year - can.YearOfProduction > can.ExpirationDate).ToList();
            ShowCans(expiredCans);
        }

        public List<Can> GetCans()
        {
            return _cansOfStew;
        }
    }

    class Can
    {
        public string Title { get; private set; }
        public int YearOfProduction { get; private set; }
        public int ExpirationDate { get; private set; }

        public Can(string title, int yearOfProduction, int expirationTime)
        {
            Title = title;
            YearOfProduction = yearOfProduction;
            ExpirationDate = expirationTime;
        }
    }
}
