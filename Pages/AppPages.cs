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
        public readonly HomePage mainPage;


        public AppPages(ISpecFlowOutputHelper specFlowOutputHelper, HomePage mainPage)
        {

            this.mainPage = mainPage;
            this.specFlowOutputHelper = specFlowOutputHelper;

        }



    }
}
