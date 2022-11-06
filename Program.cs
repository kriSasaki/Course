using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _54__AnarchyInHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            bool isWork = true;

            while (isWork)
            {
                const string SortByName = "1";
                const string SortByAge = "2";
                const string SortByDesease = "3";

                hospital.ShowSick();

                Console.WriteLine($"\n{SortByName} - отсортировать по имени" +
                    $"\n{SortByAge} - отсортировать по возрасту" +
                    $"\n{SortByDesease} - отсортировать по заболеванию\n");
                string command = Console.ReadLine();

                switch (command)
                {
                    case SortByName:
                        hospital.SortByName();
                        break;
                    case SortByAge:
                        hospital.SortByAge();
                        break;
                    case SortByDesease:
                        hospital.SortByDisease();
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Hospital
    {
        private List<Ill> _patients = new List<Ill>();

        public Hospital()
        {
            _patients.Add(new Ill("Иван", 19, "ишемия"));
            _patients.Add(new Ill("Петр", 37, "СПИД"));
            _patients.Add(new Ill("Кирилл", 12, "диарея"));
            _patients.Add(new Ill("Константин", 20, "диарея"));
            _patients.Add(new Ill("Иван", 12, "туберкулез"));
            _patients.Add(new Ill("Константин", 56, "диарея"));
            _patients.Add(new Ill("Иван", 19, "туберкулез"));
            _patients.Add(new Ill("Кирилл", 37, "СПИД"));
            _patients.Add(new Ill("Константин", 20, "ишемия"));
            _patients.Add(new Ill("Петр", 56, "СПИД"));
        }

        public void ShowSick()
        {
            foreach (var ill in _patients)
            {
                Console.WriteLine($"{ill.Name}, {ill.Age} лет, болезнь - {ill.Disease}");
            }
        }

        public void SortByName()
        {
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();

            var sortedPatients = _patients.Where(patient => patient.Name == name);

            foreach (var patient in sortedPatients)
            {
                Console.WriteLine($"{patient.Name}, возраст - {patient.Age}, ,болезнь - {patient.Disease}");
            }
        }

        public void SortByAge()
        {
            Console.WriteLine("Введите возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());

            var sortedPatients = _patients.Where(patient => patient.Age == age);

            foreach (var patient in sortedPatients)
            {
                Console.WriteLine($"{patient.Name}, возраст - {patient.Age}, ,болезнь - {patient.Disease}");
            }
        }

        public void SortByDisease()
        {
            Console.WriteLine("Введите болезнь: ");
            string disease = Console.ReadLine();

            var sortedPatients = _patients.Where(patient => patient.Disease == disease);

            foreach (var patient in sortedPatients)
            {
                Console.WriteLine($"{patient.Name}, возраст - {patient.Age}, ,болезнь - {patient.Disease}");
            }
        }
    }

    class Ill
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Ill(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }
    }
}
