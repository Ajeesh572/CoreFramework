namespace UIAutomation.Base
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using UIAutomation.WebDriverUtils;
    public class BaseLayout
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLayout"/> class.
        /// </summary>
        public BaseLayout()
        {
            this.Driver = WebDriverManager.Instance.GetWebDriver;
            this.Wait = WebDriverManager.Instance.GetWebDriverWait;
        }

        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        protected IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets the wait.
        /// </summary>
        protected WebDriverWait Wait { get; set; }
    }
}
