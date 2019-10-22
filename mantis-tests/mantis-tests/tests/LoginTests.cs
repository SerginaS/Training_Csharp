using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]

        public void LoginWithInValidCredentials()
        {
            //подготовка
            app.LoginHelper.Logout();

            //действие
            AccountData account = new AccountData("administrator", "123456789");
            app.LoginHelper.Login(account);

            //проверка
            Assert.IsFalse(app.LoginHelper.IsLoggedIn(account));
        }

        [Test]

        public void LoginWithValidCredentials()
        {
            //подготовка
            app.LoginHelper.Logout();

            //действие
            AccountData account = new AccountData("administrator", "root");
            app.LoginHelper.Login(account);

            //проверка
            Assert.IsTrue(app.LoginHelper.IsLoggedIn(account));
        }
    }
}
