using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_NUnit
{
    public class MainPageBuilder
    {
        private readonly IWebDriver _driver;

        public MainPageBuilder(IWebDriver driver)
        {
            _driver = driver;
        }

        public MainPage Build()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");
            _driver.Manage().Window.Maximize();
            return new MainPage(_driver);
        }
    }
}
