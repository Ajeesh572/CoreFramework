namespace UIAutomation.Base
{
    using OpenQA.Selenium;
    using UIAutomation.Components;
    using UIAutomation.WebDriverUtils;
    public abstract class BasePage : BaseComponent
    {
        public static IWebDriver Driver=WebDriverManager.Instance.GetWebDriver;
    }
}
