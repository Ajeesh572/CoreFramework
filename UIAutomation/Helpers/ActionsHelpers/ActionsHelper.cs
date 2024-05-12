namespace UIAutomation.Helpers.ActionsHelpers
{
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium;
    using UIAutomation.WebDriverUtils;

    public class ActionsHelper
    {
        /// <summary>
        /// Hits Escape keys generally
        /// </summary>
        public static void PressEacape()
        {
            Actions actions = new Actions(WebDriverManager.Instance.GetWebDriver);
            actions.SendKeys(Keys.Escape).Perform();
        }
    }
}
