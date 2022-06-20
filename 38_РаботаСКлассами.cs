using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _38_РаботаСКлассами
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Имя", 1000, 50);
            player.ShowInfo();
        }
    }

    class Player
    {
        private string _name;
        private int _health;
        private int _damage;

        public Player(string name, int health, int damage)
        {
            _name = name;
            _health = health;
            _damage = damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"У игрока {_name} - {_health} хп и {_damage} урона");
        }
    }
}
