using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToPageAuth()
        {
            driver.Url = baseURL + "login_page.php";
            
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "my_view_page.php")
            {
                return;
            }

            driver.FindElement(By.XPath("//i[@class = 'fa fa-dashboard menu-icon']")).Click();

        }

        public void GoToProgectManagment()
        {
            if (driver.Url == baseURL + "manage_proj_page.php")
            {
                return;
            }

            driver.FindElement(By.XPath("//i[@class = 'fa fa-gears menu-icon']")).Click();
            driver.FindElement(By.XPath("//a[text() = 'Управление проектами']")).Click();
        }



    }
}
