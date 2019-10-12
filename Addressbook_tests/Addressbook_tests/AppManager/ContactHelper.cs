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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigation.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName)
            {
                Lastname = lastName,
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail
            };
        }
        

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigation.OpenHomePage();
            ContactDetails(0);
            string detailsInformation = driver.FindElement(By.CssSelector("div#content")).Text;

            return new ContactData(null)
            {
                DetailsInformation = detailsInformation
            };
        }


        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigation.OpenHomePage();
            EditContacts(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName)
            {
                Lastname = lastName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if(contactCache == null)
            {
                contactCache = new List<ContactData>();
                List<ContactData> contacts = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    var c2 = cells.ElementAt(1).Text;
                    var c3 = cells.ElementAt(2).Text;
                    var contact = new ContactData(c3);
                    contact.Lastname = c2;
                    contact.Id = element.FindElement(By.TagName("input")).GetAttribute("value");
                    contactCache.Add(contact);
                }
            }            
            return new List<ContactData>(contactCache);
        }

        internal int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        internal void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.OpenHomePage();
            SelectGroupFromFilter(group.Name);
            SelectContact(contact.Id);
            RemoveContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void RemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupFromFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
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
            EditContacts(0);
            FillContactForm(newContact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(ContactData contact, ContactData newContact)
        {
            SelectContact(contact.Id);
            EditContacts(contact.Id);
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
        public ContactHelper Remove(ContactData contact)
        {
            SelectContact(contact.Id);
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
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            //Type(By.Name("homepage"), contact.Homepage);
            //SelectElementType(By.Name("bday"), contact.Bday, By.XPath("//div[@id='content']/form/select/option[6]"));
            //SelectElementType(By.Name("bmonth"), contact.Bmonth, By.XPath("//div[@id='content']/form/select[2]/option[5]"));
            //Type(By.Name("byear"), contact.Byear);
            //SelectElementType(By.Name("aday"), contact.Aday, By.XPath("//div[@id='content']/form/select[3]/option[7]"));
            //SelectElementType(By.Name("amonth"), contact.Amonth, By.XPath("//div[@id='content']/form/select[4]/option[4]"));
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }


        public ContactHelper SubmitNewContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
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
        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper AssertRemovalContacts()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper EditContacts(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();

            return this;
        }
        public ContactHelper EditContacts(String id)
        {
            driver.FindElement(By.XPath("//td[@class='center']//a[@href='edit.php?id=" + id + "']")).Click();

            return this;
        }

        public void ContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
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
