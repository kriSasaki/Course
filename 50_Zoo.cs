using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                const string CommandShowAviary = "1";
                const string CommandExit = "2";
                Console.WriteLine($"В зоопарке {zoo.GetAviariesAmount()} вольеров");
                Console.WriteLine($"{CommandShowAviary} - посмотреть вольер" +
                    $"\n{CommandExit} - выйти из зоопарка");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandShowAviary:
                        zoo.ShowAviary();
                        break;
                    case CommandExit:
                        isWorking = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();
        private Random _random = new Random();

        public Zoo()
        {
            int minAmountOfAviaries = 4;
            int maxAmountOfAviaries = 10;
            int amountOfAviaries = _random.Next(minAmountOfAviaries, maxAmountOfAviaries);
            CreateAviaries(amountOfAviaries);
        }

        public void ShowAviary()
        {
            Console.Write("Какой вольер вы хотите посмотреть?: ");
            int index = ReadInt();

            if(index>0 && index <= _aviaries.Count)
            {
                _aviaries[index-1].ShowAnimals();
            }
            else
            {
                Console.Write("Такого вольера нет");
            }

            Console.ReadKey();
        }

        public int GetAviariesAmount()
        {
            return _aviaries.Count();
        }

        private void CreateAviaries(int amountOfAviaries)
        {
            for (int i = 0; i < amountOfAviaries; i++)
            {
                _aviaries.Add(new Aviary());
            }
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

    class Aviary
    {
        private Dictionary<Animal, string> _animals = new Dictionary<Animal, string>();
        private static Random _random = new Random();
        public string AnimalsType { get; private set; }

        public Aviary()
        {
            int minAmountOfAnimals = 2;
            int maxAmountOfAnimals = 10;
            int amountOfAnimals = _random.Next(minAmountOfAnimals, maxAmountOfAnimals);
            CreateAviary(amountOfAnimals);
        }

        public void CreateAviary(int amountOfAnimals)
        {
            TypesOfAnimals type = GetAnimalType();


            for (int i=0; i<amountOfAnimals; i++)
            {
                _animals.Add(new Animal(type), GetVoice(type));
            }
        }

        public void ShowAnimals()
        {
            Console.WriteLine("Животные в вольере: ");

            foreach(var animal in _animals)
            {
                Console.WriteLine($"{animal.Key.Type}, {animal.Key.Gender}, говорит '{animal.Value}'");
            }
        }

        private string GetVoice(TypesOfAnimals type)
        {
            switch (type)
            {
                case TypesOfAnimals.Elephant:
                    return "Слон трубит";
                case TypesOfAnimals.Wolf:
                    return "Воет";
                case TypesOfAnimals.Monkey:
                    return "Кричит";
                case TypesOfAnimals.Giraffe:
                    return "Издает жирафьи звуки";
                case TypesOfAnimals.Fox:
                    return "яп-яп-яап";
                case TypesOfAnimals.Lemur:
                    return "Мяу";
                case TypesOfAnimals.Zebra:
                    return "Голос зебры в точности имитирует звук скользящего по льду камня, брошенного с силой... ";
                case TypesOfAnimals.Rhinoceros:
                    return "Рычит";
            }

            return null;
        }     
        
        private TypesOfAnimals GetAnimalType()
        {
            return ((TypesOfAnimals)_random.Next(Enum.GetValues(typeof(TypesOfAnimals)).Length));
        }
    }

    class Animal
    {
        private static Random _random = new Random();
        public TypesOfAnimals Type { get; private set; }
        public string Gender { get; private set; }

        public Animal(TypesOfAnimals type)
        {
            Type = type;
            Gender = GetGender();
        }

        private string GetGender()
        {
            int maleGender = 0;
            int femaleGender = 2;
            int gender = _random.Next(maleGender, femaleGender);

            if (gender == maleGender)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }
    }    
}

    enum TypesOfAnimals
    {
        Elephant,
        Wolf,
        Monkey,
        Giraffe,
        Fox,
        Lemur,
        Zebra,
        Rhinoceros
    }
