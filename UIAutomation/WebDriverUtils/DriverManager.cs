namespace UIAutomation.WebDriverUtils
{
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;
    using System;
    using UIAutomation.Utilities.Logger;
    using System.Configuration;

    public class DriverManager
    {


        /// <summary>
        /// Implicit value in mill seconds
        /// </summary>
        public const int ImplicitWait = 1000;

        private readonly object set;

        /// <summary>
        /// Gets get driverWait instance.
        /// </summary>
        /// <returns>The instance of driver wait <see cref="WebDriverWait"/></returns>
        public WebDriverWait GetWebDriverWait => WebDriverWait;

        /// <summary>
        /// Gets get Driver instance.
        /// </summary>
        /// <returns>The instance of driver <see cref="IWebDriver"/></returns>
        public IWebDriver GetWebDriver => Driver;

        /// <summary>
        /// Set WebDriver
        /// </summary>
        /// <param name="webDriver">New webDriver</param>
        public virtual void SetWebDriver(IWebDriver webDriver)
        {
            Driver = webDriver;
            InitWebDriver(Driver);
        }

        /// <summary>
        /// Gets or sets web driver.
        /// </summary>
        protected static IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets driver wait.
        /// </summary>
        protected static WebDriverWait WebDriverWait { get; set; }

        /// <summary>
        /// Method to close and quit the Driver
        /// </summary>
        public void QuitDriver()
        {
            try
            {
                Driver?.Close();
            }
            catch (WebDriverException e)
            {
                Logging.Debug($"Error when try close the driver{Environment.NewLine}{e.Message}{Environment.NewLine}{e.StackTrace}");
            }
            finally
            {
                Logging.Debug("Quitting current driver...");
                Driver?.Quit();
                WebDriverManager.DisposeWebDriverManager();
            }
        }

        /// <summary>
        /// Method to initialize Driver.
        /// </summary>
        protected void InitWebDriver()
        {
            Logging.Debug($"************ InitWebDriver()");
            var browserName = ConfigurationManager.AppSettings["Browser"];
            Logging.Debug($"************ {browserName}");
            InitWebDriver(DriverFactory.GetDriver(browserName));
        }

        /// <summary>
        /// Method to initialize Driver.
        /// </summary>
        /// <param name="driver">New webDriver</param>
        protected void InitWebDriver(IWebDriver driver)
        {
            var explicitWait = int.Parse(ConfigurationManager.AppSettings["ExplicitWait"]);
            Logging.Debug($"************ {explicitWait}");
            Logging.Debug($"************ Setup Web Driver");
            Driver = driver;
            Logging.Debug($"************ Setup ImplicitWait");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(ImplicitWait);
            Logging.Debug($"************ Setup ExplicitWait");
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(explicitWait));
        }
    }
}
