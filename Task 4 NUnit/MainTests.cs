using System;
using System.Xml.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Task_4_NUnit
{
    [TestFixture]
    [Parallelizable]
    public class MainTests
    {
        private  IWebDriver _driver;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _driver = WebDriverSingleton.GetDriver();

            _mainPage = new MainPageBuilder(_driver).Build();
        }

        [Test]
        [Category("About")]
        public void AboutTest()
        {
            _mainPage.NavigateToAbout();

            Assert.That(_driver.Url == "https://en.ehu.lt/about/");
        }


        [Test]
        [Category("Search")]
        public void SearchTest()
        {
            _mainPage.Search("study programs");

            Assert.That(_driver.Url == "https://en.ehu.lt/?s=study+programs");
        }

        [Test]
        public void LanguageSwitcherTest()
        {
            _mainPage.LanguageChange();


            Assert.That(_driver.Url == "https://lt.ehu.lt/");
        }

        [Test]
        public void ContactInfoTest()
        {
            _mainPage.ContactInfo();

            Assert.That(_mainPage.Email.Displayed);
            Assert.That(_mainPage.PhoneLT.Displayed);
            Assert.That(_mainPage.PhoneBY.Displayed);
            Assert.That(_mainPage.SocialNetworks.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverSingleton.QuitDriver();
            _driver.Dispose();
        }
    }
}