using System;
using System.Collections.Generic;
using System.Text;

namespace Final19.PLL.Patterns
{
    public static class Pattern
    {
        public static void Menu(string nameMenu, params string[] menuItems)
        {
            Console.WriteLine("\t" + nameMenu);
            Console.WriteLine("-------------------------------------------------");
            int ch = 1;
            foreach (var str in menuItems)
            {
                Console.WriteLine("| {0, 2} | {1, -40} |", ch, str);
                ch++;
            }
            Console.WriteLine("-------------------------------------------------");
            Console.Write("Введите цифру пункта меню: ");
        }

        public static void Heading(string user)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|СОЦИАЛЬНАЯ СЕТЬ.                          |");
            Console.WriteLine("|текущий пользователь: {0, -20}|", user);
            Console.WriteLine("--------------------------------------------");
        }
    }
}