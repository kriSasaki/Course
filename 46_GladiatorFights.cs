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
            bool isActive = true;
            ConsoleKeyInfo key;

            while (isActive)
            {
                Console.Clear();
                Console.WriteLine("Гладиаторские бои" +
                    "\nEsc - Выход" +
                    "\nAny key - Выбрать бойцов\n");
                key = Console.ReadKey(true);
                Arena arena = new Arena();
                Gladiator firstGladiator;
                Gladiator secondGladiator;

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        isActive = false;
                        break;
                    default:
                        arena.ShowAll();
                        arena.Choose(out firstGladiator);
                        arena.Choose(out secondGladiator);;
                        arena.Fight(firstGladiator, secondGladiator);
                        break;
                }

                Console.ReadKey(true);
            }
        }
    }

    class Arena
    {
        private List<Gladiator> _warriors = new List<Gladiator>();
        Random random = new Random();

        public Arena()
        {
            _warriors.Add(new Nord("Иона", 400, 100, 500, 0));
            _warriors.Add(new Orc("Лоб", 800, 120, 200, 0));
            _warriors.Add(new Khajiit("Карджо", 389, 83, 400, 0));
            _warriors.Add(new Argonian("Джари-Ра", 300, 150, 350, 0));
            _warriors.Add(new Breton("Эола", 291, 70, 200, 20));
            _warriors.Add(new Altmer("Ондолемар", 200, 50, 100, -10));
        }

        public void ShowAll()
        {
            Console.WriteLine("Список участников:");

            for (int i = 0; i < _warriors.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _warriors[i].ShowStats();
                Console.WriteLine("====================================================");
            }

            Console.WriteLine();
        }

        public void Choose(out Gladiator gladiator)
        {
            int gladiatorIndex = random.Next(_warriors.Count);
            gladiator = _warriors[gladiatorIndex];
            _warriors.RemoveAt(gladiatorIndex);
            Console.Write("Выбран боец: ");
            gladiator.ShowStats();
        }

        public void Fight(Gladiator firstFighter, Gladiator secondFighter)
        {
            float baseDamageFirst = firstFighter.Damage;
            float baseArmorFirst = firstFighter.Armor;
            float baseDamageSecond = secondFighter.Damage;
            float baseArmorSecond = secondFighter.Armor;

            while (firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                Fight(firstFighter, secondFighter, baseDamageFirst, baseArmorFirst);
                Fight(secondFighter, firstFighter, baseDamageSecond, baseArmorSecond);
                firstFighter.ShowStats();
                secondFighter.ShowStats();
                Console.WriteLine("\n");

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
        }

        public void Fight(Gladiator fighter, Gladiator enemyFighter, float baseDamage, float baseArmor)
        {
            if (fighter.SkippingTurn > 0)
            {
                fighter.SkipTurn(-1);
                Console.WriteLine($"{fighter.Name} пропускает ход!");
            }
            else
            {
                if (fighter.AbilityRecharging == 0)
                {
                    fighter.UsePower();

                    if (fighter.SkippingTurn > 0)
                    {
                        enemyFighter.SkipTurn(fighter.SkippingTurn);
                        fighter.SkipTurn(-(fighter.SkippingTurn));
                    }                
                }
                else
                {
                    fighter.ReduceRecharging();
                }

                if (fighter.MagicDamage > 0)
                {
                    enemyFighter.TakeMagicDamage(fighter.MagicDamage);
                }
                
                if (enemyFighter.SuccessfullDodge == true)
                {
                    enemyFighter.TakeDamage(0);
                    Console.WriteLine($"{enemyFighter.Name} успешно увернулся от атаки");
                }
                else
                {
                    enemyFighter.TakeDamage(fighter.Damage);
                }
            }

            if (fighter.AbilityDuration > 0)
            {
                fighter.ReduceDuration();
            }
            else
            {
                fighter.NormalizeStats(fighter, baseDamage, baseArmor);
            }
        }
    }

    class Gladiator
    {
        public string Name { get; protected set; }
        public float Health { get; protected set; }
        public float Damage { get; protected set; }
        public float MagicDamage { get; protected set; }
        public float Armor { get; protected set; }
        public float MagicResistance { get; protected set; }
        public int AbilityRecharging { get; protected set; }
        public int AbilityDuration { get; protected set; }
        public int SkippingTurn { get; protected set; }
        public bool SuccessfullDodge { get; protected set; }

        public Gladiator(string name, int health, int damage, int armor, int magicResistance)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
            MagicResistance = magicResistance;
        }

        public void ShowStats()
        {
            Console.WriteLine($"\"{Name}\"   |{Health}HP   {Damage}DMG   {Armor}ARMOR|" +
                $"\n---------------------------------------------");
        }

        public void SkipTurn(int steps)
        {
            SkippingTurn += steps;
        }

        public void NormalizeStats(Gladiator fighter, float baseDamage, float baseArmor)
        {
            fighter.Armor = baseArmor;
            fighter.Damage = baseDamage;
        }
        
        public void ReduceDuration()
        {
            AbilityDuration -= 1;
        }

        public void ReduceRecharging()
        {
            AbilityRecharging -= 1;
        }

        public void TakeDamage(float enemyDamage)
        {
            if (enemyDamage >= Armor)
            {
                Health -= enemyDamage;
            }
            else 
            {
                Health -= enemyDamage / (Armor / enemyDamage);
            }

            if (SuccessfullDodge == true)
            {
                SuccessfullDodge = false;
            }        
        }

        public void TakeMagicDamage(float enemyMagicDamage)
        {
            Health -= enemyMagicDamage - (enemyMagicDamage * MagicResistance / 100);
        }

        public virtual void UsePower() { }
    }

    class Nord : Gladiator
    {
        public Nord(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует крик \"Безжалостная сила\"");
            Shout();
        }

        private void Shout()
        {
            AbilityRecharging = 4;
            SkippingTurn = 2;
        }
    }

    class Orc : Gladiator
    {
        public Orc(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Ярость берсерка\"");
            BerserkerRage();
        }

        public void BerserkerRage()
        {
            Damage *= 2;
            Armor *= 2;
            AbilityRecharging = 3;
            AbilityDuration = 1;
        }
    }

    class Khajiit : Gladiator
    {
        public Khajiit(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} пытается увернуться от атаки");
            Dodge();
        }

        public void Dodge()
        {
            Random random = new Random();
            AbilityRecharging = 1;
            AbilityDuration = 1;
            int dodgeChance=30;
            int chance = 100;
            int dodge = random.Next(0, chance);
            if (dodge<=dodgeChance)
            {
                SuccessfullDodge = true;
            }
        }
    }

    class Argonian : Gladiator
    {
        public Argonian(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Кора Хиста\"");
            Histskin();
        }

        public void Histskin()
        {
            Health += 150;
            AbilityRecharging = 2;
        }
    }

    class Breton : Gladiator
    {
        public Breton(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Стормовой плащ\"");
            StormCloak();
        }

        public void StormCloak()
        {
            Damage += 50;
            Health += 70;
            MagicResistance += 20;
            AbilityRecharging = 5;
            AbilityDuration = 3;
        }
    }

    class Altmer : Gladiator
    {
        public Altmer(string name, int health, int damage, int armor, int magicResistance) : base(name, health, damage, armor, magicResistance) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Огненный шар\"");
            Fireball();
        }

        public void Fireball()
        {
            MagicDamage = 150;
            AbilityRecharging = 5;
        }
    }
}

    
