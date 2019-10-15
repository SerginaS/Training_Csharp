using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            //проверка наличия хотя бы одной группы и контакта, если нет - создаем
            app.Groups.CheckGroupList();
            app.Contacts.CheckContacts();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            IEnumerable<ContactData> contact = ContactData.GetAll().Except(oldList);
            
            //проверка наличия хотя бы одного контакта который не состоит в группе в которую нужно добавить контакт, если нет - создаем новый
            if (contact.Count() == 0)
            {
                ContactData newContact = new ContactData("test");
                app.Contacts.Create(newContact);
            }

            ContactData contactInGroup = ContactData.GetAll().Except(oldList).First();
            app.Contacts.AddContactToGroup(contactInGroup, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contactInGroup);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
