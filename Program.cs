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
            database.Menu();
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        
        public void Menu()
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
                
                Console.Write("Введите порядковый номер для удаления игрока: ");
                string stringInNumber = Console.ReadLine();

                if (Int32.TryParse(stringInNumber, out int sequenceNumber))
                {
                    _players.RemoveAt(sequenceNumber - 1);
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
                
                Console.Write("Введите порядковый номер для бана игрока: ");
                string stringInNumber = Console.ReadLine();
                
                if (Int32.TryParse(stringInNumber, out int sequenceNumber))
                {
                    if (_players[sequenceNumber - 1].IsBanned == false)
                    {
                        _players[sequenceNumber - 1].AddToBan();
                        GetMessage("Игрок успешно забанен.");
                    }
                    else if (_players[sequenceNumber - 1].IsBanned == true)
                    {
                        GetMessage("Игрок уже забанен.");
                    }
                    else
                    {
                        GetMessage("Номер неверный.");
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
                
                Console.Write("Введите порядковый номер для разбана игрока: ");
                string stringInNumber = Console.ReadLine();
                
                if (Int32.TryParse(stringInNumber, out int sequenceNumber))
                {
                    if (_players[sequenceNumber - 1].IsBanned == true)
                    {
                        _players[sequenceNumber - 1].RemoveFromBan();
                        GetMessage("Игрок успешно разбанен.");
                    }
                    else if (_players[sequenceNumber - 1].IsBanned == false)
                    {
                        GetMessage("Игрок уже не в бане.");
                    }
                    else
                    {
                        GetMessage("Номер неверный.");
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



        private void ShowPlayers()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                Console.Write(i + 1 + ". ");
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
        private string _flag;
        public bool IsBanned { get; private set; }

        public Player(string name, int level)
        {
            _name = name;
            _level = level;
            IsBanned = false;
        }

        public void PlayerDetails()
        {
            if (IsBanned == false)
            {
                _flag = "не забанен";
            }
            else
            {
                _flag = "забанен";
            }
            Console.WriteLine($"Ник персонажа - {_name}, уровень - {_level}, статус бана - {_flag}");
        }

        public void AddToBan()
        {
            IsBanned = true;
        }

        public void RemoveFromBan()
        {
            IsBanned = false;
        }
    }
}
