using System;
using System.Collections.Generic;
using System.Threading;

namespace КонфигураторПассажирскихПоездов
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.Work();
        }
    }

    class Dispatcher
    {
        private List<Train> _trains = new List<Train>();
        private TicketOffice _ticketOffice = new TicketOffice();

        public void Work()
        {
            bool isOpen = true;
            int passengers;

            while (isOpen)
            {
                ShowInfo();
                Route route = new Route();
                Thread.Sleep(1000);
                passengers = _ticketOffice.Sell();
                Thread.Sleep(1000);
                Train train = new Train(passengers, route.Departure, route.Arrival);
                AddTrain(train);
                Thread.Sleep(1000);
                train.Send();
                Console.WriteLine("________________________________________________________________________________________________________________________");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        private void ShowInfo()
        {
            Console.WriteLine("Общая информация:\n");

            if (_trains.Count == 0)
            {
                Console.WriteLine("Поездов нет..");
                Console.WriteLine("Создать?");
                Console.ReadKey(true);
            }
            else
            {
                foreach (var train in _trains)
                {
                    Console.WriteLine($"Поезд №{train.Number} отправлен по маршруту {train.Departure} - {train.Arrival}.\t" +
                        $"Количество вагонов: {train.VansCount}. Количество пассажиров: {train.PassengersCount}");
                }

                Console.WriteLine("\nСоздать поезд?");
                Console.ReadKey(true);
            }

            Console.WriteLine("________________________________________________________________________________________________________________________");
            Console.WriteLine();
        }

        private void AddTrain(Train train)
        {
            _trains.Add(train);
            train.ShowInfo();
        }
    }

    class Train
    {
        private static int _count;
        private List<Van> _vans = new List<Van>();
        private Dictionary<string, int> _vanTypes = new Dictionary<string, int>();

        public int Number { get; private set; }
        public int VansCount { get; private set; }
        public int PassengersCount { get; private set; }
        public string Departure { get; private set; }
        public string Arrival { get; private set; }

        public Train(int passengersCount, string departure, string arrival)
        {
            _vanTypes.Add("Большой", 50);
            _vanTypes.Add("Средний", 36);
            _vanTypes.Add("Маленький", 20);
            _count++;
            Number = _count;
            PassengersCount = passengersCount;
            Departure = departure;
            Arrival = arrival;
            Create();
        }

        private void Create()
        {
            int numberOfPassengers = PassengersCount;

            foreach (var van in _vanTypes)
            {
                while (numberOfPassengers >= van.Value)
                {
                    _vans.Add(new Van(van.Key, van.Value, van.Value));
                    numberOfPassengers -= van.Value;
                }
            }

            if (numberOfPassengers > 0)
            {
                _vans.Add(new Van("Маленький", numberOfPassengers, _vanTypes["Маленький"]));
            }

            VansCount = _vans.Count;
            Console.WriteLine($"Cформирован поезд из {VansCount} вагонов\n");
        }

        public void ShowInfo()
        {
            foreach (var van in _vans)
            {
                Console.WriteLine($"Вагон типа {van.Size} вместительностью {van.MaxPlaces}. Свободных мест: {van.FreePlaces}");
            }

            Console.WriteLine();
        }

        public void Send()
        {
            Console.WriteLine($"Поезд №{Number} отправляется по маршруту {Departure} - {Arrival}.\n");
        }
    }

    class Route
    {
        private Random _random = new Random();
        private string[] _waypoints = { "Воронеж", "Москва", "Санкт-Петербург", "Калининград", "Орёл", "Оренбург", "Иркутск", "Мурманск", "Сочи" };

        public string Departure { get; private set; }
        public string Arrival { get; private set; }

        public Route()
        {
            Create();
        }

        private void Create()
        {
            int departureIndex = 0;
            int arrivalIndex = 0;

            while (departureIndex == arrivalIndex)
            {
                departureIndex = _random.Next(_waypoints.Length);
                arrivalIndex = _random.Next(_waypoints.Length);
            }

            Departure = _waypoints[departureIndex];
            Arrival = _waypoints[arrivalIndex];
            Console.WriteLine($"Создан маршрут {Departure} — {Arrival}\n");
        }
    }

    class Van
    {
        public string Size { get; private set; }
        public int NumberOfPassengers { get; private set; }
        public int MaxPlaces { get; private set; }
        public int FreePlaces { get; private set; }

        public Van(string size, int numberOfPassengers, int maxPlaces)
        {
            Size = size;
            NumberOfPassengers = numberOfPassengers;
            MaxPlaces = maxPlaces;
            FreePlaces = maxPlaces - numberOfPassengers;
        }
    }

    class TicketOffice
    {
        private Random _random = new Random();
        private int _soldMin = 1;
        private int _soldMax = 500;
        private int _count;

        public int Sell()
        {
            _count = _random.Next(_soldMin, _soldMax + 1);
            Console.WriteLine($"Продано {_count} билетов\n");
            return _count;
        }
    }
}
