using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            string exitProgram = "";
            while (exitProgram != "exit")

            {
                Console.WriteLine("Программа выполняется, пока не поступит команда 'exit' ");
                exitProgram = Console.ReadLine();
                if (exitProgram != "exit")
                {
                    Console.WriteLine("Неизвестная команда");
                }
            }

        }
    }
}
