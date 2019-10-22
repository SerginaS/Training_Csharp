using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]

        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData("Test")
            {
                Description = "Test1"
            };

            app.Project.Create(project);
        }
    }   
}
