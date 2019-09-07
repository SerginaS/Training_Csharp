﻿using System;
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
            newContact.lastname = null;
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

            app.Contacts.Modify(3, newContact);
        }
    }
}
