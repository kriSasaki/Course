using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57_WeaponsReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoldiersBase soldiers = new SoldiersBase();
            soldiers.ShowNamesAndRanks();
        }
    }

    class SoldiersBase
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public SoldiersBase()
        {
            _soldiers.Add(new Soldier("Иван", "Гранатомет", "Рядовой", 13));
            _soldiers.Add(new Soldier("Петр", "Автомат", "Капрал", 21));
            _soldiers.Add(new Soldier("Сергей", "Гранатомет", "Майор", 46));
            _soldiers.Add(new Soldier("Иван", "Пистолет", "Полковник", 50));
            _soldiers.Add(new Soldier("Константин", "Пулемет", "Рядовой", 8));
        }

        public void ShowNamesAndRanks()
        {
            var filtredSoldiers = _soldiers.Select(soldier => new
                                  {
                                      name = soldier.Name,
                                      rank = soldier.Rank
                                  });

            foreach(var soldier in filtredSoldiers)
            {
                Console.WriteLine($"{soldier.name}, {soldier.rank}");
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Rank { get; private set; }
        public int ServiceTime { get; private set; }

        public Soldier(string name, string armament, string rank, int serviceTime)
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            ServiceTime = serviceTime;
        }
    }
}
