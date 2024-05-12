namespace UIAutomation.Tests.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using UIAutomation.Base;

    public class AccessoryPane : BasePage
    {
        private By accessoryPane = By.CssSelector("#attach-accessory-pane");
        private By closeAccessoryPane = By.CssSelector("a.a-link-normal.close-button");

        public By GetWebElementByFieldName(string fieldName)
        {
            Dictionary<string, By> myDictionary = new Dictionary<string, By>();
            myDictionary.Add("Close", closeAccessoryPane);
            myDictionary.Add("Pane", accessoryPane);
            return myDictionary[fieldName];
        }
    }
}
