using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            int age, tryCount = 5, money, gemCount, gemPrice = 67;
            string login = "amogus", password = "123", inputLogin, inputPassword, choice = null;
            Console.WriteLine("Добро пожаловать в игру!\nДля начала, подтвердите ваш возраст(количество полных лет): ");
            age = Convert.ToInt32(Console.ReadLine());

            if (age < 18)
            {
                Console.WriteLine("Игра доступна только с 18 лет! Возвращайтесь, как подростете.");
            }

            else for (int i = 0; i < tryCount; i++)
                {
                    Console.Write("Введите логин и пароль от вашего аккаунта.\nЛогин: ");
                    inputLogin = Console.ReadLine();
                    Console.Write("Пароль: ");
                    inputPassword = Console.ReadLine();
                    Console.Clear();

                    if ((login == inputLogin) && (password == inputPassword))
                    {
                        while (choice != "4") {
                            Console.WriteLine("Добро пожаловать обратно в таверну, Amogus! Нажмите на цифру для выбора" +
                                "\n=====================" +
                                "\n1. Отправиться путешевствовать" +
                                "\n2. Зайти в магазин кристаллов" +
                                "\n3. Изменить цвет интерфейса" +
                                "\n4. Закрыть игру");
                            choice = Console.ReadLine();
                            Console.Clear();
                            if (choice == "4")
                            {
                                Console.WriteLine("Досвидания! Возвращайтесь скорее.");
                            }
                            else
                            {
                                switch (choice)
                                {
                                    case "1":

                                        Console.WriteLine("Ваш персонаж отправился изучать мир...." +
                                            "\n=====================");

                                        break;
                                    case "2":
                                        Console.WriteLine("Кристаллы по " + gemPrice + " монет");
                                        Console.Write("Сколько у вас золота:");
                                        money = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Сколько кристаллов вам нужно:");
                                        gemCount = Convert.ToInt32(Console.ReadLine());
                                        money -= gemCount * gemPrice;
                                        Console.WriteLine("У вас в сумке " + gemCount + " кристаллов и " + money + " монет" +
                                            "\n=====================");

                                        break;
                                    case "3":
                                        Console.WriteLine("Выберите цвет:" +
                                            "\n1. Красный" +
                                            "\n2. Зеленый" +
                                            "\n3. Синий");
                                        int color =Convert.ToInt32(Console.ReadLine());
                                        switch (color)
                                        {
                                            case 1:
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.Clear();
                                                break;
                                            case 2:
                                                Console.BackgroundColor = ConsoleColor.Green;
                                                Console.Clear();
                                                break;
                                            case 3:
                                                Console.BackgroundColor = ConsoleColor.Blue;
                                                Console.Clear();
                                                break;
                                            default:
                                                Console.WriteLine("Цвет не найден.");
                                                break;
                                        }
                                                break;
                                    default:
                                        continue;
                                        
                                }
                            }

                        }
                    }

                    else
                    {
                        Console.WriteLine("У вас осталось " + (tryCount - i - 1) + " попыток.");
                    }
            }
        }
    }
}
