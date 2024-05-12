namespace UIAutomation.Tests.Steps
{
    using TechTalk.SpecFlow;
    using UIAutomation.Enironments;
    using UIAutomation.Helpers.ActionsHelpers;
    using UIAutomation.Pages;
    using UIAutomation.WebDriverUtils;
    [Binding]
    public sealed class CommonSteps
    {
        [Given(@"I Launched application")]
        public void GivenILaunchedApplication()
        {
            WebDriverManager.Instance.GetWebDriver.Navigate().GoToUrl(EnvironmentManager.GetURL());
            new AmazonHomePage().WaitUntilPageIsLoaded();
        }

        [When(@"I Switch to tab ""([^""]*)""")]
        public void WhenISwitchToTab(int tabNumber)
        {
            var driver = WebDriverManager.Instance.GetWebDriver;
            driver.SwitchTo().Window(driver.WindowHandles[tabNumber]);
        }

        [When(@"I Click escape key")]
        public void WhenIClickEscapeKey()
        {
            ActionsHelper.PressEacape();
        }
    }
}