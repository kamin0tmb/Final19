using Final19.BLL.Exceptions;
using Final19.BLL.Models;
using Final19.BLL.Services;
using Final19.PLL.Helpers;
using System;

namespace Final19.PLL.Views
{
    public class MessageSendingView
    {
        UserService userService;
        MessageService messageService;
        public MessageSendingView(MessageService messageService, UserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();
            Console.Write("Введите почтовый адрес получателя: ");
            messageSendingData.RecipientEmail = Console.ReadLine();
            Console.Write("Введите сообщение (не больше 5000 символов): ");
            messageSendingData.Content = Console.ReadLine();
            messageSendingData.SenderId = user.Id;
            try
            {
                messageService.SendMessage(messageSendingData);
                Console.Clear();
                SuccessMessage.Show("Сообщение успешно отправлено!");
                Console.WriteLine();
                user.OutgoingMessages = messageService.GetOutcomingMessagesByUserId(user.Id);
                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                Console.Clear();
                AlertMessage.Show("Пользователь не найден!");
                Console.WriteLine();
            }
            catch (ArgumentNullException)
            {
                Console.Clear();
                AlertMessage.Show("Введите корректное значение!");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.Clear();
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
                Console.WriteLine();
            }
        }
    }
}