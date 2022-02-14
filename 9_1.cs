using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            double rubToUsd = 0.013;
            double rubToEur = 0.011;
            double usdToRub = 76.79;
            double usdToEur = 0.88;
            double eurToUsd = 1.14;
            double eurToRub = 87.6;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Введите количество вашей валюты.\nРубли:");
            double rubAmount = Convert.ToSingle(Console.ReadLine());
            Console.Write("Доллары:");
            double usdAmount = Convert.ToSingle(Console.ReadLine());
            Console.Write("Евро:");
            double eurAmount = Convert.ToSingle(Console.ReadLine());
            Console.Clear();
            string currency = null;

            while (currency != "Exit")
            {
                Console.WriteLine("======================\nВаш баланс в рублях: " + rubAmount + "P\nВаш баланс в долларах: " + usdAmount + "$\nВаш баланс в евро: " + eurAmount + "\u20AC\n======================\nВыберите один из вариантов конвертирования(для команды используйте цифры):\n1. Рубли в доллары\n2. Рубли в евро\n3. Доллары в рубли\n4. Доллары в евро\n5. Евро в рубли\n6. Евро в доллары\nExit - завершение программы");

                currency = Console.ReadLine();

                if (currency == "Exit")
                {
                    Console.WriteLine("Программа завершена.");

                }
                else
                {
                    Console.WriteLine("Количество конвертируемой валюты: ");
                    double amountToConvert = Convert.ToSingle(Console.ReadLine());
                    Console.Clear();

                    switch (currency)
                    {
                        case "1":
                            usdAmount += amountToConvert * rubToUsd;
                            rubAmount -= amountToConvert;
                            break;
                        case "2":
                            eurAmount += amountToConvert * rubToEur;
                            rubAmount -= amountToConvert;
                            break;
                        case "3":
                            rubAmount += amountToConvert * usdToRub;
                            usdAmount -= amountToConvert;
                            break;
                        case "4":
                            eurAmount += amountToConvert * usdToEur;
                            usdAmount -= amountToConvert;
                            break;
                        case "5":
                            rubAmount += amountToConvert * eurToRub;
                            eurAmount -= amountToConvert;
                            break;
                        case "6":
                            usdAmount += amountToConvert * eurToUsd;
                            eurAmount -= amountToConvert;
                            break;
                        default:
                            Console.WriteLine("Неизвестная команда.");
                            break;
                    }
                }
            }
        }
    }
}
