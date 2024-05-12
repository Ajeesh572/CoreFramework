namespace UIAutomation.Tests.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using UIAutomation.Base;
    using UIAutomation.WebDriverUtils;

    public class NavigationBar : BasePage
    {
        public NavigationBar()
        {
            ((IJavaScriptExecutor)WebDriverManager.Instance.GetWebDriver).ExecuteScript("window.scrollTo(0, 0)");
        }
        private By searchBox = By.CssSelector("#twotabsearchtextbox");

        private By cart = By.CssSelector("a#nav-cart");

        public By GetWebElementByFieldName(string fieldName)
        {
            Dictionary<string, By> myDictionary = new Dictionary<string, By>();
            myDictionary.Add("Search Box", searchBox);
            myDictionary.Add("Cart", cart);
            return myDictionary[fieldName];
        }
    }
}
