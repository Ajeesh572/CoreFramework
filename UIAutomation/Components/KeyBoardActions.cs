namespace UIAutomation.Components
{
    using OpenQA.Selenium;

    public abstract partial class BaseComponent
    {
        /// <summary>
        /// Hits Enter key inside defined field
        /// </summary>
        /// <param name="byElement">By element of field on DOM</param>
        public void PressEnterKey(By byElement) => GetWebElement(byElement).SendKeys(Keys.Enter);
    }
}
