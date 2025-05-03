using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class ProjectDeleteTest : AuthTestBase
    {
        
        [Test]
        public void DeleteProject()
        {
            if (!app.ProjectManagment.ProjectExists())
            {
                app.ProjectManagment.CreateProject(new ProjectData()
                {
                    ProjectName = GenerateRandomString(10)
                });
            }
            
            List<ProjectData> oldProjectList = app.ProjectManagment.GetProjectList();
            ProjectData toBeRemoved = oldProjectList[0];

            app.ProjectManagment.DeleteProject(toBeRemoved);

            List<ProjectData> newProjectList = app.ProjectManagment.GetProjectList();

            oldProjectList.Remove(toBeRemoved);

            oldProjectList.Sort();
            newProjectList.Sort();

            Assert.That(oldProjectList, Is.EqualTo(newProjectList));
        }
    }
}
