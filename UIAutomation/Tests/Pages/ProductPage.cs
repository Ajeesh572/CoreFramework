namespace UIAutomation.Tests.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using UIAutomation.Base;
    public class ProductPage : BasePage
    {
        private By addToCart = By.CssSelector("#desktop_qualifiedBuyBox #add-to-cart-button");

        private By accessoryPane = By.CssSelector("#attach-accessory-pane");

        private By priceOfProduct = By.CssSelector("#centerCol .a-price-whole");

        private By productName = By.CssSelector("#titleSection #productTitle");
        public By GetWebElementByFieldName(string fieldName)
        {
            Dictionary<string, By> myDictionary = new Dictionary<string, By>();
            myDictionary.Add("Add to Cart", addToCart);
            myDictionary.Add("Accessory Pane", addToCart);
            myDictionary.Add("Product Price", priceOfProduct);
            myDictionary.Add("Product Name", productName);
            return myDictionary[fieldName];
        }
    }
}
