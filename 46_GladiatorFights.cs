using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _46_GladiatorFights
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            ConsoleKey exitKey = ConsoleKey.Escape;
            bool isActive = true;            

            while (isActive)
            {
                Console.Clear();
                Console.WriteLine("Гладиаторские бои" +
                    "\n"+exitKey+" - Выход" +
                    "\nAny key - Выбрать бойцов\n");
                key = Console.ReadKey(true);
                Arena arena = new Arena();
                Gladiator firstGladiator;
                Gladiator secondGladiator;

                if(key.Key == exitKey)
                {
                    isActive = false;
                }
                else
                {
                    arena.ShowAll();
                    firstGladiator = arena.ChooseGladiator();
                    Console.Clear();
                    arena.ShowAll();
                    secondGladiator = arena.ChooseGladiator();
                    Console.Clear();
                    arena.Fight(firstGladiator, secondGladiator);
                }

                Console.ReadKey(true);
            }
        }
    }

    class Arena
    {
        private List<Gladiator> _gladiators = new List<Gladiator>();

        public Arena()
        {
            _gladiators.Add(new Nord("Иона", 400, 100, 500, 0));
            _gladiators.Add(new Orc("Лоб", 800, 120, 200, 0));
            _gladiators.Add(new Khajiit("Карджо", 389, 83, 400, 0));
            _gladiators.Add(new Argonian("Джари-Ра", 300, 150, 350, 0));
            _gladiators.Add(new Breton("Эола", 291, 70, 200, 20));
            _gladiators.Add(new Altmer("Ондолемар", 200, 50, 100, -10));
        }

        public void ShowAll()
        {
            Console.WriteLine("Список участников:");

            for (int i = 0; i < _gladiators.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _gladiators[i].ShowStats();
                Console.WriteLine("====================================================");
            }

            Console.WriteLine();
        }

        public Gladiator ChooseGladiator()
        {
            Gladiator gladiator;           
            Console.Write("Введите номер гладиатора: ");
            int gladiatorIndex = ReadInt() - 1;

            while (gladiatorIndex > _gladiators.Count || gladiatorIndex < 0)
            {
                Console.WriteLine("Такого гладиатора нет");
                Console.Write("Введите номер гладиатора: ");
                gladiatorIndex = ReadInt() - 1;
            }

            gladiator = _gladiators[gladiatorIndex];
            _gladiators.RemoveAt(gladiatorIndex);
            Console.Write("Выбран боец: ");
            gladiator.ShowStats();
            Console.ReadKey();

            return gladiator;
        }

        public void Fight(Gladiator firstFighter, Gladiator secondFighter)
        {
            firstFighter.ShowStats();
            secondFighter.ShowStats();

            while (firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                if (firstFighter.SkippingTurn > 0)
                {
                    firstFighter.SkipTurn(-1);
                    Console.WriteLine($"{firstFighter.Name} пропускает ход!");
                }
                else
                {
                    firstFighter.Attack(secondFighter);
                }
                
                if (secondFighter.SkippingTurn > 0)
                {
                    secondFighter.SkipTurn(-1);
                    Console.WriteLine($"{secondFighter.Name} пропускает ход!");
                }
                else
                {
                    secondFighter.Attack(firstFighter);
                }
                
                firstFighter.ShowStats();
                secondFighter.ShowStats();
                Console.WriteLine("\n");

            }

            AnnounceWinner(firstFighter, secondFighter);                
        }

        public void AnnounceWinner(Gladiator firstFighter, Gladiator secondFighter)
        {
                if (firstFighter.Health <= 0 && secondFighter.Health <= 0)
                {
                    Console.WriteLine("Ничья, оба погибли");
                }
                else if (firstFighter.Health <= 0)
                {
                    Console.WriteLine($"{secondFighter.Name} победил!");
                }
                else if (secondFighter.Health <= 0)
                {
                    Console.WriteLine($"{firstFighter.Name} победил!");
                }
        }

        private int ReadInt()
        {
            int result;

            while (int.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Неверный ввод числа!\nНеобходимо ввести целое число.");
                Console.Write("Введите целое число: ");
            }

            return result;
        }
    }

    class Gladiator
    {  
        private float _baseDamage;
        private float _baseArmor;
        public string Name { get; protected set; }
        public float Health { get; protected set; }
        public float Damage { get; protected set; }
        public float MagicDamage { get; protected set; }
        public float Armor { get; protected set; }
        public float MagicResistance { get; protected set; }
        public int AbilityRecharging { get; protected set; }
        public int AbilityDuration { get; protected set; }
        public int SkippingTurn { get; protected set; }
        
        public Gladiator(string name, int health, int damage, int armor, int magicResistance)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
            MagicResistance = magicResistance;
            _baseArmor = Armor;
            _baseDamage = Damage;
        }

        public void ShowStats()
        {
            Console.WriteLine($"\"{Name}\"   |{Health}HP   {Damage}DMG   {Armor}ARMOR|" +
                $"\n---------------------------------------------");
        }

        public virtual void Attack(Gladiator enemyFighter)
        {
            enemyFighter.TakeDamage(Damage);

            if (AbilityDuration > 0)
            {
                ReduceDuration();
            }
            else
            {
                NormalizeStats();
            }
        }

        public void SkipTurn(int steps)
        {
            SkippingTurn += steps;
        }
        
        public void ReduceRecharging()
        {
            AbilityRecharging -= 1;
        }

        public virtual void TakeDamage(float enemyDamage)
        {
            if (enemyDamage >= Armor)
            {
                Health -= enemyDamage;
            }
            else
            {
                Health -= enemyDamage / (Armor / enemyDamage);
            }
        }

        public void TakeMagicDamage(float enemyMagicDamage)
        {
            Health -= enemyMagicDamage - (enemyMagicDamage * MagicResistance / 100);
        }

        private void ReduceDuration()
        {
            AbilityDuration -= 1;
        }

        private void NormalizeStats()
        {
            Armor = _baseArmor;
            Damage = _baseDamage;
        }
    }

    class Nord : Gladiator
    {
        private int _abilityMovesRecharge = 4;
        private int _skippingMoves = 2;
        public Nord(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }
        
        public override void Attack(Gladiator enemyFighter)
        {
            if (AbilityRecharging == 0)
            {
                UsePower(enemyFighter);
            }
            else
            {
                ReduceRecharging();
            }

            base.Attack(enemyFighter);
        }

        private void UsePower(Gladiator enemyFighter)
        {
            Console.WriteLine($"\t{Name} использует крик \"Безжалостная сила\"");
            Shout(enemyFighter);
        }

        private void Shout(Gladiator enemyFighter) 
        {
            AbilityRecharging = _abilityMovesRecharge;
            enemyFighter.SkipTurn(_skippingMoves);
        }
    }

    class Orc : Gladiator
    {
        private int _damageMultiplier = 2;
        private int _armorMultiplier = 2;
        private int _abilityMovesRecharge = 3;
        private int _abilityMovesDuration = 1;
        public Orc(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }
        
        public override void Attack(Gladiator enemyFighter)
        {
            if (AbilityRecharging == 0)
            {
                UsePower(enemyFighter);
            }
            else
            {
                ReduceRecharging();
            }

            base.Attack(enemyFighter);
        }

        private void UsePower(Gladiator enemyFighter)
        {
            Console.WriteLine($"\t{Name} использует способность \"Ярость берсерка\"");
            CastBerserkerRage();
        }

        private void CastBerserkerRage()
        {
            Damage *= _damageMultiplier;
            Armor *= _armorMultiplier;
            AbilityRecharging = _abilityMovesRecharge;
            AbilityDuration = _abilityMovesDuration;
        }
    }

    class Khajiit : Gladiator
    {
        private Random _random = new Random();
        private int _abilityMovesDuration = 1;
        private int _dodgeChance = 30;
        public bool CanDodge { get; protected set; }
        public Khajiit(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }
        
        public override void Attack(Gladiator enemyFighter)
        {
            if (AbilityRecharging == 0)
            {
                UsePower();
            }
            else
            {
                ReduceRecharging();
            }

            base.Attack(enemyFighter);
        }

        public override void TakeDamage(float enemyDamage)
        {
            if (CanDodge == true)
            {
                CanDodge = false;
                Console.WriteLine($"{Name} успешно увернулся от атаки");
            }
            else
            {
                base.TakeDamage(enemyDamage);
            }
        }

        private void UsePower()
        {
            Console.WriteLine($"\t{Name} пытается увернуться от атаки");
            Dodge();
        }

        private void Dodge()
        {
            AbilityDuration = _abilityMovesDuration;
            int chance = 100;
            int dodge = _random.Next(0, chance);
            
            if (dodge<= _dodgeChance)
            {
                CanDodge = true;
            }
        }
    }

    class Argonian : Gladiator
    {
        private int _healthRestoration = 150;
        private int _abilityMovesRecharge = 2;
        public Argonian(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }
        
        public override void Attack(Gladiator enemyFighter)
        {
            if (AbilityRecharging == 0)
            {
                UsePower();
            }
            else
            {
                ReduceRecharging();
            }

            base.Attack(enemyFighter);
        }

        private void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Кора Хиста\"");
            CastHistskin();
        }

        private void CastHistskin()
        {
            Health += _healthRestoration;
            AbilityRecharging = _abilityMovesRecharge;
        }
    }

    class Breton : Gladiator
    {
        private int _damageIncrease = 50;
        private int _healthRestoration = 70;
        private int _magicResistanceIncrease = 20;
        private int _abilityMovesRecharge = 5;
        private int _abilityMovesDuration = 3;
        public Breton(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }
        
        public override void Attack(Gladiator enemyFighter)
        {
            if (AbilityRecharging == 0)
            {
                UsePower();
            }
            else
            {
                ReduceRecharging();
            }

            base.Attack(enemyFighter);
        }

        private void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Стормовой плащ\"");
            CastStormCloak();
        }

        private void CastStormCloak()
        {
            Damage += _damageIncrease;
            Health += _healthRestoration;
            MagicResistance += _magicResistanceIncrease;
            AbilityRecharging = _abilityMovesRecharge;
            AbilityDuration = _abilityMovesDuration;
        }
    }

    class Altmer : Gladiator
    {
        private int _magicDamage = 150;
        private int _abilityMovesRecharge = 3;
        public Altmer(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }
        
        public override void Attack(Gladiator enemyFighter)
        {
            if (AbilityRecharging == 0)
            {
                UsePower(enemyFighter);
            }
            else
            {
                ReduceRecharging();
            }

            base.Attack(enemyFighter);
        }

        private void UsePower(Gladiator enemyFighter)
        {
            Console.WriteLine($"\t{Name} использует способность \"Огненный шар\"");
            CastFireball(enemyFighter);
        }

        private void CastFireball(Gladiator enemyFighter)
        {
            MagicDamage = _magicDamage;
            AbilityRecharging = _abilityMovesRecharge;
            enemyFighter.TakeMagicDamage(MagicDamage); 
        }
    }
}   
