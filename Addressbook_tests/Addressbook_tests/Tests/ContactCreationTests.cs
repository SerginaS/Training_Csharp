using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            NewContactData contact = new NewContactData("test");
            contact.middlename = "test1";
            contact.lastname = "test2";
            contact.home = "test3";
            contact.byear = "1524";
            contact.ayear = "1999";

            app.Contacts.Create(contact);
        }                            
    }
}
