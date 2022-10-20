using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _47_War
{
    class Program
    {
        static void Main(string[] args)
        {
            FieldOfBattle fieldOfBattle = new FieldOfBattle();
            Console.WriteLine($"Битва между странами {fieldOfBattle._firstCountry.Name} и {fieldOfBattle._secondCountry.Name}");
            fieldOfBattle.BeginBattle();
        }
    }

    class FieldOfBattle
    {
        private Fighter _firstFighter;
        private Fighter _secondFighter;
        public Country _firstCountry { get; protected set; }
        public Country _secondCountry { get; protected set; }

        public FieldOfBattle()
        {
            _firstCountry = new Country("Первая страна"); 
            _secondCountry = new Country("Вторая страна");
        }

        public void BeginBattle()
        {
            _firstCountry.ShowFighters();
            _secondCountry.ShowFighters();
            
            while (_firstCountry.GetPlatoonNumber() > 0 && _secondCountry.GetPlatoonNumber() > 0)
            {
                Fight();
                Console.ReadKey();
            }

            AnnounceWinner(_firstCountry, _secondCountry);
        }

        private void Fight()
        {
            _firstFighter = _firstCountry.SendFighter();
            Console.WriteLine($"Страна {_firstCountry.Name} отправила бойца {_firstFighter.Name}");
            _secondFighter = _secondCountry.SendFighter();
            Console.WriteLine($"Страна {_secondCountry.Name} отправила бойца {_secondFighter.Name}");

            while (_firstFighter.Health>0 && _secondFighter.Health > 0)
            {
                _firstFighter.Attack(_secondFighter);
                _secondFighter.Attack(_firstFighter);
            }

            AnnounceWinner(_firstFighter, _secondFighter);
        }

        private void AnnounceWinner(Fighter firstFighter, Fighter secondFighter)
        {
            if (firstFighter.Health <= 0 && secondFighter.Health <= 0)
            {
                Console.WriteLine("Ничья, оба погибли\n=========================================");
            }
            else if (firstFighter.Health <= 0)
            {
                _firstCountry.RemoveFighter(firstFighter);
                Console.WriteLine($"{secondFighter.Name} победил!\n=========================================");
            }
            else
            {
                _secondCountry.RemoveFighter(secondFighter);
                Console.WriteLine($"{firstFighter.Name} победил!\n=========================================");
            }
        }

        private void AnnounceWinner(Country firstCountry, Country secondCountry)
        {
            if (firstCountry.GetPlatoonNumber() == 0 && secondCountry.GetPlatoonNumber() == 0)
            {
                Console.WriteLine("Ничья, обе страны потерпели поражение");
            }
            else if (firstCountry.GetPlatoonNumber() <= 0)
            {
                Console.WriteLine($"страна {firstCountry.Name} победила!");
            }
            else
            {
                Console.WriteLine($"Страна {secondCountry.Name} победила!");
            }
        }
    }

    class Country
    {
        private Platoon _platoon;
        public string Name { get; protected set; }

        public Country(string name)
        {
            Name = name;
            _platoon = new Platoon();
        }

        public int GetPlatoonNumber()
        {
            int fightersNumber = _platoon.GetFightersNumber();

            return fightersNumber;
        }

        public void ShowFighters()
        {
            Console.WriteLine($"Взвод страны {Name}:");
            _platoon.ShowFighters();
            Console.WriteLine("=========================================");
        }

        public Fighter SendFighter()
        {
            return _platoon.SendFighter();
        }

        public void RemoveFighter(Fighter fighter)
        {
            _platoon.RemoveFighter(fighter);
        }
    }

    class Platoon
    {
        private List<Fighter> _fighters = new List<Fighter>();
        private static Random _random = new Random();

        public Platoon()
        {
            CreatePlatoon(10, _fighters);
        }

        public void ShowFighters()
        {
            foreach(var fighter in _fighters)
            {
                Console.WriteLine($"{fighter.Name}: {fighter.Health} hp. {fighter.Damage} dm.");
            }
        }

        public int GetFightersNumber()
        {
            int fightersNumber = _fighters.Count;

            return fightersNumber;
        }

        public Fighter SendFighter()
        {
            Fighter sentFighter = _fighters[_random.Next(0, _fighters.Count)];

            return sentFighter;
        }

        public void RemoveFighter(Fighter fighter)
        {
            _fighters.Remove(fighter);
        }

        private void CreatePlatoon(int numberOfSoldiers, List<Fighter> soldier)
        {
            for (int i = 0; i < numberOfSoldiers; i++)
            {
                soldier.Add(GetSoldier());
            }
        }

        private Fighter GetSoldier()
        {
            int minimumNumberClassSoldier = 0;
            int maximumNumberClassSoldier = 4;
            int soldierNumber = _random.Next(minimumNumberClassSoldier, maximumNumberClassSoldier);

            if (soldierNumber == 1)
            {
                return new Soldier("Пехотинец", 100, 50);
            }
            else if (soldierNumber == 2)
            {
                return new Healer("Медик", 100, 40);
            }
            else if (soldierNumber == 3)
            {
                return new Tank("Тяжелый пехотинец", 150, 30);
            }
            else
            {
                return new Sniper("Снайпер", 50, 100);
            }
        }
    }

    class Fighter
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public Fighter (int health, int damage, string name)
        {
            Health = health;
            Damage = damage;
            Name = name;
        }

        public virtual void Attack(Fighter enemyFighter)
        {
            enemyFighter.TakeDamage(Damage);
        }

        public virtual void TakeDamage(int damageSoldier)
        {
            Health -= damageSoldier;
        }
    }

    class Soldier : Fighter
    {
        public Soldier(string name, int health, int damage) : base(health, damage, name) { }
    }

    class Healer : Fighter
    {
        private int _healthHeal = 10;

        public Healer(string name, int health, int damage) : base(health, damage, name) { }

        public override void Attack(Fighter enemyFighter)
        {
            UsePower();
            base.Attack(enemyFighter);
        }

        private void UsePower()
        {
            Console.WriteLine($"{Name} принимает медикаменты");
            Health += _healthHeal;
        }
    }

    class Tank : Fighter
    {
        private int _damageReduction = 10;
        
        public Tank(string name, int health, int damage) : base(health, damage, name) { }

        public override void TakeDamage(int damageSoldier)
        {
            Health -= (damageSoldier-_damageReduction);
        }
    }

    class Sniper : Fighter
    {
        private int _damageBoost = 25;
        public Sniper(string name, int health, int damage) : base(health, damage, name) { }

        public override void Attack(Fighter enemyFighter)
        {
            UsePower();
            base.Attack(enemyFighter);
        }

        private void UsePower()
        {
            Console.WriteLine($"{Name} метко прицеливается");
            Damage += _damageBoost;
        }
    }
}
