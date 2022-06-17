using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34_ОчередьВМагазине
{
    class Program
    {
        static void Main(string[] args)
        {
            int storeAccount = 0;
            bool isWork = true;
            Queue<int> purchaseAmount = new Queue<int>();

            purchaseAmount.Enqueue(168);
            purchaseAmount.Enqueue(500);
            purchaseAmount.Enqueue(1);
            purchaseAmount.Enqueue(12345);
            purchaseAmount.Enqueue(0);

            while (isWork)
            {
                foreach (var amount in purchaseAmount)
                {
                    Console.WriteLine("Покупатель набрал на сумму " + amount + " рублей.");
                }

                storeAccount += purchaseAmount.Peek();
                Console.WriteLine("\nСейчас в очереди обслуживают покупателя с суммой " + purchaseAmount.Dequeue() + " рублей.\n");
                Console.WriteLine("Счёт магазина стал " + storeAccount + " рублей.\n");
                Console.ReadKey();
                Console.Clear();
                if(purchaseAmount.Count()==0)
                {
                    isWork = false;
                }
            }
            Console.WriteLine("Покупатели закночились.");
        }
    }
}
