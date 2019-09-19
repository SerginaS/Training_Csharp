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
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                var c2 = cells.ElementAt(1).Text;
                var c3 = cells.ElementAt(2).Text;
                var contact = new ContactData(c3);
                contact.Lastname = c2;
                contacts.Add(contact);
            }
            return contacts;
        }

        public ContactHelper Create(ContactData contact)
        {
            AddContacts();
            FillContactForm(contact);
            SubmitNewContactCreation();
            ReturnToHomePage();
            return this;
        }
       
        public ContactHelper Modify(int p, ContactData newContact)
        {
            SelectContact(p);
            EditContacts();
            FillContactForm(newContact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;

        }

        public ContactHelper Remove(int p)
        {
            SelectContact(p);
            RemoveContact();
            AssertRemovalContacts();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper AddContacts()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Company);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            SelectElementType(By.Name("bday"), contact.Bday, By.XPath("//div[@id='content']/form/select/option[6]"));
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.bday);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select/option[3]")).Click();
            SelectElementType(By.Name("bmonth"), contact.Bmonth, By.XPath("//div[@id='content']/form/select[2]/option[5]"));
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.bmonth);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select[2]/option[5]")).Click();
            Type(By.Name("byear"), contact.Byear);
            SelectElementType(By.Name("aday"), contact.Aday, By.XPath("//div[@id='content']/form/select[3]/option[7]"));
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.aday);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select[3]/option[7]")).Click();
            SelectElementType(By.Name("amonth"), contact.Amonth, By.XPath("//div[@id='content']/form/select[4]/option[4]"));
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.amonth);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[4]")).Click();
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
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
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.CssSelector("#maintable tr[name='entry'] > td:nth-child("+ (index + 1) +")")).Click();
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
        public bool ContactIsPresent()
        {
            return IsElementPresent(By.Name("selected[]"))
                && IsElementPresent(By.Id("maintable"));
        }

        // Проверка на наличие хотя бы одного контакта в списке контактов, если нет - создаем        
        public void CheckContacts()
        {
            if (ContactIsPresent() == false)
            {
                ContactData contact = new ContactData("test");
                Create(contact);
            }
        }
    }
}
