using Final19.BLL.Services;

namespace Final19.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void EmailValidShouldThrowAnArgumentNullException()
        {
            var userService = new UserService();
            Assert.Throws<ArgumentNullException>(() => userService.EmailValid("address"));
        }

        [Test]
        public void EmailValidShouldNotThrowAnArgumentNullException()
        {
            var userService = new UserService();
            Assert.DoesNotThrow(() => userService.EmailValid("jm187@yandex.ru"));
        }
    }
}