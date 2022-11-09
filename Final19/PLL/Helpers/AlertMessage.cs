using System;
using System.Collections.Generic;
using System.Text;

namespace Final19.PLL.Helpers
{
    public class AlertMessage
    {
        public static void Show(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
    }
}