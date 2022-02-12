using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int countQueue;
            int timeReceipt = 13;
            int hour = 60;
            Console.WriteLine("Сколько человек вы видите:");
            countQueue = Convert.ToInt32(Console.ReadLine());
            int totalMinutes = countQueue * timeReceipt;
            int waitingHours = totalMinutes / hour;
            int waitingMinutes = totalMinutes % hour;
            Console.WriteLine("Вам осталось ждать " + waitingHours + " часов и " + waitingMinutes + " минут");
        }
    }
}
