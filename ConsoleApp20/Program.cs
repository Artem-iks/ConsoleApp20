using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    internal class Program
    {
        static int hit(int attack, int defense, int crits)
        {
            bool isCrit = new Random().Next(1, 101) <= crits;
            int finalDmg = (isCrit ? attack * 2 : attack) - defense;
            if (finalDmg < 0) finalDmg = 0;

            if (isCrit) Console.Write("[КРИТ!] ");
            return finalDmg;
        }

        static int Coin()
        {
            return new Random().Next(1, 3) == 1 ? 3 : 1;
            }

            static bool Check1(string text)
        {
            return text.Length > 6 && text.Length < 30;
        }

        static bool Check2(int number)
        {
            return number >= 1920 && number <= 2025;
        }
        static string Player()
        {
            Console.Write("Введіть ваш вибір (камінь, ножиці, папір): ");
            return Console.ReadLine().ToLower().Trim();
        }

        static string Bot()
        {
            int n = new Random().Next(1, 4);
            return n == 1 ? "камінь" : n == 2 ? "ножиці" : "папір";
        }



        static void Main(string[] args)
        {
            //1
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть логін (email): ");
            string login1 = Console.ReadLine();

            if (login1.Length <= 6 || login1.Length >= 30)
            {
                Console.WriteLine("Помилка! Логін має бути від 7 до 29 символів");
                return;
            }

            Console.Write("Введіть пароль: ");
            string pass1 = Console.ReadLine();

            if (pass1.Length <= 6 || pass1.Length >= 30)
            {
                Console.WriteLine("Помилка! Пароль має бути від 7 до 29 символів");
                return;
            }

            Console.Write("Введіть рік народження: ");
            int year = Convert.ToInt32(Console.ReadLine());

            if (year < 1920 || year > 2025)
            {
                Console.WriteLine("Помилка! Рік народження має бути від 1920 до 2025");
                return;
            }

            if (2026 - year < 18)
            {
                Console.WriteLine("Ой! Ви не повнолітні");
            }
            else
            {
                Console.WriteLine("Ви зареєстровані");

                Console.Write("Введіть свій логін: ");
                string login2 = Console.ReadLine();

                Console.Write("Введіть свій пароль: ");
                string pass2 = Console.ReadLine();

                if (login2 == login1 && pass2 == pass1)
                {
                    Console.WriteLine("Вхід успішний");
                }
                else
                {
                    Console.WriteLine("Доступ заборонено");
                }
            }
            //2
            

            string p = Player();

            if (p != "камінь" && p != "ножиці" && p != "папір")
            {
                Console.WriteLine("Помилка! Виберіть: камінь, ножиці або папір.");
                return;
            }

            string b = Bot();
            Console.WriteLine($"Комп'ютер вибрав: {b}");

            if (p == b)
            {
                Console.WriteLine("Нічия!");
            }
            else if ((p == "камінь" && b == "ножиці") || (p == "ножиці" && b == "папір") || (p == "папір" && b == "камінь"))
            {
                Console.WriteLine("Ви перемогли!");
            }
            else
            {
                Console.WriteLine("Комп'ютер переміг!");
            }
            //3
            Console.Write("Ім'я першого гравця: ");
            string p1 = Console.ReadLine();

            Console.Write("Ім'я другого гравця: ");
            string p2 = Console.ReadLine();

            int score1 = 0;
            int score2 = 0;

            for (int i = 1; i <= 5; i++)
            {
                score1 += Coin();
                score2 += Coin();
            }

            Console.WriteLine($"{p1}: {score1} очок");
            Console.WriteLine($"{p2}: {score2} очок");

            if (score1 == score2)
            {
                Console.WriteLine("Нічия!");
            }
            else
            {
                Console.WriteLine($"Переміг {(score1 > score2 ? p1 : p2)}!");
            }
            //4
            int health1 = 200, attack1 = 40, defense1 = 10, crits1 = 5;
            int health2 = 200, attack2 = 25, defense2 = 5, crits2 = 30;

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"\n--- Раунд {i} ---");

                Console.Write("NPC 1 атакує: ");
                int damage1 = hit(attack1, defense2, crits1);
                health2 -= damage1;
                Console.WriteLine($"NPC 2 отримав {damage1} шкоди. Здоров'я NPC 2: {health2}");

                if (health2 <= 0) break;

                Console.Write("NPC 2 атакує: ");
                int damage2 = hit(attack2, defense1, crits2);
                health1 -= damage2;
                Console.WriteLine($"NPC 1 отримав {damage2} шкоди. Здоров'я NPC 1: {health1}");

                if (health1 <= 0) break;
            }

            Console.WriteLine("\n--- Результат бою ---");
            if (health1 > 0 && health2 > 0)
            {
                Console.WriteLine("Нічия!");
            }
            else
            {
                Console.WriteLine(health1 > health2 ? "Переміг NPC 1!" : "Переміг NPC 2!");
            }



        }














    }
    }

