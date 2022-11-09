using Final19.BLL.Exceptions;
using Final19.BLL.Models;
using Final19.BLL.Services;
using Final19.PLL.Helpers;
using Final19.PLL.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final19.PLL.Views
{
    public class FriendsView
    {
        UserService userService;

        public FriendsView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                Pattern.Heading(user.Email);
                FriendsCount(user.Friends.Count());
                Console.WriteLine();
                Pattern.Menu("Друзья.",
                    "Посмотреть список друзей",
                    "Добавить друга",
                    "Удалить друга",
                    "Выйти в главное меню"
                    );
                string keyValue = Console.ReadLine();
                if (keyValue == "4")
                {
                    Console.Clear();
                    break;
                }
                switch (keyValue)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("\tВаши друзья.");
                            Console.WriteLine();
                            foreach (var f in user.Friends)
                            {
                                Console.WriteLine($"{f.FirstName} {f.LastName} {f.Email}");
                            }

                            Console.WriteLine();
                            break;
                        }
                    case "2":
                        {
                            ShowEmailInput();
                            string emailFriend = Console.ReadLine();
                            try
                            {
                                userService.EmailValid(emailFriend);
                                User userFriend = userService.FindByEmail(emailFriend);
                                Friend friend = new Friend()
                                {
                                    User_id = user.Id,
                                    Friend_id = userFriend.Id
                                };
                                userService.AddToFriends(friend);
                                Console.Clear();
                                Console.WriteLine($"Пользователь: {userFriend.FirstName} {userFriend.LastName} " +
                                                  $"успешно добавлен в список друзей.");
                                Console.WriteLine();
                                user.Friends = userService.GetListFrendsByUserId(user.Id);
                            }
                            catch (ArgumentNullException)
                            {
                                Console.Clear();
                                AlertMessage.Show("Введите корректное значение.");
                                Console.WriteLine();
                            }
                            catch (UserNotFoundException)
                            {
                                Console.Clear();
                                AlertMessage.Show("Пользователь не найден!");
                                Console.WriteLine();
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                AlertMessage.Show("Произошла ошибка.");
                                Console.WriteLine();
                            }
                            break;
                        }
                    case "3":
                        {
                            ShowEmailInput();
                            string emailFriend = Console.ReadLine();
                            try
                            {
                                userService.EmailValid(emailFriend);
                                User userFriend = userService.FindByEmail(emailFriend);
                                Friend friend = new Friend()
                                {
                                    Friend_id = userFriend.Id
                                };
                                userService.DeleteFriend(friend);
                                Console.Clear();
                                Console.WriteLine($"Пользователь: {userFriend.FirstName} {userFriend.LastName} " +
                                                  $"удалён из списка друзей.");
                                Console.WriteLine();
                                user.Friends = userService.GetListFrendsByUserId(user.Id);
                            }
                            catch (ArgumentNullException)
                            {
                                Console.Clear();
                                AlertMessage.Show("Введите корректное значение.");
                                Console.WriteLine();
                            }
                            catch (UserNotFoundException)
                            {
                                Console.Clear();
                                AlertMessage.Show("Пользователь не найден!");
                                Console.WriteLine();
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                AlertMessage.Show("Произошла ошибка.");
                                Console.WriteLine();
                            }
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

        /// <summary>
        /// Выводит приглашение для ввода e-mail друга.
        /// </summary>
        private void ShowEmailInput()
        {
            Console.Write("Введите e-mail друга: ");
        }

        /// <summary>
        /// Определяет правильное склонение слова "друг".
        /// </summary>
        /// <param name="friendsCount"></param>
        private void FriendsCount(int friendsCount)
        {
            if (friendsCount == 0)
                Console.WriteLine("У вас пока нет ни одного друга.");
            if (friendsCount == 1)
                Console.WriteLine("У вас 1 друг.");
            if (friendsCount > 1 && friendsCount < 5)
                Console.WriteLine("У вас {0} друга.", friendsCount);
            if (friendsCount > 4 && friendsCount < 21)
                Console.WriteLine("У вас {0} друзей.", friendsCount);
            if (friendsCount > 20)
            {
                var lastDigit = int.Parse(friendsCount.ToString().Substring(friendsCount.ToString().Length - 1));
                if (lastDigit == 1)
                    Console.WriteLine("У вас {0} друг.", friendsCount);
                if (lastDigit > 1 && lastDigit < 5)
                    Console.WriteLine("У вас {0} друга.", friendsCount);
                if (lastDigit > 4 && lastDigit <= 9 && lastDigit == 0)
                    Console.WriteLine("У вас {0} друзей.", friendsCount);
            }
        }
    }
}