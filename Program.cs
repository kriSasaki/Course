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
            int allPictures = 52;
            int countPerRow = 3;
            int rowCount = allPictures / rowPictures;
            int excessCountPictures = allPictures % rowCount;
            Console.WriteLine("Заполненных рядов " + rowCount);
            Console.WriteLine("Лишних картинок " + excessCount);
        }
    }
}
