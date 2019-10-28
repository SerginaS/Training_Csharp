using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {

                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.IssueData issue = new Mantis.IssueData();
                issue.summary = issueData.Summary;
                issue.description = issueData.Description;
                issue.category = issueData.Category;
                issue.project = new Mantis.ObjectRef();
                issue.project.id = project.Id;
                client.mc_issue_add(account.Username, account.Password, issue);
        }

        public void CheckProjects(AccountData account)
        {
            List<ProjectData> list = GetProjectList(account);
            if (list.Count == 0)
            {
                ProjectData project = new ProjectData("test")
                {
                    Description = "test"
                };
                CreateProject(account, project);
            }
        }

        public void CreateProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            project.description = projectData.Description;
            client.mc_project_add(account.Username, account.Password, project);
        }
        public void RemoveProject(AccountData account, String id)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_delete (account.Username, account.Password, id);
        }

        public List<ProjectData> GetProjectList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            List<ProjectData> projectList = new List<ProjectData>();
            foreach (Mantis.ProjectData projectData in projects)
            {
                projectList.Add(new ProjectData
                {
                    Name = projectData.name,
                    Id = projectData.id
                });
            }
            return projectList;
        }
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

    }
}
