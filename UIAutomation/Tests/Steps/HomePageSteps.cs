namespace UIAutomation.Tests.Steps
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using System.Linq;
    using TechTalk.SpecFlow;
    using UIAutomation.Helpers;
    using UIAutomation.Pages;
    [Binding]
    public sealed class HomePageSteps
    {
        private AmazonHomePage amazonHomePage;
        private Scenariocontext scenariocontext;
        public HomePageSteps(Scenariocontext scenariocontext)
        {
            amazonHomePage = new AmazonHomePage();
            this.scenariocontext = scenariocontext;
        }

        [When(@"I Choose Item ""([^""]*)"" of search result on home page")]
        public void WhenIChooseItemOfSearchResultOnHomePage(int itemNumberOfSearchResults)
        {
            By element = amazonHomePage.GetWebElementByFieldName("Search Results");
            amazonHomePage.GetWebElements(element)[itemNumberOfSearchResults].Click();
        }

        [When(@"I Note ""([^""]*)"" name from Search list and save by key ""([^""]*)"" on home page")]
        public void WhenINoteNameFromSearchListAndSaveByKeyOnHomePage(int itemNumberOfSearchResults, string choosenItem)
        {
            By element = amazonHomePage.GetWebElementByFieldName("Search Results");
            string name = amazonHomePage.GetWebElements(element)[itemNumberOfSearchResults].Text;
            scenariocontext.setContext(choosenItem, name);
        }

        [Then(@"I Verify Page Title (is|contains) ""([^""]*)""")]
        public void ThenIVerifyPageTitleIs(string condition, string expectedPageName)
        {
            string actualPageName = amazonHomePage.GetPageTitle;
            amazonHomePage.WaitUntilPageIsLoaded();
            var status = condition == "is" ? expectedPageName.Equals(actualPageName) : actualPageName.Contains(expectedPageName);
            Assert.True(status);
        }

        [Then(@"I Verify ""([^""]*)"" are for ""([^""]*)"" on home page")]
        public void ThenIVerifyAreForOnHomePage(string fieldName, string expectedTextInSearchResults)
        {
            By element = amazonHomePage.GetWebElementByFieldName(fieldName);
            Boolean status = amazonHomePage.GetWebElements(element).Any(item => item.GetAttribute("href").Contains(expectedTextInSearchResults));
            Assert.True(status, $"The Search results dosent has {expectedTextInSearchResults}");
        }

    }
}