using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public ContactHelper Create(NewContactData contact)
        {
            AddContacts();
            FillContactForm(contact);
            SubmitNewContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(NewContactData newContact)
        {
            if(IsElementPresent(By.Name("entry")) == false)
            {
                NewContactData contact = new NewContactData("test");
                Create(contact);
            }
            SelectContact();
            EditContacts();
            FillContactForm(newContact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;

        }

        public ContactHelper Remove()
        {
            if (IsElementPresent(By.Name("entry")) == false)
            {
                NewContactData contact = new NewContactData("test");
                Create(contact);
            }
            SelectContact();
            RemoveContact();
            AssertRemovalContacts();                
            return this;
        }

        public ContactHelper AddContacts()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(NewContactData contact)
        {
            Type(By.Name("firstname"), contact.firstname);
            Type(By.Name("middlename"), contact.middlename);
            Type(By.Name("lastname"), contact.lastname);
            Type(By.Name("nickname"), contact.nickname);
            Type(By.Name("title"), contact.title);
            Type(By.Name("company"), contact.company);
            Type(By.Name("address"), contact.company);
            Type(By.Name("home"), contact.home);
            Type(By.Name("mobile"), contact.mobile);
            Type(By.Name("work"), contact.work);
            Type(By.Name("fax"), contact.fax);
            Type(By.Name("email"), contact.email);
            Type(By.Name("email2"), contact.email2);
            Type(By.Name("email3"), contact.email3);
            Type(By.Name("homepage"), contact.homepage);
            SelectElementType(By.Name("bday"), contact.bday, By.XPath("//div[@id='content']/form/select/option[6]"));
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.bday);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select/option[3]")).Click();
            SelectElementType(By.Name("bmonth"), contact.bmonth, By.XPath("//div[@id='content']/form/select[2]/option[5]"));
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.bmonth);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select[2]/option[5]")).Click();
            Type(By.Name("byear"), contact.byear);
            SelectElementType(By.Name("aday"), contact.aday, By.XPath("//div[@id='content']/form/select[3]/option[7]"));
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.aday);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select[3]/option[7]")).Click();
            SelectElementType(By.Name("amonth"), contact.amonth, By.XPath("//div[@id='content']/form/select[4]/option[4]"));
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.amonth);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[4]")).Click();
            Type(By.Name("ayear"), contact.ayear);
            Type(By.Name("address2"), contact.address2);
            Type(By.Name("phone2"), contact.phone2);
            Type(By.Name("notes"), contact.notes);
            return this;
        }


        public ContactHelper SubmitNewContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper SelectContact()
        {
            //driver.FindElement(By.XPath("//tr["+ v +"]/td/input")).Click();
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper AssertRemovalContacts()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper EditContacts()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();;
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
