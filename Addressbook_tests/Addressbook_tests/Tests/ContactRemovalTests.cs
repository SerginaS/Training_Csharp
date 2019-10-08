using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);

            //подсчет  и сравнение количества контактов
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);

            //сравнение двух списков после удаления группы
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //проверка, что id  удаленного контакта отсутствует в списке
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

    }
}
