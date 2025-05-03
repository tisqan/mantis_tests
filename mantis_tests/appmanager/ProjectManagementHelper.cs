using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void CreateProject(ProjectData project)
        {
            manager.Navigation.GoToProgectManagment();
            manager.ManagementMenu.InitProject();
            FillProjectName(project);
            AddProject();

        }

        public void DeleteProject(ProjectData project)
        {
            manager.Navigation.GoToProgectManagment();
            OpenProject(project);
            Delete();
            ConfirmDelete();
        }

        public void OpenProject(ProjectData project)
        {
            driver.FindElement(By.XPath($"//tr/td/a[text() = '{project.ProjectName}']")).Click();
        }

        public void Delete()
        {
            driver.FindElement(By.XPath($"//input[@class = 'btn btn-primary btn-sm btn-white btn-round']")).Click();
        }

        public void ConfirmDelete()
        {
            driver.FindElement(By.XPath($"//input[@type = 'submit']")).Click();
        }

        public void FillProjectName(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.ProjectName);

        }

        public void AddProject()
        {
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();

        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigation.GoToProgectManagment();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr/td/a"));

            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData()
                {
                    ProjectName = element.Text
                });
            }

            return projects;

        }

        public bool ProjectExists()
        {
            manager.Navigation.GoToProgectManagment();
            return IsElementPresent(By.XPath("//tr[./td/a]"));
        }

    }
}
