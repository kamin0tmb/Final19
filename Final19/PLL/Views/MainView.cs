using Final19.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Final19.PLL.Patterns;

namespace Final19.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            Pattern.Menu(" Добро пожаловать \n\tв социальную сеть!!!",
                "Войти в профиль",
                "Зарегистрироваться"
                );
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.authenticationView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.registrationView.Show();
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