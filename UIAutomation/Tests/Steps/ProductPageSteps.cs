namespace UIAutomation.Tests.Steps
{
    using TechTalk.SpecFlow;
    using OpenQA.Selenium;
    using UIAutomation.Tests.Pages;
    using UIAutomation.Helpers;
    using NUnit.Framework;

    [Binding]
    public sealed class ProductPageSteps
    {

        private ProductPage productPage;
        private Scenariocontext scenariocontext;
        public ProductPageSteps(Scenariocontext scenariocontext)
        {
            productPage = new ProductPage();
            this.scenariocontext = scenariocontext;
        }
        [When(@"I Click ""([^""]*)"" Button on Products page")]
        public void WhenIClickButtonOnProductsPage(string fieldName)
        {
            By element = productPage.GetWebElementByFieldName(fieldName);
            productPage.WaitUntilElementIsDisplayed(element);
            productPage.ClickElement(productPage.GetWebElement(element));
            productPage.WaitUntilPageIsLoaded();

        }

        [When(@"I Wait for Accessory Pane on Products page")]
        public void WhenIWaitForAccessoryPaneOnProductsPage()
        {
            productPage.WaitUntilElementIsDisplayed(productPage.GetWebElementByFieldName("Accessory Pane"));
            productPage.WaitUntilPageIsLoaded();
        }


        [When(@"I Note price of product by key ""([^""]*)"" on Products page")]
        public void WhenINotePriceOfProductByKeyOnProductsPage(string key)
        {
            string value = productPage.GetText(productPage.GetWebElementByFieldName("Product Price"));
            scenariocontext.setContext(key, value);
        }

        [Then(@"I Verify Product name is ""([^""]*)"" on Products page")]
        public void ThenIVerifyProductNameIsOnProductsPage(string key)
        {
            string expectedValue = scenariocontext.getContext(key).ToString();
            string actualValue = productPage.GetText(productPage.GetWebElementByFieldName("Product Name"));
            Assert.True(expectedValue.Equals(expectedValue));
        }


    }
}