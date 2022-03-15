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
            string name = "123";
            string number = "qwe";
            Console.WriteLine(name + " " + number);
            string nameless = number;
            number = name;
            name = nameless;
            Console.WriteLine(name + " " + number);
        }
    }
}
