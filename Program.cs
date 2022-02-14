using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequence = 0;
            while (sequence< 98) //цикл проверяет условие, то есть пока он не дойдет до небходимого числа, не прекратит выводить числа.
            {
                sequence += 7;
                Console.Write(sequence+" ");
            }

        }
    }
}
