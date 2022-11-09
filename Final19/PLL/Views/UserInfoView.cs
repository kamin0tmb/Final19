using Final19.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final19.PLL.Views
{
    public class UserInfoView
    {
        public void Show(User user)
        {
            Console.Clear();
            Console.WriteLine("ИНФОРМАЦИЯ О МОЁМ ПРОФИЛЕ.");
            Console.WriteLine();
            Console.WriteLine("Мой идентификатор: {0}", user.Id);
            Console.WriteLine("Меня зовут: {0}", user.FirstName);
            Console.WriteLine("Моя фамилия: {0}", user.LastName);
            Console.WriteLine("Мой пароль: {0}", user.Password);
            Console.WriteLine("Мой почтовый адрес: {0}", user.Email);
            Console.WriteLine("Ссылка на моё фото: {0}", user.Photo);
            Console.WriteLine("Мой любимый фильм: {0}", user.FavoriteMovie);
            Console.WriteLine("Моя любимая книга: {0}", user.FavoriteBook);
            Console.WriteLine();
        }
    }
}