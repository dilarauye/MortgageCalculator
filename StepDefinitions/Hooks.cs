using Microsoft.Playwright;
using MortgageCalculator.Support;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using static MortgageCalculator.Support.CommonMethods;


namespace MortgageCalculator.StepDefinitions
{
    [Binding]
    public class Hooks 
    {

        private IPlaywright playwright;
        private IBrowser browser;
        private IBrowserContext context;
        public IPage page { get; set; } = null!;
        public static int numberOfFailedtests;
        private static BrowserNewContextOptions testDevice;
        private readonly ScenarioContext scenarioContext;
        private readonly ISpecFlowOutputHelper outputHelper;

        public Hooks(ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
        {

            this.scenarioContext = scenarioContext;
            this.outputHelper = specFlowOutputHelper;
        }
       

        [BeforeScenario]
        public async Task CreatePlaywright()
        {

            playwright ??= await Playwright.CreateAsync();
            testDevice = playwright.Devices[GetAppSettingsValue("TestDevice")];

            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Timeout = 120000,
                SlowMo = 0

            });

            context = await browser.NewContextAsync(new(testDevice));
            await context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            page = await context.NewPageAsync();
            var url = GetAppSettingsValue("Url");
            await page.GotoAsync(url);
            await page.WaitForLoadStateAsync();
            outputHelper.WriteLine($"test url is {url}");



        }

        [AfterScenario]
        public async Task AfterScenario()
        {
           
            if ( scenarioContext.TestError != null )
            {
                numberOfFailedtests++;
                await context.Tracing.StopAsync(new()
                {

                    Path = $"{scenarioContext.ScenarioInfo.Title}_{numberOfFailedtests}.trace.zip"

                });

            }
            if (page  != null)
            {
                await page.CloseAsync();

            }
            if (context != null)
            {
                await context.CloseAsync();
            }
            if (browser != null)
            {
                await browser.CloseAsync();
            }

            playwright?.Dispose();

        }
    }
}