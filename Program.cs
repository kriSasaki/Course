using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            int countMessages;
            Console.Write("Введите сообщение: ");
            message = Convert.ToString(Console.ReadLine());
            Console.Write("Сколько раз отправить?: ");
            countMessages =Convert.ToInt32(Console.ReadLine());
            for (int i=0; i<countMessages; i++)
            {
                Console.WriteLine(message);
            }
        }
    }
}
