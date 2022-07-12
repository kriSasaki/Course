using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_КолодаКарт
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            CardDeck cardDeck = new CardDeck();
            bool isActive = true;

            while (isActive)
            {
                Console.Clear();
                Console.WriteLine("Карт в колоде: "+ cardDeck.MaximumCards);
                Console.WriteLine("\nКарты у игрока:");
                player.Show();
                Console.WriteLine("\nВытянуть следующую карту?");
                Console.ReadKey();

                if (cardDeck.CheckCount() == 0)
                {
                    Console.Clear();
                    Console.WriteLine("В колоде закончились карты..");
                    Console.ReadKey();
                }
                else
                {
                    Card card = cardDeck.GiveCard();
                    player.TakeCard(card);
                }
            }
        }
    }

    class Card
    {
        public string Suit { get; private set; }
        public string Rank { get; private set; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }

    class CardDeck
    {
        private Stack<Card> _cards = new Stack<Card>();
        private int _maximumCards;

        public CardDeck()
        {
            Create();
        }

        public int MaximumCards
        {
            get
            {
                return _maximumCards;
            }
            private set
            {
                _maximumCards = value;
            }
        }

        public int CheckCount()
        {
            return _cards.Count;
        }

        public Card GiveCard()
        {
            return _cards.Pop();
        }

        private void Create()
        {
            Random random = new Random();
            string[] suits = { "Пика", "Трефа", "Черви", "Бубна" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
            _maximumCards = 16;

            for(int i=0; i < MaximumCards; i++)
            {
                _cards.Push(new Card(suits[random.Next(suits.Length - 1)], ranks[random.Next(ranks.Length - 1)]));
            }
        }
    }

    class Player
    {
        private List<Card> _chosenCards = new List<Card>();

        public void TakeCard(Card card)
        {
            _chosenCards.Add(card);
        }

        public void Show()
        {
            foreach (var cardItem in _chosenCards)
            {
                Console.WriteLine(cardItem.Suit + " " + cardItem.Rank);
            }
        }
    }
}
