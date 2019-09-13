using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //проверка на наличие хотя бы одного контакта в списке контактов, если нет - создаем
            app.Contacts.CheckContacts();

            app.Contacts.Remove();
        }

    }
}
