using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace MortgageCalculator.Pages
{
    public class AppPages
    {
        public readonly ISpecFlowOutputHelper specFlowOutputHelper;
        public readonly HomePage homePage;


        public AppPages(ISpecFlowOutputHelper specFlowOutputHelper, HomePage homePage)
        {

            this.homePage = homePage;
            this.specFlowOutputHelper = specFlowOutputHelper;

        }



    }
}
