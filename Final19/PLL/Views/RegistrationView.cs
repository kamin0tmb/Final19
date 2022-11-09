using Final19.BLL.Models;
using Final19.BLL.Services;
using Final19.PLL.Helpers;
using System;

namespace Final19.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;

        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();
            Console.WriteLine();
            Console.WriteLine("Для создания нового профиля введите ваши данные. ");
            Console.Write("Имя: ");
            userRegistrationData.FirstName = Console.ReadLine();
            Console.Write("Фамилия: ");
            userRegistrationData.LastName = Console.ReadLine();
            Console.Write("Пароль (не менее 8 символов): ");
            userRegistrationData.Password = Console.ReadLine();
            Console.Write("Почтовый адрес: ");
            userRegistrationData.Email = Console.ReadLine();
            try
            {
                this.userService.Register(userRegistrationData);
                Console.Clear();
                SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
                Console.WriteLine();
            }
            catch (ArgumentNullException)
            {
                Console.Clear();
                AlertMessage.Show("Введите корректное значение.");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.Clear();
                AlertMessage.Show("Произошла ошибка при регистрации.");
                Console.WriteLine();
            }
        }
    }
}