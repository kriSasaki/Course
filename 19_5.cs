using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        static void ShowMenu()
        {
            bool isOn = true;
            int command;
            string[] fullNames = new string[0];
            string[] positions = new string[0];

            while (isOn)
            {
                
                Console.WriteLine("1 - добавить досье" +
                    "\n2 - вывести все досье" +
                    "\n3 - удалить досье" +
                    "\n4 - поиск по фамилии" +
                    "\n5 - выход");
                command = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (command)
                {
                    case 1:
                        AddDossier(ref fullNames, ref positions);
                        break;
                    case 2:
                        ShowDossier(fullNames, positions);
                        break;
                    case 3:
                        DeleteDossier(ref fullNames, ref positions);
                        break;
                    case 4:
                        SearchDossier(fullNames, positions);
                        break;
                    case 5:
                        isOn = false;
                        break;
                }
            }
        }

        static void AddDossier(ref string[] array1, ref string[] array2)
        {
            Console.WriteLine("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            string position = Console.ReadLine();

            AddDossier(ref array1, name);
            AddDossier(ref array2, position);
        }

        static void DeleteDossier(ref string[] array1, ref string[] array2)
        {
            Console.WriteLine("Введите номер досье: ");
            int delete = Convert.ToInt32(Console.ReadLine());

            DeleteDossier(ref array1, delete);
            DeleteDossier(ref array2, delete);
        }
        
        static void AddDossier(ref string[] array, string information)
        {
            string[] tempArray1 = new string[array.Length + 1];
            

            for (int i = 0; i < array.Length; i++)
            {
                tempArray1[i] = array[i];
            }
            tempArray1[tempArray1.Length - 1] = information;
            array = tempArray1;
        }

        static void ShowDossier(string[] fullNames, string[] positions)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + fullNames[i] + " - " + positions[i]);
            }
        }

        static void DeleteDossier(ref string[] array, int delete)
        {
            bool isDossierFound = false;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (delete == i + 1)
                {
                    string[] tempArray = array.Except(new string[] { array[i] }).ToArray();
                    array = tempArray;
                    isDossierFound = true;
                }
            }
            Console.Clear();

            if (!isDossierFound)
            {
                CheckDossier(isDossierFound);
            }
        }

        static void SearchDossier(string[] fullNames, string[] positions)
        {
            bool isDossierFound = false;
            Console.WriteLine("Найти имя: ");
            string name = Console.ReadLine();

            for (int i = 0; i < fullNames.Length; i++)
            {
                if (name == fullNames[i])
                {
                    Console.WriteLine((i + 1) + ". " + fullNames[i] + " - " + positions[i]);
                    isDossierFound = true;
                }
            }
            if (!isDossierFound)
            {
                CheckDossier(isDossierFound);
            }
        }

        static bool CheckDossier(bool isDossierFound)
        {
            Console.WriteLine("Такого досье нет.");

            return isDossierFound;
        }
    }
}
