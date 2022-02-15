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
            int limit = 98;
            int step = 7;

            for (int sequence = 0; sequence < limit; ) // число итераций известно. While бесконечный цикл. For конечен. Я не понимаю((((
            {
                sequence += step;
                Console.Write(sequence + " ");
            }
        }
    }
}
