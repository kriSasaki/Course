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
            database.ShowMenu();
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void ShowMenu()
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
        private void AddPlayer()
        {
            Console.Write("Введите никнейм игрока: ");
            string name = Console.ReadLine();
            Console.Write("Введите уровень игрока: ");
            string levelCheck = Console.ReadLine();

            if (Int32.TryParse(levelCheck, out int level))
            {
                _players.Add(new Player(name, level));
                GetMessage("Игрок успешно добавлен.");
            }
            else
            {
                GetMessage("Введите корректные данные");
            }
        }

        private void GetMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Console.Clear();
        }

        private void RemovePlayer()
        {
            if (_players.Count > 0)
            {
                ShowPlayers();

                Console.Write("Введите id игрока для его удаления: ");

                if (TryGetId(out int _id))
                {
                    _players.RemoveAt(_id - 1);
                    GetMessage("Данный игрок успешно удален.");
                }
                else
                {
                    GetMessage("Введите корректные данные");
                }
            }
            else
            {
                GetMessage("База данных пуста");
            }
        }

        private void BanPlayer()
        {
            if (_players.Count > 0)
            {
                ShowPlayers();

                Console.Write("Введите id игрока для его бана: ");

                if (TryGetId(out int _id))
                {
                    if (_players[_id - 1].IsBanned == false)
                    {
                        _players[_id - 1].Ban();
                        GetMessage("Игрок успешно разбанен.");
                    }
                    else
                    {
                        GetMessage("Игрок уже не в бане.");
                    }
                }
                else
                {
                    GetMessage("Ошибка ввода.");
                }
            }
            else
            {
                GetMessage("База данных пуста");
            }
        }

        private void UnbanPlayer()
        {
            if (_players.Count > 0)
            {
                ShowPlayers();

                Console.Write("Введите id для разбана игрока: ");

                if (TryGetId(out int id))
                {
                    if (_players[id - 1].IsBanned == true)
                    {
                        _players[id - 1].Unban();
                        GetMessage("Игрок успешно разбанен.");
                    }
                    else
                    {
                        GetMessage("Игрок уже не в бане.");
                    }
                }
                else
                {
                    GetMessage("Ошибка ввода.");
                }
            }
            else
            {
                GetMessage("База данных пуста");
            }
        }

        private bool TryGetId(out int result)
        {
            string userInput = Console.ReadLine();
            bool isStringNumber = int.TryParse(userInput, out result);
            return isStringNumber;
        }

        private void ShowPlayers()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                Console.Write("Id игрока - " + i + 1 + ". ");
                _players[i].PlayerDetails();
            }
            GetMessage("====================================================" +
                "\nКонец списка.");
        }
    }

    class Player
    {
        private string _name;
        private int _level;
        public bool IsBanned { get; private set; }

        public Player(string name, int level)
        {
            _name = name;
            _level = level;
            IsBanned = false;
        }

        public void PlayerDetails()
        {
            string flag;

            if (IsBanned == false)
            {
                flag = "не забанен";
            }
            else
            {
                flag = "забанен";
            }
            Console.WriteLine($"Ник персонажа - {_name}, уровень - {_level}, статус бана - {flag}");
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
