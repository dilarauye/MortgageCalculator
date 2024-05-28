using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace MortgageCalculator.Pages
{
    public class HomePage
    {

        private ISpecFlowOutputHelper specFlowOutputHelper;

        public HomePage(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            this.specFlowOutputHelper = specFlowOutputHelper;
        }
    }
}
