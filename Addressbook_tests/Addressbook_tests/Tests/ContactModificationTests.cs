using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            NewContactData newContact = new NewContactData("test1111");
            newContact.middlename = "test22222";
            newContact.lastname = "test3333";
            newContact.home = "test4444444";
            newContact.byear = "3000";
            newContact.ayear = "0001";

            app.Contacts.Modify(3, newContact);
        }
    }
}
