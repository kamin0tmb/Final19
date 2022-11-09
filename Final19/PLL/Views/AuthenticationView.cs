using Final19.BLL.Exceptions;
using Final19.BLL.Models;
using Final19.BLL.Services;
using Final19.PLL.Helpers;
using Final19.PLL.Patterns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final19.PLL.Views
{
    public class AuthenticationView
    {
        UserService userService;
        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();
            Console.Write("Введите почтовый адрес: ");
            authenticationData.Email = Console.ReadLine();
            Console.Write("Введите пароль: ");
            authenticationData.Password = Console.ReadLine();
            try
            {
                var user = this.userService.Authenticate(authenticationData);
                Console.Clear();
                SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
                SuccessMessage.Show("Добро пожаловать " + user.FirstName);
                Console.WriteLine();
                Program.userMenuView.Show(user);
            }
            catch (WrongPasswordException)
            {
                Console.Clear();
                AlertMessage.Show("Пароль не корректный!");
                Console.WriteLine();
            }
            catch (UserNotFoundException)
            {
                Console.Clear();
                AlertMessage.Show("Пользователь не найден!");
                Console.WriteLine();
            }

        }
    }
}