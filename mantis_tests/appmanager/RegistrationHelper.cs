using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {
            
        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://vm-tisqanwork/mantisbt-2.25.4/account_page.php";
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void SubmitRegistration()
        {
            throw new NotImplementedException();
        }

        private void OpenRegistrationForm()
        {
            //driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click(); в версии mantisbt 2.25.4 такого элеиента нет
            driver.FindElement(By.XPath("//a[@class = 'back-to-login-link pull-left']")).Click();
        }
    }
}
