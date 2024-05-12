namespace UIAutomation.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using UIAutomation.Base;
    public class AmazonHomePage : BasePage
    {
        private By searchResults = By.CssSelector("[data-component-type='s-search-result'] h2 a");
     

        public By GetWebElementByFieldName(string fieldName)
        {
            Dictionary<string, By> myDictionary = new Dictionary<string, By>();
            myDictionary.Add("Search Results", searchResults);
            return myDictionary[fieldName];
        }



    }
}
