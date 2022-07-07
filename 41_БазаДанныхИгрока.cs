using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _41_БазаДанныхИгрока
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.Work();
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("1 - Список игроков" +
                    "\n2 - Добавить игрока" +
                    "\n3 - Удалить игрока" +
                    "\n4 - Забанить игрока" +
                    "\n5 - Разбанить игрока" +
                    "\n6 - Выход");
                Console.Write("введите команду: ");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        ShowPlayers();
                        break;
                    case "2":
                        AddPlayer();
                        break;
                    case "3":
                        RemovePlayer();
                        break;
                    case "4":
                        BanPlayer();
                        break;
                    case "5":
                        UnbanPlayer();
                        break;
                    case "6":
                        isWork = false;
                        break;
                }
            }
        }

        private void ShowPlayers()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                Console.Write("Порядковый индекс игрока - " + i + ". ");
                _players[i].ShowPlayerDetails();
            }
            ShowMessage("====================================================" +
                "\nКонец списка.");
        }
        private void AddPlayer()
        {
            Console.Write("Введите никнейм игрока: ");
            string name = Console.ReadLine();
            Console.Write("Введите уровень игрока: ");
            string levelCheck = Console.ReadLine();

            if (Int32.TryParse(levelCheck, out int level))
            {
                _players.Add(new Player(name, level));
                ShowMessage("Игрок успешно добавлен.");
            }
            else
            {
                ShowMessage("Введите корректные данные");
            }
        }

        private bool TryGetId(out int playerIndex)
        {
            playerIndex = 0;
            string userInput = Console.ReadLine();
            bool isPlayerFind = false;

            if (int.TryParse(userInput, out int result))
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (result == _players[i].playerId)
                    {
                        playerIndex = i;
                        isPlayerFind = true;
                    }
                }
            }

            return isPlayerFind;
        }

        private void RemovePlayer()
        {
            if (_players.Count > 0)
            {
                ShowPlayers();

                Console.Write("Введите ID игрока для его удаления: ");

                if (TryGetId(out int playerIndex))
                {
                    _players.RemoveAt(playerIndex);
                    ShowMessage("Данный игрок успешно удален.");
                }
                else
                {
                    ShowMessage("Введите корректные данные");
                }
            }
            else
            {
                ShowMessage("База данных пуста");
            }
        }

        private void BanPlayer()
        {
            if (_players.Count > 0)
            {
                ShowPlayers();

                Console.Write("Введите id игрока для его бана: ");

                if (TryGetId(out int playerIndex))
                {
                    if (_players[playerIndex].IsBanned == false)
                    {
                        _players[playerIndex].Ban();
                        ShowMessage("Игрок успешно забанен.");
                    }
                    else
                    {
                        ShowMessage("Игрок уже в бане.");
                    }
                }
                else
                {
                    ShowMessage("Ошибка ввода.");
                }
            }
            else
            {
                ShowMessage("База данных пуста");
            }
        }

        private void UnbanPlayer()
        {
            if (_players.Count > 0)
            {
                ShowPlayers();

                Console.Write("Введите id для разбана игрока: ");

                if (TryGetId(out int playerIndex))
                {
                    if (_players[playerIndex].IsBanned == true)
                    {
                        _players[playerIndex].Unban();
                        ShowMessage("Игрок успешно разбанен.");
                    }
                    else
                    {
                        ShowMessage("Игрок уже не в бане.");
                    }
                }
                else
                {
                    ShowMessage("Ошибка ввода.");
                }
            }
            else
            {
                ShowMessage("База данных пуста");
            }
        }

        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Player
    {
        private string _name;
        private int _level;
        public static int ids;
        public int playerId { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string name, int level)
        {
            _name = name;
            _level = level;
            playerId = ++ids;
            IsBanned = false;
        }



        public void ShowPlayerDetails()
        {
            string banCheck;

            if (IsBanned == false)
            {
                banCheck = "не забанен";
            }
            else
            {
                banCheck = "забанен";
            }
            Console.WriteLine($"ID персонажа - {playerId}, ник персонажа - {_name}, уровень - {_level}, статус бана - {banCheck}");
        }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }
}
