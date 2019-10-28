using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]

        public void AddNewIssueTests()
        {
            AccountData account = new AccountData()
            {
                Username = "Administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "1"
            };
            IssueData issue = new IssueData()
            {
                Summary = "some text",
                Description = "some long text",
                Category = "General"
            };
            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
