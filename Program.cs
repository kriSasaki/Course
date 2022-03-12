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
                bool isDossierFound = false;
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
                        Resize(ref fullNames, ref positions);
                        break;
                    case 2:
                        ShowDossier(ref fullNames, ref positions);
                        break;
                    case 3:
                        Resize(ref fullNames, ref positions, isDossierFound);
                        break;
                    case 4:
                        SearchDossier(ref fullNames, ref positions, ref isDossierFound);
                        break;
                    case 5:
                        isOn = false;
                        break;
                }
            }
        }

        static void  Resize(ref string[] array1, ref string[] array2)
        {
            Console.WriteLine("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            string position = Console.ReadLine();

            AddDossier(ref array1, name);
            AddDossier(ref array2, position);
        }

        static void Resize(ref string[] array1, ref string[] array2, bool isDossierFound)
        {
            Console.WriteLine("Введите номер досье: ");
            int delete = Convert.ToInt32(Console.ReadLine());

            DeleteDossier(ref array1, isDossierFound, delete);
            DeleteDossier(ref array2, isDossierFound, delete);
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

        static void ShowDossier(ref string[] fullNames, ref string[] positions)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + fullNames[i] + " - " + positions[i]);
            }
        }

        static void DeleteDossier(ref string[] array, bool isDossierFound, int delete)
        {
            

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

            CheckDossier(isDossierFound);
        }

        static void SearchDossier(ref string[] fullNames, ref string[] positions, ref bool isDossierFound)
        {
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

            CheckDossier(isDossierFound);
        }

        static bool CheckDossier(bool isDossierFound)
        {
            if (isDossierFound == false)
            {
                Console.WriteLine("Такого досье нет.");
            }
            return isDossierFound;
        }
    }
}