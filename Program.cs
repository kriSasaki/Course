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


            Menu();

        }
        static void Menu()
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
                    "\n4- поиск по фамилии" +
                    "\n5 -выход");
                command = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (command)
                {
                    case 1:
                        Console.Write("Введите имя: ");
                        AddDossier(ref fullNames);
                        Console.Write("Введите должность: ");
                        AddDossier(ref positions);
                        break;
                    case 2:
                        ShowDossier(ref fullNames,ref positions);
                        break;
                    case 3:
                        bool deleted = false;
                        Console.WriteLine("Введите номер досье: ");
                        int delete = Convert.ToInt32(Console.ReadLine());
                        DeleteDossier(ref fullNames,ref delete, ref deleted, ref isDossierFound);
                        DeleteDossier(ref positions, ref delete, ref deleted, ref isDossierFound);
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
        static string[] AddDossier(ref string[] array)
        {
            string[] tempArray = new string[array.Length + 1];
            string information = Console.ReadLine();

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[tempArray.Length - 1] = information;
            array = tempArray;
            return array;
        }
        static void ShowDossier(ref string[] fullNames,ref string[] positions)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.WriteLine((i+1)+". "+fullNames[i]+" - "+positions[i]);
            }
        }
        static void DeleteDossier(ref string[] array, ref int delete, ref bool deleted, ref bool isDossierFound)
        {
            
            for(int i = 0; i < array.GetLength(0); i++)
            {
                if (delete == i+1)
                {
                    string[] tempArray = array.Except(new string[] { array[i] }).ToArray();
                    array = tempArray;
                    isDossierFound = true;
                }
            }
            Console.Clear();

            CheckDossier(ref isDossierFound);
        }
        static void SearchDossier(ref string[] fullNames,ref  string[] positions,ref bool isDossierFound)
        {
            Console.WriteLine("Найти имя: ");
            string name = Console.ReadLine();
            
            for(int i=0; i < fullNames.Length; i++)
            {
                if (name == fullNames[i])
                {
                    Console.WriteLine((i + 1) + ". " + fullNames[i] + " - " + positions[i]);
                    isDossierFound = true;
                }
            }

            CheckDossier(ref isDossierFound);
        }
        static void CheckDossier(ref bool isDossierFound)
        {
            if (isDossierFound==false)
            {
                Console.WriteLine("Такого досье нет.");
            }
        }
    }
}
