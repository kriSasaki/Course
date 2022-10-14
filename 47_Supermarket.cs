using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _47_Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();
            bool isWork = true;

            while (isWork)
            {
                const string CommandCreateQueue = "1";
                const string CommandServeBuyers = "2";
                const string CommandExit = "3";
                Console.WriteLine($"В очереди {supermarket.GetQueueAmount()} человек. За сеанс магазин заработал {supermarket.Money} рублей.");
                Console.WriteLine($"\n{CommandCreateQueue} - создать очередь клиентов." +
                    $"\n{CommandServeBuyers} - обслужить очередь клиентов." +
                    $"\n{CommandExit} - выйти.");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandCreateQueue:
                        supermarket.CreateQueue();
                        break;
                    case CommandServeBuyers:
                        supermarket.ServeBuyers();
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }

        }
    }

    class Product
    {
        public string Title { get; private set; }
        public int Price { get; private set; }

        public Product(string title, int price)
        {
            Title = title;
            Price = price;
        }
    }

    class Buyer
    {
        private List<Product> _cart;
        public int Money { get; private set; }

        public Buyer(List<Product> cart, int money)
        {
            _cart = cart;
            Money = money;
        }
        public void BuyProducts(out int sumOfProducts)
        {
            sumOfProducts = GetPriceFullCart();
            ShowProducts();
            Console.WriteLine($"Сумма всей корзины - {sumOfProducts}. У покупателя {Money}");

            if (Money < sumOfProducts)
            {
                RemoveProducts();
                sumOfProducts = GetPriceFullCart();
            }

            Console.WriteLine($"Покупатель заплатил {sumOfProducts}\n");
        }

        private int GetPriceFullCart()
        {
            int sumOfProduct = 0;

            foreach (var product in _cart)
            {
                sumOfProduct += product.Price;
            }

            return sumOfProduct;
        }

        private void ShowProducts()
        {
            Console.WriteLine("Все продукты: ");

            foreach (var product in _cart)
            {
                Console.WriteLine($"{product.Title} - {product.Price} рублей.");
            }
        }


        private void RemoveProducts()
        {
            while (GetPriceFullCart() > Money)
            {
                RemoveProduct();
            }
        }

        private void RemoveProduct()
        {
            Random random = new Random();
            int index = random.Next(0, _cart.Count);
            Console.WriteLine($"Покупатель убрал {_cart[index].Title}");
            _cart.RemoveAt(index);
        }
    }

    class Supermarket
    {
        private Queue<Buyer> _buyers = new Queue<Buyer>();
        private List<Product> _products = new List<Product>();
        private Random _random = new Random();
        private bool _isServingBuyers;
        public int Money { get; private set; }

        public Supermarket()
        {
            _products.Add(new Product("Молоко", 50));
            _products.Add(new Product("Яблоко", 20));
            _products.Add(new Product("Мыло", 100));
            _products.Add(new Product("Хлеб", 30));
            _products.Add(new Product("Яйцо", 60));
            _products.Add(new Product("Булочка", 40));
        }

        public int GetQueueAmount()
        {
            int sumOfBuyers = _buyers.Count;

            return sumOfBuyers;
        }
        public void CreateQueue()
        {
            if (_isServingBuyers == false)
            {
                int minimumCountClient = 2;
                int maximumCountClient = 10;
                int countClient = _random.Next(minimumCountClient, maximumCountClient);

                for (int i = 0; i < countClient; i++)
                {
                    _buyers.Enqueue(CreateBuyer());
                }

                _isServingBuyers = true;
            }
            else
            {
                Console.WriteLine("В магазине уже есть очередь.");
            }
        }
        public void ServeBuyers()
        {
            while (_buyers.Count > 0)
            {
                _buyers.Dequeue().BuyProducts(out int sumOfProducts);
                PutCashInRegister(sumOfProducts);
                Console.ReadKey();
            }

            _isServingBuyers = false;
        }

        private void PutCashInRegister(int money)
        {
            Money += money;
        }

        private Buyer CreateBuyer()
        {
            List<Product> products = new List<Product>();
            int minimumCountProduct = 2;
            int maximumCountProduct = 6;
            int minimumCountMoney = 50;
            int maximumCountMoney = 250;
            int countMoney = _random.Next(minimumCountMoney, maximumCountMoney);
            int countProduct = _random.Next(minimumCountProduct, maximumCountProduct);

            for (int i = 0; i < countProduct; i++)
            {
                products.Add(_products[_random.Next(0, _products.Count - 1)]);
            }

            return new Buyer(products, countMoney);
        }

    }
}
