using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _53_Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> prisoners = new List<Citizen> { new Citizen("Джорджи Костава", "Антиправительственное"), new Citizen("Димитрий", "1"), new Citizen("Кевин Каулинский", "Антиправительственное"), new Citizen("Кордон Калло", "Антиправительственное"), new Citizen("М. Вонел", "2") };

            ShowPrisoners(prisoners);

            prisoners = HoldAmnesty(prisoners);

            Console.WriteLine("\nЗаключенные после амнистии\n");
            ShowPrisoners(prisoners);
        }

        private static void ShowPrisoners(List<Citizen> citizens)
        {
            foreach (var citizen in citizens)
            {
                Console.WriteLine($"{citizen.Name}, преступление - {citizen.Crime}");
            }
        }

        private static List<Citizen> HoldAmnesty(List<Citizen> prisoners)
        {
            string judgement = "Антиправительственное";
            return prisoners.Where(prisoner => prisoner.Crime != judgement).ToList();
        }
    }

    class Citizen
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }

        public Citizen(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }
    }
}
