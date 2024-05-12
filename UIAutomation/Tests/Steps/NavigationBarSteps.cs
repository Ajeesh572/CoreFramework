namespace UIAutomation.Tests.Steps
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using UIAutomation.Tests.Pages;
    [Binding]
    public sealed class NavigationBarSteps
    {
        private NavigationBar navigationBar;
        public NavigationBarSteps()
        {
            navigationBar = new NavigationBar();
        }
        [When(@"I Fill in field ""([^""]*)"" by value ""([^""]*)"" on Navigation Bar")]
        public void WhenIFillInFieldByValueOnNavigation(string fieldName, string fieldValue)
        {
            navigationBar.WaitUntilElementIsDisplayed(navigationBar.GetWebElementByFieldName(fieldName));
            IWebElement element = navigationBar.GetWebElement(navigationBar.GetWebElementByFieldName(fieldName));
            navigationBar.FillInput(element, fieldValue);
        }

        [When(@"I Hit enter in ""([^""]*)"" on Navigation Bar")]
        public void WhenIHitEnterInOnNavigation(string fieldName)
        {
            By element = navigationBar.GetWebElementByFieldName(fieldName);
            navigationBar.PressEnterKey(element);
            navigationBar.WaitUntilPageIsLoaded();
        }

        [When(@"I Click ""([^""]*)"" Button on Navigation Bar")]
        public void WhenIClickButtonOnNavigation(string fieldName)
        {
            navigationBar.WaitUntilElementIsDisplayed(navigationBar.GetWebElementByFieldName(fieldName));
            By element = navigationBar.GetWebElementByFieldName(fieldName);
            navigationBar.ClickElement(navigationBar.GetWebElement(element));
        }

        [Then(@"I Verify Field ""([^""]*)"" has value ""([^""]*)"" for atttribute ""([^""]*)"" on Navigation Bar")]
        public void ThenIVerifyFieldHasValueForAtttributeOnNavigation(string fieldName, string expectedValue, string attributeName)
        {
            By element = navigationBar.GetWebElementByFieldName(fieldName);
            string actualValue = navigationBar.GetAttributeValue(element, attributeName);
            Assert.True(expectedValue.Equals(actualValue));
        }
    }
}