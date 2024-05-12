namespace UIAutomation.WebDriverUtils
{
    using OpenQA.Selenium;
    using UIAutomation.WebDriverUtils.WrapperFactory;
    public class DriverFactory
    {
        private const string Chrome = "Chrome";

        /// <summary>
        /// Get the correct instance of IWebDriver according the name given by parameter.
        /// </summary>
        /// <param name="browser">The browser or mobile os.</param>
        /// <returns><see cref="IWebDriver"/>The instance of web driver.</returns>
        public static IWebDriver GetDriver(string browser)
        {
            switch (browser)
            {
                case Chrome: return new Chrome().InitDriver();
                default: return null;
            }
        }
    }
}
