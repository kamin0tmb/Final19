﻿using Final19.BLL.Models;
using Final19.BLL.Services;
using Final19.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final19.PLL.Views
{
    public class UserDataUpdateView
    {
        UserService userService;

        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            Console.Write("Меня зовут: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Моя фамилия: ");
            user.LastName = Console.ReadLine();
            Console.Write("Ссылка на моё фото: ");
            user.Photo = Console.ReadLine();
            Console.Write("Мой любимый фильм: ");
            user.FavoriteMovie = Console.ReadLine();
            Console.Write("Моя любимая книга: ");
            user.FavoriteBook = Console.ReadLine();
            this.userService.Update(user);
            Console.Clear();
            SuccessMessage.Show("Ваш профиль успешно обновлён!");
            Console.WriteLine();
        }
    }
}