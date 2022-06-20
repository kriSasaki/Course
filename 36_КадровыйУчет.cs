using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_КадровыйУчет
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dossier = new Dictionary<string, string>();
            bool isOn = true;

            while (isOn)
            {
                Console.WriteLine("1 - добавить досье" +
                    "\n2 - вывести все досье" +
                    "\n3 - удаления по фамилии" +
                    "\n4 - выход");
                string command = Console.ReadLine();
                Console.Clear();

                switch (command)
                {
                    case "1":
                        AddDossier(dossier);
                        break;
                    case "2":
                        ShowDossier(dossier);
                        break;
                    case "3":
                        DeleteDossier(dossier);
                        break;
                    case "4":
                        isOn = false;
                        break;
                    default:
                        Console.WriteLine("Не правильный ввод.");
                        break;
                }
            }         
        }

        static void AddDossier(Dictionary<string, string> dossier)
        {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            if (dossier.ContainsKey(name) == false)
            {
                dossier.Add(name, position);
            }
            else
            {
                Console.Write("Такое имя уже есть.");
            }
            Console.Clear();
        }

        static void ShowDossier(Dictionary<string, string> dossier)
        {
            foreach(var file in dossier)
            {
                Console.WriteLine(file.Key + " " + file.Value);
            }
            Console.Write("\n");
        }

        static void DeleteDossier(Dictionary<string, string> dossier)
        {
            Console.Write("Напишите имя человека, досье которого хотите удалить:");
            string dossierName = Console.ReadLine();

            if (dossier.ContainsKey(dossierName))
            {
                dossier.Remove(dossierName);
                Console.Write("Успешно удалено.");
            }
            else
            {
                Console.Write("Такого имени нет.");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
