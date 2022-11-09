using Final19.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final19.PLL.Views
{
    public class UserOutcomingMessageView
    {
        public void Show(IEnumerable<Message> outcomingMessages)
        {
            Console.Clear();
            Console.WriteLine("Исходящие сообщения");
            Console.WriteLine();
            if (outcomingMessages.Count() == 0)
            {
                Console.WriteLine("Исходящих сообщений нет");
                Console.WriteLine();
                return;
            }
            outcomingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine("Кому: {0}. Текст сообщения: {1}", message.RecipientEmail, message.Content);
            });

            Console.WriteLine();
        }
    }
}