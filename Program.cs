using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine($"{CommandOpenService} - открыть автосервис" +
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
        private List<Storage> _parts = new List<Storage>();
        private Random _random = new Random();
        private double _workPayment;
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

            foreach (var part in _parts)
            {
                index++;
                Console.WriteLine($"{index}. {part._part.Name}, {part.Amount} - количество");
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
                    Console.WriteLine($"\n Выберите деталь для замены или 'stop' для завершения ремонта: ");
                    string command = Console.ReadLine();

                    if (command == CommandStop)
                    {
                        replacing = false;
                    }
                    else if (int.TryParse(command, out int partNumber) && partNumber <= _car.partsAmount && partNumber > 0)
                    {
                        int partIndex = partNumber - 1;
                        int partPrice = GetPartPrice(_car, partIndex);
                        _workPayment = partPrice * 0.5;
                        double fullPayment = _workPayment + partPrice;

                        if (GetPartCondition(_car, partIndex))
                        {
                            PayList(-fullPayment * 2);
                        }
                        else
                        {
                            ReplacePart(partIndex, fullPayment);
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
                    int penalty = GetPenalty()*2;
                    Console.WriteLine($"Машина осталась неисправна");
                    PayList(-penalty);
                    isOpen = false;
                }
            }
        }

        private int GetPenalty()
        {
            return _car.GetBrokenPartsPrice();
        }

        private void ReplacePart(int partNumber, double payment)
        {
            if (_parts[partNumber].Amount > 0)
            {
                _parts[partNumber].ReduceAmount();
                _car.ReplacePart(partNumber);
                PayList(payment);
            }
            else
            {
                Console.WriteLine("У вас закончились детали");
            }

        }

        private int GetPartPrice(Car car, int partNumber)
        {
            return car.GetPartPrice(partNumber);
        }

        private void PayList(double payment)
        {
            if (payment < 0)
            {
                Console.WriteLine($"За неправильный ремонт вы платите штраф в размере двойной цены за деталь(-и)({payment})");
                Money += payment;
            }
            else
            {
                Console.WriteLine($"За ремонт детали вы получили {payment} деняк");
                Money += payment;
            }
        }

        private bool GetPartCondition(Car car, int partNumber)
        {
            return car.GetPartCondition(partNumber);
        }

        private void AddParts()
        {
            int partsAmount = Enum.GetValues(typeof(PartsNames)).Length;
            int maxPartsCount = 10;

            for (int i = 0; i < partsAmount; i++)
            {
                int partsCount = _random.Next(maxPartsCount);
                _parts.Add(new Storage((PartsNames)i, true, partsCount));
            }
        }
    }

    class Car
    {
        private static Random _random = new Random();
        private List<Part> _parts = new List<Part>();
        public int partsAmount => _parts.Count;

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
            if(_parts.Count(part => part.IsUnbroken == true) == _parts.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ReplacePart(int partNumber)
        {
            _parts[partNumber].Replace();
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

        public bool GetPartCondition(int partNumber)
        {
            if (_parts[partNumber].IsUnbroken == true)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public Part _part { get; private set; }
        public int Amount { get; private set; }
        public Storage(PartsNames name, bool isUnbroken, int amount)
        {
            _part = new Part(name, isUnbroken);
            Amount = amount;
        }

        public void ReduceAmount()
        {
            Amount -= 1;
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
        Двигатель,
        Шасси,
        Кузов,
        Сцепление,
        Подвеска,
        Тормоза
    }
}
