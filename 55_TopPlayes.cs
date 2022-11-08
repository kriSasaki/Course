using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _55_TopPlayers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxTopPlayers = 3;
            Server server = new Server();
            Console.WriteLine($"\nТоп {maxTopPlayers} игрока по уровню:");
            server.ShowTopLevelPlayers(maxTopPlayers);
            Console.WriteLine($"\nТоп {maxTopPlayers} игрока по силе:");
            server.ShowTopPowerPlayers(maxTopPlayers);
        }
    }

    class Server
    {
        private List<Player> _players = new List<Player>();
        
        public Server()
        {
            _players.Add(new Player("Джони", 20, 1300));
            _players.Add(new Player("Боб", 99, 0));
            _players.Add(new Player(" ", 999, 99999999));
            _players.Add(new Player("lol", 5, 100));
            _players.Add(new Player("amogus", 13, 500));
            _players.Add(new Player("imposter", 77, 4352));
            _players.Add(new Player("sus", 33, 876));
            _players.Add(new Player("killer228", 123, 321321321));
            _players.Add(new Player("1337", 1337, 1337));
            _players.Add(new Player("Huggy Wuggy", 1, 1));
            _players.Add(new Player("Kissy Missy", 1, 1));
            _players.Add(new Player("щищ", 11, 11111));
        }

        public void ShowPlayers(List<Player> players)
        {
            foreach(var player in players)
            {
                Console.WriteLine($"{player.Name}, уровень - {player.Level}, сила - {player.Power}");
            }
        }

        public void ShowTopLevelPlayers(int maxTopPlayers)
        {
            var filteredPlayers = _players.OrderByDescending(player => player.Level).Take(maxTopPlayers).ToList();
            ShowPlayers(filteredPlayers);
        }

        public void ShowTopPowerPlayers(int maxTopPlayers)
        {
            var filteredPlayers = _players.OrderByDescending(player => player.Power).Take(maxTopPlayers).ToList();
            ShowPlayers(filteredPlayers);
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }
    }
}
