namespace UIAutomation.Components
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;
    using System;
    using UIAutomation.Utilities.Logger;
    using UIAutomation.WebDriverUtils;

    public abstract partial class BaseComponent
    {

        /// <summary>
        /// Clicks on an element.
        /// </summary>
        /// <param name="element">WebElement</param>
        public void ClickElement(IWebElement element)
        {
            WaitUntilElementIsClickeable(element);
            element.Click();
        }

        /// <summary>
        /// Waits until a web element is clickable.
        /// </summary>
        /// <param name="webElement">Is the web element that method will wait</param>
        public void WaitUntilElementIsClickeable(IWebElement webElement)
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        /// <summary>
        /// Waits until a web element is displayed.
        /// </summary>
        /// <param name="byElement">Is the element that method will wait</param>
        public void WaitUntilElementIsDisplayed(By byElement, int seconds = 0)
        {
            if (seconds == 0)
                WebDriverManager.Instance.GetWebDriverWait.Until(ExpectedConditions.ElementIsVisible(byElement));
            else
            {
                WebDriverWait wait = new WebDriverWait(WebDriverManager.Instance.GetWebDriver, TimeSpan.FromMilliseconds(seconds * 1000));
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(byElement));
                }
                catch (WebDriverTimeoutException ev)
                {
                    Logging.Debug($"Element not visible {ev.Message}");
                }
            }

        }

        /// <summary>
        /// Waits until a web element is displayed.
        /// </summary>
        /// <param name="webElement">Is the web element that method will wait</param>
        public void WaitUntilPageIsLoaded()
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// Fill input to Text field.
        /// </summary>
        /// <param name="webElement">web element</param>
        /// <param name="value">Value for fill</param>
        public void FillInput(IWebElement webElement, string value)
        {
            WaitUntilElementIsClickeable(webElement);
            webElement.Clear();
            webElement.SendKeys(value);
        }
    }
}
