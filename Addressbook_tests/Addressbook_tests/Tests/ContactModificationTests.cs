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
            NewContactData newContact = new NewContactData("test3333333");
            newContact.middlename = "test22222";
            newContact.lastname = "test22222";
            newContact.nickname = null;
            newContact.title = null;
            newContact.company = null;
            newContact.address = null;
            newContact.home = null;
            newContact.mobile = null;
            newContact.work = null;
            newContact.fax = null;
            newContact.email = null;
            newContact.email2 = null;
            newContact.email3 = null;
            newContact.homepage = null;
            newContact.bday = null;
            newContact.bmonth = null;
            newContact.byear = null;
            newContact.aday = null;
            newContact.amonth = null;
            newContact.ayear = null;
            newContact.address2 = null;
            newContact.phone2 = null;
            newContact.notes = null;

            //проверка на наличие хотя бы одного контакта в списке контактов, если нет - создаем
            app.Contacts.CheckContacts();

            app.Contacts.Modify(newContact);
        }
    }
}
