using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите процент жизней: ");
            int health = 50;
            int maxHealth = 10;
            string command = null;
            Console.Clear();

            while (command != "q")
            {
                DrawBar(health, maxHealth, ConsoleColor.Red, 0, '_');
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("1 - ввести процент жизней" +
                    "\nq - выйти");
                command = Console.ReadLine();
                switch (command)
                {
                    case "1":                    
                        Console.Write("Процент: ");
                        int percent = Convert.ToInt32(Console.ReadLine());
                        if(percent > 0 && percent < 100)
                        {
                            health = percent;
                        }
                        else
                        {
                            Console.WriteLine("Неверное значение! Нажмите любую кнопку для продолжения.");
                        }
                        break;
                    case "q":
                        Console.WriteLine("Программа завершена.");
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;

                }
                Console.ReadKey();
                Console.Clear();
            }

        }

        static void DrawBar(int percent, int maxValue, ConsoleColor color, int position, char symbol = ' ')
        {
                ConsoleColor defaultColor = Console.BackgroundColor;
                string bar = "";
                int value = percent * maxValue / 100;

                for (int i = 0; i < value; i++)
                {
                    bar += symbol;
                }
                Console.SetCursorPosition(0, position);
                Console.Write('[');
                Console.BackgroundColor = color;
                Console.Write(bar);
                Console.BackgroundColor = defaultColor;

                bar = "";

                for (int i = value; i < maxValue; i++)
                {
                    bar += symbol;
                }
                Console.Write(bar + ']');
        }
    }
}
