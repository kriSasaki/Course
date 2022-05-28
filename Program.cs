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
            int health = Convert.ToInt32(Console.ReadLine());
            int maxHealth = 10;
            Console.Clear();

            while (true)
            {
                DrawBar(health, maxHealth, ConsoleColor.Red, 0, '_');
                Console.SetCursorPosition(0, 3);
                Console.Write("Введите процент жизней: ");
                health = Convert.ToInt32(Console.ReadLine());
                Console.ReadKey();
                Console.Clear();
            }

        }

        static void DrawBar(int percent, int maxValue, ConsoleColor color, int position, char symbol = ' ')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";
            int value = percent * maxValue / 100;

            for(int i = 0; i < value; i++)
            {
                bar += symbol;
            }
            Console.SetCursorPosition(0, position);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for(int i = value; i < maxValue; i++)
            {
                bar += symbol;
            }
            Console.Write(bar + ']');
        }
    }
}