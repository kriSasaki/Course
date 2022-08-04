using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _44_Магазин
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            Shop shop = new Shop();
            Player player = new Player(1000);

            while (isActive)
            {
                Console.Clear();
                player.ShowMoney();
                Console.WriteLine("Магазин\n");
                Console.WriteLine("1 - Показать весь ассортимент товаров");
                Console.WriteLine("2 - Купить выбранный товар");
                Console.WriteLine("3 - Посмотреть список купленных товаров");
                Console.WriteLine("4 - Выход\n");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        shop.ShowAssortment();
                        break;
                    case "2":
                        player.ChooseProduct(shop);
                        break;
                    case "3":
                        player.ShowCart();
                        break;
                    case "4":
                        isActive = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет, попробуй ещё раз.\n");
                        break;
                }
                Console.ReadKey();
            }
        }
    }

    class Product
    {
        public string Title { get; private set; }
        public int Price { get; private set; }
        public int Amount { get; private set; }

        public Product(string title, int price, int amount)
        {
            Title = title;
            Price = price;
            Amount = amount;
        }

        public void IncreaseAmount(int amount)
        {
            Amount += amount;
        }

        public void DecreaseAmount(int amount)
        {
            Amount -= amount;
        }
    }

    class Player
    {
        private List<Product> _cart = new List<Product>();
        public int Money { get; private set; }

        public Player(int money)
        {
            Money = money;
        }

        public void ShowMoney()
        {
            Console.SetCursorPosition(0, 28);
            Console.WriteLine($"Осталось денег: {Money}");
            Console.SetCursorPosition(0, 0);
        }

        public void ChooseProduct(Shop shop)
        {
            shop.ShowAssortment();
            Console.Write("Выберете товар: ");
            string title = Console.ReadLine();

            if (shop.TryFindItem(title, out Product product))
            {
                Console.Write("Введите количество: ");
                int amount = ReadInt();

                if(amount > product.Amount)
                {
                    Console.WriteLine("В магазине недостаточно данного товара.");
                }
                else
                {
                    if(TryToBuy(product, amount))
                    {
                        Buy(product, amount);
                        shop.DecreaseAmount(product, amount);
                    }
                    else
                    {
                        Console.WriteLine("Отмена продажи.");
                    }
                }
            }
        }

        public void Buy(Product item, int amount)
        {
            Money -= item.Price * amount;
            AddToCart(item, amount);
            Console.WriteLine("Покупка совершена!");
        }

        public void AddToCart(Product item, int amount)
        {
            bool IsProductFinded = false;
            
            if(_cart.Count == 0)
            {
                _cart.Add(new Product(item.Title, item.Price, amount));
            }
            else
            {
                foreach(var product in _cart)
                {
                    if (product.Title == item.Title)
                    {
                        product.IncreaseAmount(amount);
                        IsProductFinded = true; 
                    }
                }
                if (IsProductFinded == false)
                {
                    _cart.Add(new Product(item.Title, item.Price, amount));
                }
            }
        }

        public bool TryToBuy(Product item, int amount)
        {
            if (Money == 0)
            {
                Console.WriteLine("У вас закончились деньги");
                return false;
            }
            else if (item.Price * amount > Money)
            {
                Console.WriteLine("Недостаточно денег для покупки.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ShowCart()
        {
            foreach(var product in _cart)
            {
                int totalPrice = product.Amount * product.Price;
                Console.WriteLine($"{product.Title}\n\t{product.Amount} * {product.Price} = {totalPrice}");
            }
        }

        private int ReadInt()
        {
            int result;

            while (int.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Неверный ввод числа!");
                Console.WriteLine("Необходимо ввести целое число. Чтобы выйти введите exit.\n");
                Console.Write("Введи целое число: ");
            }

            return result;
        }
    }

    class Shop
    {
        private List<Product> _assortment = new List<Product>();

        public Shop()
        {
            _assortment.Add(new Product("Хлеб", 27, 5));
            _assortment.Add(new Product("Колбаса", 150, 10));
            _assortment.Add(new Product("Молоко", 64, 20));
            _assortment.Add(new Product("Вафли", 97, 3));
            _assortment.Add(new Product("Вода", 40, 150));
        }

        public void ShowAssortment()
        {
            foreach (var product in _assortment)
            {
                Console.WriteLine($"{product.Title}\tЦена: {product.Price}. В наличии: {product.Amount} штук");
            }
            
            Console.WriteLine();
        }

        public bool TryFindItem(string title, out Product findedItem)
        {
            findedItem = null;

            foreach (var product in _assortment)
            {
                if (product.Title.ToLower() == title.ToLower())
                {
                    findedItem = product;
                    
                    return true;
                }
            }
            
            Console.WriteLine("Такого товара нет.");
            
            return false;
        }

        public void DecreaseAmount(Product item, int amount)
        {
            item.DecreaseAmount(amount);
        }
    }
}
