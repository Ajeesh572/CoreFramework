namespace UIAutomation.Tests.Hooks
{
    using TechTalk.SpecFlow;
    using UIAutomation.WebDriverUtils;
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverManager.Instance.QuitDriver();
        }
    }
}