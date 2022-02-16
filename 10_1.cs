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
            int age;
            int tryCount = 5;
            int money = 1234;
            int gemsCount;
            int gemPrice = 67;
            string login = "amogus";
            string password = "123";
            string inputLogin;
            string inputPassword;
            string choice = null;
            Console.WriteLine("Добро пожаловать в игру!\nДля начала, подтвердите ваш возраст(количество полных лет): ");
            age = Convert.ToInt32(Console.ReadLine());

            if (age < 18)
            {
                Console.WriteLine("Игра доступна только с 18 лет! Возвращайтесь, как подростете.");
            }
            else
            {
               while (tryCount-- > 0)
                {
                    Console.Write("Введите логин и пароль от вашего аккаунта.\nЛогин: ");
                    inputLogin = Console.ReadLine();
                    Console.Write("Пароль: ");
                    inputPassword = Console.ReadLine();
                    Console.Clear();

                    if ((login == inputLogin) && (password == inputPassword))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("У вас осталось " + tryCount + " попыток.");
                    }
                }


                if (tryCount < 0)
                {
                    Console.WriteLine("Вы исчерпали все попытки.");
                }


                else
                {
                    while (choice != "4")
                    {
                        Console.WriteLine("Добро пожаловать обратно в таверну, Amogus! Нажмите на цифру для выбора" +
                            "\n=====================" +
                            "\n1. Отправиться путешевствовать" +
                            "\n2. Зайти в магазин кристаллов" +
                            "\n3. Изменить цвет интерфейса" +
                            "\n4. Закрыть игру");
                        choice = Console.ReadLine();
                        Console.Clear();
                        
                            switch (choice)
                            {
                                case "1":
                                Random rand = new Random();
                                int coinsGot = rand.Next(0, 123);
                                money += coinsGot;
                                    Console.WriteLine("Ваш персонаж отправился изучать мир.... и получил "+coinsGot+" монет!" +
                                        "\n Теперь у вас"+money+" деняк)" +
                                        "\n=====================");

                                    break;
                                case "2":
                                    Console.WriteLine("Кристаллы по " + gemPrice + " монет");
                                    Console.WriteLine("У вас " + money + " золота");
                                    Console.Write("Сколько кристаллов вам нужно: ");
                                    gemsCount = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (money >= gemsCount * gemPrice)
                                {
                                    money -= gemsCount * gemPrice;
                                    Console.WriteLine("У вас в сумке " + gemsCount + " кристаллов и " + money + " монет" +
                                        "\n=====================");
                                }
                                else
                                {
                                    Console.WriteLine("У вас не достаточно средств.\n=====================");
                                }

                                    break;
                                case "3":
                                    Console.WriteLine("Выберите цвет:" +
                                        "\n1. Красный" +
                                        "\n2. Зеленый" +
                                        "\n3. Синий");
                                    int color = Convert.ToInt32(Console.ReadLine());
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
                                case "4":
                                    Console.WriteLine("Досвидания! Возвращайтесь скорее.");
                                    break;
                            default:
                                continue;
                            }
                        

                    }
                }


            }
        }

    }
}
