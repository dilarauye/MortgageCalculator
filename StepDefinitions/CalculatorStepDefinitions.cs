using Microsoft.Playwright;
using MortgageCalculator.Pages;
using MortgageCalculator.Support;
using TechTalk.SpecFlow.Infrastructure;

namespace MortgageCalculator.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions : CommonMethods
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public IPage page;
        public AppPages appPages;
        public ISpecFlowOutputHelper outputHelper;
        public ScenarioContext scenarioContext;
        public CalculatorStepDefinitions(AppPages appPages, ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext, Hooks hooks )
        {
            this.appPages = appPages;
            this.outputHelper = specFlowOutputHelper;
            this.scenarioContext = scenarioContext;
            this.page = hooks.page;              
        }


        [Given(@"user is on the Home Page")]
        public void GivenUserIsOnTheHomePage()
        {
            Assertions.Expect(page).ToHaveTitleAsync("Xcelerate");
        }

        [When(@"user fills in Borrower Details '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenUserFillsInBorrowerDetails(int age, string propertyValue, string zipCode, string firstMortgageBalance)
        {
            var dOB = GetDateOfBirth(age);
            outputHelper.WriteLine(dOB);            
        }

        [When(@"user fills in Borrower Details with second mortgage '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void WhenUserFillsInBorrowerDetailsWithSecondMortgage(string p0, string p1, string p2, string p3, string p4)
        {
            outputHelper.WriteLine("");
        }


    }
}
