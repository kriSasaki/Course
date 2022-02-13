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
            double rubToUsd = 0.013, rubToEur = 0.011, UsdToRub= 76.79, UsdToEur=0.88, EurToUsd=1.14, EurToRub=87.6;
            Console.WriteLine("Выберите валюту для конвертирования: рубль, доллар, евро");
            string currency =Convert.ToString(Console.ReadLine());

            switch (currency)
            {
                case "рубль":

                    Console.WriteLine("Введите количество рублей: ");
                    double amountOfRub = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Конвертировать в доллары или евро: ");
                    string convToUsdOrEur = Console.ReadLine();

                    if (convToUsdOrEur == "доллары")
                    {
                        Console.WriteLine("У вас " + (amountOfRub * rubToUsd) + " долларов");
                    }    

                    else if (convToUsdOrEur == "евро")
                    {
                        Console.WriteLine("У вас " + (amountOfRub * rubToEur) + " евро");
                    }

                    else
                    {
                        Console.WriteLine("Ошбика конвертирования!");
                    }
                    break;

                case "доллар":

                    Console.WriteLine("Введите количество долларов: ");
                    double amountOfUsd = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Конвертировать в рубли или евро: ");
                    string convToRubOrEur = Console.ReadLine();

                    if (convToRubOrEur == "рубли")
                    {
                        Console.WriteLine("У вас " + (amountOfUsd * UsdToRub) + " рублей");
                    }

                    else if (convToRubOrEur == "евро")
                    {
                        Console.WriteLine("У вас " + (amountOfUsd * UsdToEur) + " евро");
                    }

                    else
                    {
                        Console.WriteLine("Ошбика конвертирования!");
                    }
                    break;

                case "евро":

                    Console.WriteLine("Введите количество евро: ");
                    double amountOfEur = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Конвертировать в рубли или доллары: ");
                    string convToRubOrUsd = Console.ReadLine();

                    if (convToRubOrUsd == "рубли")
                    {
                        Console.WriteLine("У вас " + (amountOfEur * EurToRub) + " рублей");
                    }

                    else if (convToRubOrUsd == "доллары")
                    {
                        Console.WriteLine("У вас " + (amountOfEur * EurToUsd) + " долларов");
                    }

                    else
                    {
                        Console.WriteLine("Ошбика конвертирования!");
                    }
                    break;
            }
        }
    }
}
