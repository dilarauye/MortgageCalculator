using Microsoft.Playwright;
using MortgageCalculator.StepDefinitions;
using TechTalk.SpecFlow.Infrastructure;

namespace MortgageCalculator.Pages
{
    public class HomePage
    {
        private IPage page;
        private ISpecFlowOutputHelper specFlowOutputHelper;

        public HomePage(ISpecFlowOutputHelper specFlowOutputHelper, Hooks hooks)
        {
            this.specFlowOutputHelper = specFlowOutputHelper;
            page = hooks.page;


            
        }

        public ILocator HomePageHeader => page.GetByRole(AriaRole.Heading, new() { Name = "Reverse Mortgage Calculator" });
        public ILocator BorrowerProfileZipInputBox => page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code" });
        public ILocator BorrowerProfileAgeInputBox => page.GetByRole(AriaRole.Spinbutton, new() { Name = "Age" });
        public ILocator BorrowerProfileValueOfPropertyInputBox => page.GetByRole(AriaRole.Textbox, new() { Name = "Home Value" });
        public ILocator BorrowerProfileRemainingMortgageBalanceInputBox => page.GetByRole(AriaRole.Textbox, new() { Name = "Remaining Mortgage Balance" });
        public ILocator HomeSafeEstimatesCalculationLink => page.GetByRole(AriaRole.Link, new() { Name = "How are estimates calculated?" });

        public ILocator HomeSafeRemainingEquityToolTip => page.GetByRole(AriaRole.Tooltip, new() { Name = "How much equity you would still have in your home after receiving funds." });

        public ILocator DownloadPDFLink => page.GetByRole(AriaRole.Link, new() { Name = "Download PDF" });

        // public ILocator BorrowerProfileUpdateButton => page.GetByRole(AriaRole.Button, new() { Name = "Update" });
        // public ILocator BorrowerProfileIllustrateButton => page.GetByRole(AriaRole.Button, new() { Name = "Illustrate" });






    }
}
