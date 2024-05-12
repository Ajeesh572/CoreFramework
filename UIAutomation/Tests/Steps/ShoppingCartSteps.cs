namespace UIAutomation.Tests.Steps
{
    using NUnit.Framework;
    using System.Globalization;
    using System.Linq;
    using TechTalk.SpecFlow;
    using UIAutomation.Helpers;
    using UIAutomation.Tests.Pages;
    [Binding]
    public sealed class ShoppingCartSteps
    {
        private ShoppingCartPage shoppingCartPage;
        private Scenariocontext scenariocontext;
        public ShoppingCartSteps(Scenariocontext scenariocontext)
        {
            shoppingCartPage = new ShoppingCartPage();
            this.scenariocontext = scenariocontext;
        }
        [Then(@"I Verify ""([^""]*)"" is same as ""([^""]*)"" on shopping cart")]
        public void ThenIVerifyIsSameAsOnShoppingCart(string fieldName, string contextKey)
        {
            string actulText = shoppingCartPage.GetText(shoppingCartPage.GetWebElementByFieldName(fieldName));
            string expectedText = scenariocontext.getContext(contextKey).ToString();
            decimal actulTextDecimal = decimal.Parse(actulText, NumberStyles.Currency);
            decimal expectedTextDecimal = decimal.Parse(expectedText, NumberStyles.Currency);
            Assert.True(actulTextDecimal.Equals(expectedTextDecimal));
        }

        [Then(@"I Verify Sub Total price displayed is sum of below on shopping cart")]
        public void ThenIVerifySubTotalPriceDisplayedIsSumOfBelow(Table table)
        {
            var keys = table.Rows.Select(row => row[0]).ToList();
            decimal expectedSubTotal = 0;
            foreach (var key in keys)
            {
                expectedSubTotal = expectedSubTotal + decimal.Parse(scenariocontext.getContext(key).ToString(), NumberStyles.Currency);
            }
            string actulSubTotalText = shoppingCartPage.GetText(shoppingCartPage.GetWebElementByFieldName("Sub Total"));
            Assert.True(expectedSubTotal.Equals(decimal.Parse(actulSubTotalText, NumberStyles.Currency)));
        }

    }
}