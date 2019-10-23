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
        public static IEnumerable<ProjectData> RandomProjectDataProvider()
        {
            List<ProjectData> contacts = new List<ProjectData>();
            for (int i = 0; i < 1; i++)
            {
                contacts.Add(new ProjectData(GenerateRandomString(30))
                {
                    Description = GenerateRandomString(100)
                });
            }

            return contacts;
        }
        [Test, TestCaseSource("RandomProjectDataProvider")]

        public void ProjectCreationTest(ProjectData project)
        {
            app.Project.Create(project);
        }
    }   
}
