using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("test3333333");
            newContact.Middlename = "test22222";
            newContact.Lastname = "test22222";
            newContact.Nickname = null;
            newContact.Title = null;
            newContact.Company = null;
            newContact.Address = null;
            newContact.HomePhone = null;
            newContact.MobilePhone = null;
            newContact.WorkPhone = null;
            newContact.Fax = null;
            newContact.Email = null;
            newContact.Email2 = null;
            newContact.Email3 = null;
            newContact.Homepage = null;
            newContact.Bday = null;
            newContact.Bmonth = null;
            newContact.Byear = null;
            newContact.Aday = null;
            newContact.Amonth = null;
            newContact.Ayear = null;
            newContact.Address2 = null;
            newContact.Phone2 = null;
            newContact.Notes = null;

            //проверка на наличие хотя бы одного контакта в списке контактов, если нет - создаем
            app.Contacts.CheckContacts();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData oldData = oldContacts[0];
            app.Contacts.Modify(0, newContact);


            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == newContact.Id)
                {
                    Assert.AreEqual(newContact.Lastname, contact.Lastname);
                    Assert.AreEqual(newContact.Firstname, contact.Firstname);
                }
            }
        }
    }
}
