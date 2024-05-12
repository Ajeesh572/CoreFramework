namespace UIAutomation.Tests.Steps
{
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using UIAutomation.Tests.Pages;
    [Binding]
    public sealed class AccessoryPaneSteps
    {
        AccessoryPane accessoryPane;
        public AccessoryPaneSteps()
        {
            accessoryPane = new AccessoryPane();
        }
        [When(@"I Click ""([^""]*)"" Button on Accessory Pane")]
        public void WhenIClickButtonOnAccessoryPane(string fieldName)
        {
            accessoryPane.WaitUntilElementIsDisplayed(accessoryPane.GetWebElementByFieldName(fieldName));
            var element = accessoryPane.GetWebElement(accessoryPane.GetWebElementByFieldName(fieldName));
            accessoryPane.ClickElement(element);
        }

        [When(@"I close Accessory Pane if displayed")]
        public void WhenICloseAccessoryPaneIfAvailableOnProductsPage()
        {
            By byElement = accessoryPane.GetWebElementByFieldName("Close");
            accessoryPane.WaitUntilElementIsDisplayed(byElement, 3);
            IWebElement element = accessoryPane.GetWebElement(byElement);
            accessoryPane.ClickElement(element);
            accessoryPane.WaitUntilElementIsInvisible(accessoryPane.GetWebElementByFieldName("Pane"));
            accessoryPane.WaitUntilPageIsLoaded();
        }

    }
}