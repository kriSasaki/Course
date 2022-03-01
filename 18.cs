using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];            
            int number;
            int sum = 0;
            string command = null;
            string exit = "exit";
            
            while (command != exit)
            {
                int[] tempArray = new int[array.Length + 1];
                Console.Write("Числа: ");
                foreach (int i in array)
                {
                    Console.Write(i+" ");
                }
                Console.WriteLine(
                    "\n1. Ввести число" +
                    "\n2. Сумма" +
                    "\nexit - выход");
                command=Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "1":
                        Console.Write("Введите  число: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < array.Length; i++)
                        {
                            tempArray[i] = array[i];
                        }
                        tempArray[tempArray.Length-1] = number;
                        array = tempArray;
                        break;
                    case "2":
                        sum = array.Sum();
                        Console.WriteLine("Сумма всех чисел: "+sum);
                        break;
                }
            }
        }
    }
}
