using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48_Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            bool isWork = true;

            while (isWork)
            {
                const string CommandAddFish = "1";
                const string CommandRemoveFish = "2";
                const string CommandSkipYear = "3";
                const string CommandExit = "4";
                aquarium.ShowFishes();
                Console.WriteLine("=================================" +
                    $"\n{CommandAddFish} - добавить рыбку(пропускается 1 год)" +
                    $"\n{CommandRemoveFish} - убрать рыбку(пропускается 1 год)" +
                    $"\n{CommandSkipYear} - пропустить 1 год" +
                    $"\n{CommandExit} - выйти из программы") ;
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandAddFish:
                        aquarium.AddFish();
                        break;
                    case CommandRemoveFish:
                        aquarium.RemoveFish();
                        break;
                    case CommandSkipYear:
                        aquarium.SkipYear();
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
                
                aquarium.RemoveDeadFishes();
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _aquarium;
        private Random _random;
        private int _capacity;

        public Aquarium()
        {
            int minCapacity=5;
            int maxCapacity=10;
            _aquarium = new List<Fish>();
            _random = new Random();
            _capacity = _random.Next(minCapacity, maxCapacity);
        }

        public void ShowFishes()
        {
            Console.WriteLine($"Аквариум. Занято мест {_aquarium.Count} из {_capacity}\n=================================") ;
            
            if (_aquarium.Count > 0)
            {
                int index = 0;

                foreach (var fish in _aquarium)
                {
                    index++;
                    Console.WriteLine($"{index}. Рыбка {fish.Name}, {fish.Age} годиков");
                }
            }
            else
            {
                Console.WriteLine("Рыбок нет");
            }
        }

        public void AddFish()
        {
            if (_aquarium.Count > 0)
            {
                SkipYear();
            }

            if (_aquarium.Count < _capacity)
            {
                int maxAge = 4;
                int minAge = 0;
                Console.Write("Если хотите, назовите рыбку: ");
                string name = Console.ReadLine();

                _aquarium.Add(new Fish(name, _random.Next(minAge, maxAge)));
            }
            else
            {
                Console.WriteLine("Аквариум полон");
            }
        }

        public void RemoveFish()
        {
            Console.Write("Введите номер рыбки: ");
            int index = ReadInt() - 1;

            while(index >= _aquarium.Count || index < 0)
            {
                Console.WriteLine("Такой рыбки нет");
                Console.Write("Введите номер рыбки: ");
                index = ReadInt() - 1;
            }

            Console.WriteLine($"Рыбка под номером {index+1} {_aquarium[index].Name} убрана из аквариума");
            _aquarium.Remove(_aquarium[index]);
            SkipYear();
        }

        public void SkipYear()
        {
            if (_aquarium.Count > 0)
            {
                foreach (var fish in _aquarium)
                {
                    fish.GrowOld();
                }
            }
            else
            {
                Console.WriteLine("Аквариум пуст");
            }
        }

        public void RemoveDeadFishes()
        {
            Console.WriteLine($"Рыб умерло за ход: {_aquarium.Count(fish => fish.IsAlive == false)}.");
            _aquarium.RemoveAll(fish => fish.IsAlive == false);
        }

        private int ReadInt()
        {
            int result;

            while (int.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Неверный ввод числа!\nНеобходимо ввести целое число.");
                Console.Write("Введите целое число: ");
            }

            return result;
        }
    }

    class Fish
    {
        private static Random _random = new Random();
        private int _rateOfAging;
        public int MaxAge { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsAlive => Age < MaxAge;


        public Fish(string name, int age)
        {
            Name = name;
            Age = age;
            int minAge = 10;
            int maxAge = 10;
            MaxAge = _random.Next(minAge, maxAge);
            int minRateOfAging = 1;
            int maxRateOfAging = 3;
            _rateOfAging = _random.Next(minRateOfAging, maxRateOfAging);
        }

        public void GrowOld()
        {
            Age += _rateOfAging;
        }
    }
}
