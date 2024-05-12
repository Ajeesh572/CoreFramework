namespace UIAutomation.Components
{
    using UIAutomation.WebDriverUtils;
    public abstract partial class BaseComponent
    {
        /// <summary>
        /// Switches to tab by opened number.
        /// </summary>
        /// <param name="tabNumber">Tab Number</param>
        public void SwitchToTab(int tabNumber)
        {
            var driver = WebDriverManager.Instance.GetWebDriver;
            driver.SwitchTo().Window(driver.WindowHandles[tabNumber]);
        }

    }

}
