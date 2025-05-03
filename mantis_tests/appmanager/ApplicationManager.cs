using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace mantis_tests
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public ApplicationManager()
        {

            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            baseURL = "http://vm-tisqanwork/mantisbt-2.25.4/";

            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Login = new LoginHelper(this);
            ProjectManagment = new ProjectManagementHelper(this);
            ManagementMenu = new ManagementMenuHelper(this);
            Navigation = new NavigationHelper(this, baseURL);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }

            catch (Exception)
            {
                
            }

        }

        public static ApplicationManager GetInstance()
        {
            
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.GoToPageAuth();
                app.Value = newInstance;

            }

            return app.Value;

        }

       public IWebDriver Driver { get => driver; }
        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public ProjectManagementHelper ProjectManagment { get;  set; }
        public ManagementMenuHelper ManagementMenu { get;  set; }
        public LoginHelper Login { get; set; }
        public NavigationHelper Navigation { get; set; }
    }
}
