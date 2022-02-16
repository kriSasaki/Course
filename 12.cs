using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            string characters = null;
            int additionalSymbols = 2;
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();   
            Console.Write("Введите символ: ");
            string symbol = Console.ReadLine();
            
            for ( int i=1; i <= (name.Length + additionalSymbols + additionalSymbols); i += 1)
            {
                characters += symbol;
            }
            Console.WriteLine(characters + "" +
                "\n" + symbol+" " + name +" "+ symbol +
                "\n" + characters);
        }
    }
}
