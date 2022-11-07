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
                const string FilterByName = "1";
                const string FilterByAge = "2";
                const string FilterByDesease = "3";

                hospital.ShowPatients();

                Console.WriteLine($"\n{FilterByName} - отсортировать по имени" +
                    $"\n{FilterByAge} - отсортировать по возрасту" +
                    $"\n{FilterByDesease} - отсортировать по заболеванию\n");
                string command = Console.ReadLine();

                switch (command)
                {
                    case FilterByName:
                        hospital.FilterByName();
                        break;
                    case FilterByAge:
                        hospital.FilterByAge();
                        break;
                    case FilterByDesease:
                        hospital.FilterByDisease();
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
        private List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            _patients.Add(new Patient("Иван", 19, "ишемия"));
            _patients.Add(new Patient("Петр", 37, "СПИД"));
            _patients.Add(new Patient("Кирилл", 12, "диарея"));
            _patients.Add(new Patient("Константин", 20, "диарея"));
            _patients.Add(new Patient("Иван", 12, "туберкулез"));
            _patients.Add(new Patient("Константин", 56, "диарея"));
            _patients.Add(new Patient("Иван", 19, "туберкулез"));
            _patients.Add(new Patient("Кирилл", 37, "СПИД"));
            _patients.Add(new Patient("Константин", 20, "ишемия"));
            _patients.Add(new Patient("Петр", 56, "СПИД"));
        }

        public void ShowPatients()
        {
            foreach (var ill in _patients)
            {
                Console.WriteLine($"{ill.Name}, {ill.Age} лет, болезнь - {ill.Disease}");
            }
        }

        public void FilterByName()
        {
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();

            var sortedPatients = _patients.Where(patient => patient.Name == name).ToList();
            ShowSortedList(sortedPatients);
        }

        public void FilterByAge()
        {
            Console.WriteLine("Введите возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());

            var sortedPatients = _patients.Where(patient => patient.Age == age).ToList();
            ShowSortedList(sortedPatients);
        }

        public void FilterByDisease()
        {
            Console.WriteLine("Введите болезнь: ");
            string disease = Console.ReadLine();

            var sortedPatients = _patients.Where(patient => patient.Disease == disease).ToList();
            ShowSortedList(sortedPatients);
        }

        public void ShowSortedList(List<Patient> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Name}, возраст - {patient.Age}, ,болезнь - {patient.Disease}");
            }
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }
    }
}
