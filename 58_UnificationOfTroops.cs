using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _58_UnificationOfTroops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommandCenter commandCenter = new CommandCenter();
            commandCenter.ShowTroops();
            Console.WriteLine("\nОтряды после перераспределения\n");
            commandCenter.RedistributionOfSoldiers();
        }
    }

    class CommandCenter
    {
        private Troop _firstTroop = new Troop();
        private Troop _secondTroop = new Troop();

        public void RedistributionOfSoldiers()
        {
            var filteredTroop = _firstTroop.FilterSoldiers().ToList();

            Console.WriteLine("Солдаты отправленные на перераспределение");
            
            foreach (var troop in filteredTroop)
            {
                Console.WriteLine(troop.Name);
            }

            _secondTroop.UnionTroops(filteredTroop);
        }

        public void ShowTroops()
        {
            _firstTroop.ShowSoldiers();
            Console.WriteLine();
            _secondTroop.ShowSoldiers();
        }
    }

    class Troop
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        private string[] _names = { "Красноруцкий", "Бабурин ", "Вахтин", "Баранов", "Трунов" };
        private static Random _random = new Random();

        public Troop()
        {
            CreateTroop(10);
        }

        public List<Soldier> FilterSoldiers()
        {
            var filteredSoldiers = _soldiers.Where(soldier => soldier.Name.ToUpper().StartsWith("Б")).ToList();
            _soldiers = _soldiers.OrderBy(soldier => soldier.Name).ToList();
            _soldiers = _soldiers.SkipWhile(soldier => soldier.Name.ToUpper().StartsWith("Б")).ToList();
            ShowSoldiers();
            Console.WriteLine();
            return filteredSoldiers;
        }

        public void ShowSoldiers()
        {
            foreach (var soldier in _soldiers)
            {
                Console.WriteLine($"{soldier.Name}");
            }
        }

        public void UnionTroops(List<Soldier> soldiers)
        {
            _soldiers = _soldiers.Union(soldiers).ToList();
            Console.WriteLine();
            ShowSoldiers();
        }

        private void CreateTroop(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                int nameID = GetNameID();
                _soldiers.Add(new Soldier(_names[nameID]));
            }
        }

        private int GetNameID()
        {
            return _random.Next(_names.Length);
        }
    }

    class Soldier
    {
        public string Name { get; private set; }

        public Soldier(string name)
        {
            Name = name;
        }
    }
}
