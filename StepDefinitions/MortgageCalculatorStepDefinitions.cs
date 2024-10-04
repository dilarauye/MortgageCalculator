using Microsoft.Playwright;
using MortgageCalculator.Pages;
using MortgageCalculator.Support;
using TechTalk.SpecFlow.Infrastructure;
using static MortgageCalculator.Support.CommonMethods;


namespace MortgageCalculator.StepDefinitions
{
    [Binding]
    public class MortgageCalculatorStepDefinitions 
    {

        public IPage page;
        public AppPages appPages;
        public ISpecFlowOutputHelper outputHelper;
        public ScenarioContext scenarioContext;
        public MortgageCalculatorStepDefinitions(AppPages appPages, ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext, Hooks hooks )
        {
            this.appPages = appPages;
            this.outputHelper = specFlowOutputHelper;
            this.scenarioContext = scenarioContext;
            this.page = hooks.page;              
        }


        [Given(@"user is on the Home Page")]
        public async Task GivenUserIsOnTheHomePage()
        {
            await Expect(appPages.homePage.HomePageHeader).ToBeVisibleAsync();
        }

        [When(@"user fills in Borrower Details '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public async Task WhenUserFillsInBorrowerDetails(string age, string propertyValue, string zipCode, string remainingMortgageBalance)
        {
            await appPages.homePage.BorrowerProfileZipInputBox.FillAsync(zipCode);
            await appPages.homePage.BorrowerProfileAgeInputBox.FillAsync(age);
            await appPages.homePage.BorrowerProfileValueOfPropertyInputBox.FillAsync(propertyValue);
            await appPages.homePage.BorrowerProfileRemainingMortgageBalanceInputBox.FillAsync(remainingMortgageBalance);

        }

        [Then(@"estimate calculation link should be visible")]
        public async Task EstimateCalculationLinkShouldBeVisible()
        {
            
            await Expect(appPages.homePage.HomeSafeEstimatesCalculationLink).ToBeVisibleAsync();

        }

        [Then(@"Remaining Equity tooltip should be enabled")]
        public async Task ThenRemainingEquityTooltipShouldBeEnabled()
        {

            await Expect(appPages.homePage.HomeSafeRemainingEquityToolTip).ToBeEnabledAsync();
        }



        [Then(@"Remaining Equity value '([^']*)' should be visible")]
        public async Task ThenRemainingEquityValueShouldBeVisible(string remainingEquityValue)
        {
            await Expect(page.GetByText(remainingEquityValue)).ToBeVisibleAsync();
        }

        [When(@"user clicks on Download PDF link")]
        public async Task WhenUserClicksOnDownloadPDFLink()
        {
            var waitForDownloadTask = page.WaitForDownloadAsync();
            await appPages.homePage.DownloadPDFLink.ClickAsync();
            var download = await waitForDownloadTask;
            var path = await download.PathAsync();
            scenarioContext["DownloadedFilePath"] = path;
        }



        [Then(@"PDF should be downloaded")]
        public void ThenPDFShouldBeDownloaded()
        {
            string filePath = scenarioContext["DownloadedFilePath"].ToString();
            Assert.True(File.Exists(filePath));
        }














    }
}
