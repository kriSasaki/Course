using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "123";
            int maxCounts = 3;
            string inputPassword;
            int counts;
            
            for (counts=0; maxCounts > counts; maxCounts--)
            {
                Console.Write("Попыток осталос: " + maxCounts +
                    "\nВведите пароль: ");
                inputPassword = Console.ReadLine();
                Console.Clear();
                
                if (inputPassword == password)
                {
                    Console.WriteLine("82c02r9y8890yt420-q3u4c803u89-q45");
                    break;
                }
            }
            if (maxCounts == counts)
            {
                Console.WriteLine("Отказано в доступе");
            }
        }
    }
}
