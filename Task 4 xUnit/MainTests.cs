using System;
using System.ComponentModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Task_4_xUnit;
using Xunit;

namespace Task_4_XUnit
{

    public class MainTests
    {
        private IWebDriver _driver;
        private MainPage _mainPage;
        private IWebDriver InitDriver()
        {
            _driver = WebDriverSingleton.GetDriver();
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");
            _driver.Manage().Window.Maximize();

            _mainPage = new MainPage(_driver);

            return _driver;
        }

        [Fact]
        [Trait("Category", "About")]
        public void AboutTest()
        {
            using (var _driver = InitDriver())
            {
                _mainPage.NavigateToAbout();

                Assert.Equal("https://en.ehu.lt/about/", _driver.Url);

                WebDriverSingleton.QuitDriver();
            }
        }

        [Theory]
        [InlineData("study programs")]
        [Trait("Category", "Search")]
        public void SearchTest(string search)
        {
            using (var driver = InitDriver())
            {
                _mainPage.Search(search);

                Assert.Equal("https://en.ehu.lt/?s=study+programs", _driver.Url);

                WebDriverSingleton.QuitDriver();
            }
        }

        [Fact]
        [Trait("Category", "LanguageChange")]
        public void LanguageChangeTest()
        {
            using (var driver = InitDriver())
            {
                _mainPage.LanguageChange();
                Assert.Equal("https://lt.ehu.lt/", driver.Url);

                WebDriverSingleton.QuitDriver();
            }
        }

        [Fact]
        [Trait("Category", "ContactInfo")]
        public void ContactInfoTest()
        {
            using (var driver = InitDriver())
            {
                _mainPage.ContactInfo();

                Assert.True(_mainPage.Email.Displayed);
                Assert.True(_mainPage.PhoneLT.Displayed);
                Assert.True(_mainPage.PhoneBY.Displayed);
                Assert.True(_mainPage.SocialNetworks.Displayed);

                WebDriverSingleton.QuitDriver();
            }
        }
    }
}
