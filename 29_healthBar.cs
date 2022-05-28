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
            int minPercent = 0;
            int maxPercent = 100;
            int health = 0;
            int maxHealth = 10;
            string command = null;
            Console.Clear();

            while (command != "q")
            {
                DrawBar(health, maxHealth, maxPercent, ConsoleColor.Red, 0, '_');
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("1 - ввести процент жизней" +
                    "\nq - выйти");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Check(out health, minPercent, maxPercent);
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

        static void DrawBar(int health, int maxValue, int maxPercent, ConsoleColor color, int position, char symbol = ' ')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";
            int value = health * maxValue / maxPercent;

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

        static void Check(out int health, int minThreshold, int maxThreshold)
        {
            Console.Write("Процент: ");
            health = 0;
            int percent = Convert.ToInt32(Console.ReadLine());
            if (percent > minThreshold && percent < maxThreshold)
            {
                health = percent;
            }
            else
            {
                Console.WriteLine("Неверное значение! Нажмите любую кнопку для продолжения.");
            }
        }
    }
}
