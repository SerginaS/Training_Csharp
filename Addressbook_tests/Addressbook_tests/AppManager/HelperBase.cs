﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
        public void SelectElementType(By locator, string text, By locatorXpath)
        {
            if (text != null)
            {
                new SelectElement(driver.FindElement(locator)).SelectByText(text);
                driver.FindElement(locatorXpath).Click();
            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}