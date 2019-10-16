using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroupTest()
        {
            //проверка наличия хотя бы одной группы и контакта, если нет - создаем
            app.Groups.CheckGroupList();
            app.Contacts.CheckContacts();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            
            //проверка наличия хотя бы одного контакта в группе, если нет - добавляем
            if (oldList.Count() == 0)
            {
                ContactData contact = ContactData.GetAll().Except(oldList).First();
                app.Contacts.AddContactToGroup(contact, group);
            }
            List<ContactData> oldListContacts = group.GetContacts();
            ContactData contactInGroup = oldListContacts[0];

            app.Contacts.RemoveContactFromGroup(contactInGroup, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contactInGroup);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }        
    }
}
