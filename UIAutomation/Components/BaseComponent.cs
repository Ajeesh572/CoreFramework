namespace UIAutomation.Components
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UIAutomation.WebDriverUtils;
    public abstract partial class BaseComponent
    {
        /// <summary>
        /// Gets page Title of current page
        /// </summary>
        public String GetPageTitle => WebDriverManager.Instance.GetWebDriver.Title;

        /// <summary>
        /// Gets Text of element
        /// </summary>
        /// <param name="element">By element</param>
        /// <returns>Text</returns>
        public String GetText(By element) => GetWebElement(element).Text;

        /// <summary>
        /// Gets IWebElement from By element.
        /// </summary>
        /// <param name="byElement">Defines instance of by Element</param>
        /// <returns></returns>
        public IWebElement GetWebElement(By byElement) => WebDriverManager.Instance.GetWebDriver.FindElement(byElement);

        /// <summary>
        /// Gets IWebElement from By element.
        /// </summary>
        /// <param name="byElement">Defines instance of by Element</param>
        /// <returns></returns>
        public List<IWebElement> GetWebElements(By byElement) => WebDriverManager.Instance.GetWebDriver.FindElements(byElement).ToList();

        /// <summary>
        /// Gets attribute value of an element.
        /// </summary>
        /// <param name="byElement">By element on DOM</param>
        /// <param name="attributeValue">Attribute name on DOM</param>
        /// <returns>Attribute value</returns>
        public String GetAttributeValue(By byElement, String attributeValue)
        {
            return GetWebElement(byElement).GetAttribute(attributeValue);
        }
    }
}
