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
            commandCenter.TransferOfSoldiers();
            Console.WriteLine("\nОтряды после перераспределения\n");
            commandCenter.ShowTroops();
        }
    }

    class CommandCenter
    {
        private List<Soldier> _firstTroop = new List<Soldier>();
        private List<Soldier> _secondTroop = new List<Soldier>();
        private string[] _names = { "Красноруцкий", "Бабурин ", "Вахтин", "Баранов", "Трунов" };
        private static Random _random = new Random();

        public CommandCenter()
        {
            CreateTroop(_firstTroop, 10);
            CreateTroop(_secondTroop, 10);
        }

        public void TransferOfSoldiers()
        {
            string filteringLetter = "Б";
            var filteredTroop = ElectSoldiers(ref _firstTroop, filteringLetter).ToList();

            Console.WriteLine("\nСолдаты отправленные на перераспределение\n");
            
            foreach (var troop in filteredTroop)
            {
                Console.WriteLine(troop.Name);
            }
            
            _secondTroop = _secondTroop.Union(filteredTroop).ToList();
        }

        public void ShowTroops()
        {
            ShowSoldiers(_firstTroop);
            Console.WriteLine();
            ShowSoldiers(_secondTroop);
        }

        public List<Soldier> ElectSoldiers(ref List<Soldier> soldiers, string filteringLetter)
        {
            var filteredSoldiers = soldiers.Where(soldier => soldier.Name.ToUpper().StartsWith(filteringLetter)).ToList();
            soldiers = soldiers.Except(filteredSoldiers).ToList();
            Console.WriteLine();
            return filteredSoldiers;
        }

        public void ShowSoldiers(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"{soldier.Name}");
            }
        }

        private void CreateTroop(List<Soldier> soldiers, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                int nameID = GetNameID();
                soldiers.Add(new Soldier(_names[nameID]));
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
