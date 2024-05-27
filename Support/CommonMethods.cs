using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MortgageCalculator.Support
{
    internal class CommonMethods
    {

        public static string GetAppSettingsValue(string key)
        {

            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("ApSettings.json").Build().GetSection(key).Value;

        }

    }
}
