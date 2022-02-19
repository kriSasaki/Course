using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            //герой
            int heroHealth=300;
            int heroDefense = 0;
            int heroManaPoint = 100;
            int heroManaPointGainMax=5;
            int heroManaPointGain=0;
            int staffStrikeMin = 1;
            int staffStrikeMax = 5;
            int staffStrikeMana = 1;
            int staffAttackMin = 4;
            int staffAttackMax = 11;
            int castFireBallMin = 13;
            int castFireBallMax = 21;
            int castFireBallMana = 8;
            int castHealingMin = 17;
            int castHealingMax = 45;
            int castHealingMana = 3;
//            int summonDeadManMin = 15;
//            int summonDeadManMax = 30;
            int summonDeadManMana = 10;
            int heroDefenseMin = 27;
            int heroDefenseMax = 41;
            bool deadManAlive = false;
            int deadManHealth=50;
            int deadManDamageMin = 7;
            int deadManDamageMax = 16;
            int counterAttackMax = 100;
            //босс
            int bossHealth = 1000;
            int bossBashChance = 0;
            int bossBashChanceMax = 100;
            int bossClawsHitMin = 37;
            int bossClawsHitMax = 64;
            int bossDamage;
            string choice = null;
            bool bossBashCheck = false;
            while (heroHealth > 0 && bossHealth > 0)
            {
                if (bossBashChance<83)
                {
                    bossBashCheck = false;
                    Console.WriteLine("\n===========================================" +
                        "\nПеред вами северный черный огромный саблезубый людоед-громозавр." +
                "\n===========================================");
                Console.WriteLine("У босса " + bossHealth + " очков здоровья." +
                    "\nУ вас " + heroHealth + " очков здоровья и " + heroManaPoint + " очков маны");

                    if (deadManAlive == true)
                    {
                    Console.WriteLine("У вашего мертвеца осталось " + deadManHealth + " очков здоровья");
                    }

                    Console.WriteLine("===========================================" +
                    "\nВыберите действие:" +
                    "\n1. Ударить посохом." +
                    "\n2. Атака посохом(-1 ОМ)." +
                    "\n3. Сколдовать огненный шар(-8 ОМ)." +
                    "\n4. Заклинание исцеления(-3 ОМ)." +
                    "\n5. Призвать мертвецов(принимают атаки, наносят немного урока, -10 ОМ)." +
                    "\n6. Сконцентрироваться на защите(шанс контратаковать, снижижение получаемого урона).");
                choice = Console.ReadLine();
                Console.Clear();


                    switch (choice)
                    {
                        case "1":
                            bossHealth -= random.Next(staffStrikeMin, staffStrikeMax);
                            Console.WriteLine("Вы ударили посохом");
                            break;
                        case "2":
                            if ((heroManaPoint - staffStrikeMana) < 0)
                            {
                                Console.WriteLine("Нет маны.");
                                continue;
                            }
                            else
                                Console.WriteLine("Вы сколдовали посохом.");
                                heroManaPoint -= staffStrikeMana;
                                bossHealth -= random.Next(staffAttackMin, staffAttackMax);
                            break;
                        case "3":
                            if ((heroManaPoint - castFireBallMana) < 0)
                            {
                                Console.WriteLine("Нет маны.");
                                continue;
                            }
                            else
                                Console.WriteLine("Вы скастовали огненный шар.");
                                heroManaPoint -= castFireBallMana;
                                bossHealth -= random.Next(castFireBallMin, castFireBallMax);
                            break;
                        case "4":
                            if ((heroManaPoint - castHealingMana) < 0)
                            {
                                Console.WriteLine("Нет маны.");
                                continue;
                            }
                            else
                                heroManaPoint -= castHealingMana;
                                Console.WriteLine("Вы использовали заклинание лечения.");
                                heroHealth += random.Next(castHealingMin, castHealingMax);
                            break;
                        case "5":
                            if ((heroManaPoint - summonDeadManMana) < 0)
                            {
                                Console.WriteLine("Нет маны.");
                                continue;
                            }
                            else
                                Console.WriteLine("Вы призвали мертвецв.");
                                heroManaPoint -= summonDeadManMana;
//                                heroHealth -= random.Next(summonDeadManMin, summonDeadManMax);
                                deadManAlive = true;
                                deadManHealth = 50;
                            break;
                        case "6":
                            Console.WriteLine("Вы сконцентрировались на защите.");
                            heroDefense += random.Next(heroDefenseMin, heroDefenseMax);
                            break;
                    }
                }
                bossDamage = random.Next(bossClawsHitMin, bossClawsHitMax);
                bossBashChance = random.Next(bossBashChanceMax);

                if (bossBashCheck == false && bossBashChance<83)
                {
                    heroManaPoint += heroManaPointGain = random.Next(heroManaPointGainMax);
                    Console.WriteLine("У вас восстановилось " + heroManaPointGain + " маны");
                }
                if (bossBashChance > 82)
                {
                    Console.WriteLine("Вас оглушили!");
                    bossBashCheck = true;
                }

                switch (choice)
                {
                    case "5":
                        bossHealth -= random.Next(deadManDamageMin, deadManDamageMax);
                        deadManHealth -= bossDamage;
                        
                        if (deadManHealth <= 0)
                        {
                            deadManAlive = false;
                            Console.WriteLine("Ваши мертвецы погибли.");
                        }
                        break;
                    case "6":
                        heroHealth -= bossDamage - (bossDamage * heroDefense / 100);
                        heroDefense = 0;
                        int counterAttack = random.Next(counterAttackMax);
                        
                        if ((counterAttack > 43 && bossBashChance < 83) && bossBashCheck==false)
                        {
                            bossHealth -= bossDamage;
                            Console.WriteLine("Вы контратаковали!");
                        }
                        break;
                    default:
                        heroHealth -= bossDamage;
                        break;
                }
            }
            if (bossHealth < 0)
            {
                Console.WriteLine("Вы победили!");
            }
            else if (heroHealth < 0)
            {
                Console.WriteLine("Вы проиграли!");
            }
            else
                Console.WriteLine("Ничья!");
        }
    }
}
