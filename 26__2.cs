using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26__2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Пирожок вкусный. Я люблю пирожки.";
            string[] words = text.Split(' ');

            foreach(var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
