using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MortgageCalculator.Support
{
    public class CommonMethods
    {

        public static string GetAppSettingsValue(string key)
        {

            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json").Build().GetSection(key).Value;

        }


        public static string GetDateOfBirth(int age)
        {

            // Calculate the year of birth
            int currentYear = DateTime.Now.Year;
            int yearOfBirth = currentYear - age;


            // Return the date of birth assuming the same month and day as today
            return new DateTime(yearOfBirth, DateTime.Now.Month, DateTime.Now.Day).ToString();


        }







    }
}
