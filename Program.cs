using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string age;
            string zodiac;
            string employment;
            Console.WriteLine("Как вас зовут?");
            name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Сколько вам лет?");
            age = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Какой у вас знак зодиака?");
            zodiac=Convert.ToString(Console.ReadLine());
            Console.WriteLine("Какая у вас профессия?");
            employment = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Вас зовут " + name + ", вам " + age + " лет, вы " + zodiac + " и ваша профессия - " + employment + ".");
        }
    }
}
