using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEEBRAAA
{
    class Program
    {
        static void Main(string[] args)
        {
            int money;
            int gemCount;
            int gemPrice=67;
            Console.WriteLine("Кристаллы по " + gemPrice + " монет");
            Console.Write("Сколько у вас золота:");
            money = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько кристаллов вам нужно:");
            gemCount = Convert.ToInt32(Console.ReadLine());
            money -= gemCount * gemPrice;
            Console.WriteLine("У вас в сумке "+gemCount+" кристаллов и "+money +" монет");
        }
    }
}
