using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class ProjectCreationTest : AuthTestBase
    {
        
        [Test]
        public void CreateProject()
        {
            
            ProjectData project = new ProjectData()
            {
                ProjectName = GenerateRandomString(5)
            };
                        
            List<ProjectData> oldProjectList = app.ProjectManagment.GetProjectList();

            app.ProjectManagment.CreateProject(project);

            List<ProjectData> newProjectList = app.ProjectManagment.GetProjectList();

            oldProjectList.Add(project);

            oldProjectList.Sort();
            newProjectList.Sort();

            Assert.That(oldProjectList, Is.EqualTo(newProjectList));
        }

        [Test]
        public void CreateProjectApi()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                ProjectName = GenerateRandomString(5)
            };

            List<ProjectData> oldProjectList = app.Api.GetAllProjectsApi(account);

            app.ProjectManagment.CreateProject(project);

            List<ProjectData> newProjectList = app.Api.GetAllProjectsApi(account);

            oldProjectList.Add(project);

            oldProjectList.Sort();
            newProjectList.Sort();

            Assert.That(oldProjectList, Is.EqualTo(newProjectList));
        }
    }
}
