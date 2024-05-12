namespace UIAutomation.WebDriverUtils.WrapperFactory
{
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using System;
    internal class Chrome : IDriver
    {
        private static IWebDriver Driver;

        /// <summary>
        /// Initialize Chrome driver
        /// </summary>
        /// <returns>IWebDriver</returns>
        public IWebDriver InitDriver()
        {
            ChromeOptions options = new ChromeOptions();
            return InitDriver(options);
        }

        public IWebDriver InitDriver(ChromeOptions options)
        {
            string driverPath = AppDomain.CurrentDomain.BaseDirectory;
            InitDefaultValuesForChromeOptions(options);
            Driver = new ChromeDriver(driverPath, options);
            return Driver;
        }

        private void InitDefaultValuesForChromeOptions(ChromeOptions options)
        {
            options.AddArguments("disable-infobars");
            options.AddArguments("--incognito");
            options.AddArguments("--disable-impl-side-painting");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
        }
    }
}
