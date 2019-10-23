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

        public void Remove(int v)
        {
            OpenManageOverviewPage();
            OpenManageProjectPage();
            SelectProject(0);
            RemoveProject();
            AssertRemovalProject();
        }
        public void Create(ProjectData project)
        {
            OpenManageOverviewPage();
            OpenManageProjectPage();
            InitNewProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
        }

        public void AssertRemovalProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void SelectProject(int index)
        {
            var cell = driver.FindElements(By.CssSelector("div.table-responsive"))[0].FindElement(By.TagName("tbody"));
            var cell1 = cell.FindElements(By.TagName("tr"))[index];
            cell1.FindElements(By.TagName("td"))[0].FindElement(By.TagName("a")).Click();
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

        public void CheckProjects()
        {
            OpenManageOverviewPage();
            OpenManageProjectPage();
            var cell = driver.FindElements(By.CssSelector("div.table-responsive"))[0].FindElement(By.TagName("tbody"));
            int count = cell.FindElements(By.TagName("tr")).Count();
            if (count == 0)
            {
                ProjectData project = new ProjectData("test")
                {
                    Description = "test"
                };
                Create(project);
            }
        }
    }
}
