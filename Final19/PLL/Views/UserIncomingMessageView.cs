using Final19.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final19.PLL.Views
{
    public class UserIncomingMessageView
    {
        public void Show(IEnumerable<Message> incomingMessages)
        {
            Console.Clear();
            Console.WriteLine("Входящие сообщения.");
            Console.WriteLine();
            if (incomingMessages.Count() == 0)
            {
                Console.WriteLine("Входящих сообщений нет.");
                Console.WriteLine();
                return;
            }
            incomingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine("От кого: {0}. Текст сообщения: {1}", message.SenderEmail, message.Content);
            });

            Console.WriteLine();
        }
    }
}