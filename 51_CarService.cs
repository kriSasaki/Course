using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _51_CarService
{
    class Program
    {
        static void Main(string[] args)
        {
            CarSevice carSevice = new CarSevice();
            bool isWork = true;

            while (isWork)
            {
                const string CommandOpenService = "1";
                const string CommandExit = "2";
                carSevice.ShowParts();
                Console.WriteLine($"\n{CommandOpenService} - открыть автосервис" +
                    $"\n{CommandExit} - выйти");
                string command = Console.ReadLine();
                Console.Clear();

                switch (command)
                {
                    case CommandOpenService:
                        carSevice.Open();
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод");
                        break;
                }
            }
        }
    }

    class CarSevice
    {
        private Car _car;
        private List<Storage> _storages = new List<Storage>();
        private Random _random = new Random();
        public double Money { get; private set; }

        public CarSevice()
        {
            int minMoney = 5000;
            int maxMoney = 10000;
            Money = _random.Next(minMoney, maxMoney);
            AddParts();
        }

        public void ShowParts()
        {
            int index = 0;
            Console.WriteLine($"Мастерская. Доступно {Money}. Детали в наличии:");

            foreach (var storage in _storages)
            {
                index++;
                Console.Write($"{index}. ");
                storage.ShowInfo();
            }
        }

        public void Open()
        {
            bool isOpen = true;

            while (isOpen)
            {
                _car = new Car();
                bool replacing = true;

                while (replacing)
                {
                    const string CommandStop = "stop";
                    ShowParts();
                    Console.WriteLine("\nПриехала новая машина");
                    _car.ShowParts();
                    Console.WriteLine($"\n Выберите деталь для замены или '{CommandStop}' для завершения ремонта: ");
                    string command = Console.ReadLine();

                    if (command == CommandStop)
                    {
                        replacing = false;
                    }
                    else if (int.TryParse(command, out int partNumber) && ReplacePart(partNumber, out double fullPayment, out bool isPartUnbroken))
                    {                        
                        if (isPartUnbroken)
                        {
                            PayPenalty(fullPayment);
                        }
                        else
                        {
                            PayList(fullPayment);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такой детали нет");
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
                
                if (_car.IsCarRepaired())
                {
                    Console.WriteLine("Проверка машины завершена успешно");
                    isOpen = false;
                }
                else
                {
                    int penalty = _car.GetBrokenPartsPrice();
                    PayPenalty(penalty);
                    isOpen = false;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private bool ReplacePart(int partNumber, out double fullPayment, out bool isPartUnbroken)
        {
            int partIndex = partNumber - 1;
            fullPayment = 0;
            isPartUnbroken = false;

            if (_storages[partIndex].Amount > 0)
            {
                int partPrice = _car.GetPartPrice(partIndex);
                double jobMultuplier = 0.5;
                double workPayment = partPrice * jobMultuplier;
                fullPayment = workPayment + partPrice;
                isPartUnbroken = _car.IsPartUnbroken(partIndex);

                Part part = _storages[partIndex].GetPart();
                _car.ReplacePart(partIndex, part);

                return true;
            }
            else if (_storages[partIndex].Amount == 0)
            {
                Console.WriteLine("У вас закончились детали");

                return false;
            }

            return false;
        }

        private void PayList(double payment)
        {
            Console.WriteLine($"За ремонт детали вы получили {payment} деняк");
            Money += payment;
        }

        private void PayPenalty(double penalty)
        {
            double penaltyMultiplier = 2;
            double fullPenalty = penalty * penaltyMultiplier;
            Console.WriteLine($"Машина осталась неисправна");
            Console.WriteLine($"За неправильный ремонт вы платите штраф в размере двойной цены за деталь(и) - ({fullPenalty})");
            Money -= fullPenalty;
        }

        private void AddParts()
        {
            int partsAmount = Enum.GetValues(typeof(PartsNames)).Length;
            int maxPartsCount = 10;

            for (int i = 0; i < partsAmount; i++)
            {
                int partsCount = _random.Next(maxPartsCount);
                _storages.Add(new Storage((PartsNames)i, true, partsCount));
            }
        }
    }

    class Car
    {
        private static Random _random = new Random();
        private List<Part> _parts = new List<Part>();
        public int PartsAmount => _parts.Count;

        public Car()
        {
            AddParts();
        }

        public void ShowParts()
        {
            int index = 0;

            foreach (var part in _parts)
            {
                index++;
                Console.WriteLine($"{index}. {part.Name}. Состояние {part.GetCondition()}. Стоимость починки: {part.Price}");
            }
        }

        public bool IsCarRepaired()
        {
            return _parts.Count(part => part.IsUnbroken == true) == _parts.Count();
        }

        public void ReplacePart(int partNumber, Part part)
        {
            _parts[partNumber] = part;
        }

        public int GetBrokenPartsPrice()
        {
            int price=0;

            foreach(var part in _parts)
            {
                if (part.IsUnbroken == false)
                {
                    price += part.Price;
                }
            }

            return price;
        }

        public bool IsPartUnbroken(int partNumber)
        {
            return _parts[partNumber].IsUnbroken == true;
        }

        public int GetPartPrice(int partNumber)
        {
            return _parts[partNumber].Price;
        }

        private void AddParts()
        {
            int partsAmount = Enum.GetValues(typeof(PartsNames)).Length;
            int partBrokenCondition = 5;
            int partBroken;
            bool isUnbroken;


            for (int i = 0; i < partsAmount; i++)
            {
                partBroken = _random.Next(0, partBrokenCondition);
                
                if (partBroken == partBrokenCondition-1)
                {
                    isUnbroken = false;
                }
                else
                {
                    isUnbroken = true;
                }
                
                _parts.Add(new Part((PartsNames)i, isUnbroken));
            }
        }
    }

    class Storage
    {
        private Part Part;
        public int Amount { get; private set; }
        
        public Storage(PartsNames name, bool isUnbroken, int amount)
        {
            Part = new Part(name, isUnbroken);
            Amount = amount;
        }

        public void ShowInfo()
        {
            Console.Write($"{Part.Name}, {Amount} - количество\n");
        }

        public Part GetPart()
        {
            Amount--;
            return Part;
        }
    }

    class Part
    {
        private static Random _random = new Random();
        public int Price { get; private set; }
        public PartsNames Name { get; private set; }
        public bool IsUnbroken { get; private set; }

        public Part(PartsNames name, bool isUnbroken)
        {
            int minPrice = 57;
            int maxPrice = 999;
            Price = _random.Next(minPrice, maxPrice);
            Name = name;
            IsUnbroken = isUnbroken;
        }

        public void Replace()
        {
            IsUnbroken = true;
        }

        public string GetCondition()
        {
            if (IsUnbroken == true)
            {
                return "целое";
            }
            else
            {
                return "сломанное";
            }
        }
    }

    enum PartsNames
    {
        Engine,
        Chassis,
        Body,
        Clutch,
        Pendant,
        Brakes
    }
}
