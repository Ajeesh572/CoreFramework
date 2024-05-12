namespace UIAutomation.Tests.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using UIAutomation.Base;

    public class ShoppingCartPage : BasePage
    {
        private By itemPrice = By.CssSelector(".sc-list-item-content [class*=badge-price-to-pay]");
        private By subTotal = By.CssSelector("[data-name=Subtotals] [id*='subtotal-amount-buybox']");

        public By GetWebElementByFieldName(string fieldName)
        {
            Dictionary<string, By> myDictionary = new Dictionary<string, By>();
            myDictionary.Add("Price", itemPrice);
            myDictionary.Add("Sub Total", subTotal);
            return myDictionary[fieldName];
        }
    }
}
