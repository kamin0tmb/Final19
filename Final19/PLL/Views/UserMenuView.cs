using Final19.BLL.Models;
using Final19.BLL.Services;
using Final19.PLL.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final19.PLL.Views
{
    public class UserMenuView
    {
        UserService userService;

        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                Pattern.Heading(user.Email);
                Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
                Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());
                Console.WriteLine();
                Pattern.Menu("Главное меню.",
                    "Просмотреть информацию о моём профиле",
                    "Редактировать мой профиль",
                    "Друзья",
                    "Написать сообщение",
                    "Просмотреть входящие сообщения",
                    "Просмотреть исходящие сообщения",
                    "Выйти из профиля"
                    );
                string keyValue = Console.ReadLine();
                if (keyValue == "7")
                {
                    Console.Clear();
                    break;
                }
                switch (keyValue)
                {
                    case "1":
                        {
                            Program.userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.userDataUpdateView.Show(user);
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            Program.friendsView.Show(user);
                            break;
                        }
                    case "4":
                        {
                            Program.messageSendingView.Show(user);
                            break;
                        }
                    case "5":
                        {

                            Program.userIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }
                    case "6":
                        {
                            Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                            break;
                        }
                    default:
                        {
                            Console.Clear();

                            break;
                        }
                }
            }
        }
    }
}