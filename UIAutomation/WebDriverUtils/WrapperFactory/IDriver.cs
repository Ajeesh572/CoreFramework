namespace UIAutomation.WebDriverUtils.WrapperFactory
{
    using OpenQA.Selenium;
    internal interface IDriver
    {
        /// <summary>
        /// Initialize the Selenium web driver.
        /// </summary>
        /// <returns>IWebDriver</returns>
        IWebDriver InitDriver();
    }
}
