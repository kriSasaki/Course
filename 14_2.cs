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
            int heroHealth = 300;
            int heroDefense = 0;
            int heroManaPoint = 100;
            int heroManaPointGainMax = 5;
            int heroManaPointGain = 0;
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
            int summonDeadManMana = 10;
            int heroDefenseMin = 27;
            int heroDefenseMax = 41;
            bool checkDeadManAlive = false;
            int deadManHealth = 0;
            int deadManHealthMax = 50;
            int deadManDamageMin = 7;
            int deadManDamageMax = 16;
            int counterAttackMax = 100;
            int counterAttackTreshold = 42;
            int bossHealth = 1000;
            int bossBashChance = 0;
            int bossBashChanceThreshhold = 82;
            int bossBashChanceMax = 100;
            int bossClawsHitMin = 37;
            int bossClawsHitMax = 64;
            int bossDamage;
            string choice = null;
            bool checkBossBash = false;

            while (heroHealth > 0 && bossHealth > 0)
            {
                if (bossBashChance <= bossBashChanceThreshhold)
                {
                    checkBossBash = false;
                    Console.WriteLine("\n===========================================" +
                        "\nПеред вами северный черный огромный саблезубый людоед-громозавр, покрытый сотнями, если и не тысячами, шрамами." +
                        "\n===========================================");
                    Console.WriteLine("У босса " + bossHealth + " очков здоровья." +
                        "\nУ вас " + heroHealth + " очков здоровья и " + heroManaPoint + " очков маны");

                    if (checkDeadManAlive == true)
                    {
                        Console.WriteLine("У вашего мертвеца осталось " + deadManHealth + " очков здоровья");
                    }

                    Console.WriteLine("===========================================" +
                    "\nВыберите действие:" +
                    "\n1. Ударить посохом(-" + staffStrikeMin + "-" + staffStrikeMax + " урона)" +
                    "\n2. Атака посохом(-" + staffStrikeMana + " ОМ, " + staffAttackMin + "-" + staffAttackMax + " урона)" +
                    "\n3. Сколдовать огненный шар(-" + castFireBallMana + " ОМ," + castFireBallMin + "-" + castFireBallMax + " урона)" +
                    "\n4. Заклинание исцеления(-" + castHealingMana + " ОМ," + castHealingMin + "-" + castHealingMax + " исцеления)" +
                    "\n5. Призвать мертвецов(-" + summonDeadManMana + " ОМ," + deadManDamageMin + "-" + deadManDamageMax + " урона)" +
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
                                Console.WriteLine("Вы призвали мертвецв.");
                                heroManaPoint -= summonDeadManMana;
                                checkDeadManAlive = true;
                                deadManHealth = deadManHealthMax;

                            break;

                        case "6":

                            Console.WriteLine("Вы сконцентрировались на защите.");
                            heroDefense += random.Next(heroDefenseMin, heroDefenseMax);

                            break;
                    }
                }
                bossDamage = random.Next(bossClawsHitMin, bossClawsHitMax);
                bossBashChance = random.Next(bossBashChanceMax);

                if (checkBossBash == false && bossBashChance <= bossBashChanceThreshhold)
                {
                    heroManaPoint += heroManaPointGain = random.Next(heroManaPointGainMax);
                    Console.WriteLine("У вас восстановилось " + heroManaPointGain + " маны");
                }

                if (bossBashChance > bossBashChanceThreshhold)
                {
                    Console.WriteLine("Вас оглушили!");
                    checkBossBash = true;
                }

                switch (choice)
                {
                    case "5":

                        bossHealth -= random.Next(deadManDamageMin, deadManDamageMax);
                        deadManHealth -= bossDamage;

                        if (deadManHealth <= 0)
                        {
                            checkDeadManAlive = false;
                            Console.WriteLine("Ваш мертвец погиб.");
                        }

                        break;

                    case "6":

                        heroHealth -= bossDamage - heroDefense;
                        heroDefense = 0;
                        int counterAttack = random.Next(counterAttackMax);

                        if ((counterAttack > counterAttackTreshold && bossBashChance <= bossBashChanceThreshhold) && checkBossBash == false)
                        {
                            bossHealth -= bossDamage;
                            Console.WriteLine("Вы контратаковали!");
                        }

                        break;

                    default:
                        heroHealth -= bossDamage;
                        break;
                }
                Console.WriteLine("Босс нанес вам " + bossDamage + " урона.");
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
            {
                Console.WriteLine("Ничья!");
            }
        }
    }
}
