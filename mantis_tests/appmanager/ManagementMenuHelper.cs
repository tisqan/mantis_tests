using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
            
        }

        public void InitNewProject()
        {
            Control();
            ProjectManagement();
            InitProject();
        }

        public void Control()
        {
            driver.FindElement(By.XPath("//i[@class = 'fa fa-gears menu-icon']")).Click();
        }

        public void ProjectManagement()
        {
            driver.FindElement(By.XPath("//a[text() = 'Управление проектами']")).Click();
        }

        public void InitProject()
        {
            driver.FindElement(By.XPath("//button[@class = 'btn btn-primary btn-white btn-round']")).Click();
        }


    }
}
