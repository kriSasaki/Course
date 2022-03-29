using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17__2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxNumber = 1000;
            int givenNumber = random.Next(maxNumber);
            int givenDegree = 2;
            int number = 2;
            int degree;
            for (degree=1; number < givenNumber; degree++)
            {
                number *= givenDegree;
            }
            Console.WriteLine(givenNumber +" - "+ degree +" - "+ number);
        }
    }
}
