using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper (ApplicationManager manager) : base(manager)
        {

        }

        internal void Create(ProjectData project)
        {              
            OpenManageOverviewPage();
            OpenManageProjectPage();
            InitNewProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public void InitNewProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit' and contains(text(), 'Создать новый проект')]")).Click();
        }

        public void OpenManageProjectPage()
        {
            driver.FindElements(By.CssSelector("ul.nav-tabs li"))[2].Click();
        }

        public void OpenManageOverviewPage()
        {
            driver.FindElement(By.XPath("//span[@class='menu-text' and contains(text(), ' Управление ')]")).Click();
        }
        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }
    }
}
