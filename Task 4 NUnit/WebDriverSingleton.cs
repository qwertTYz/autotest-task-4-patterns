using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_NUnit
{
    public class WebDriverSingleton
    {
        private static IWebDriver? _driver;

        private WebDriverSingleton() { }

        public static IWebDriver? Driver { get => _driver; set => _driver = value; }

        public static IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                Driver = new ChromeDriver();
            }

            return Driver;
        }

        public static void QuitDriver()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                Driver = null;
            }
        }
    }
}
