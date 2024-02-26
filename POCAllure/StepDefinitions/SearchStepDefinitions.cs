using System;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace POCAllure.StepDefinitions
{
    [Binding]
    public class SearchTestStepDefinitions
    {
        public static IWebDriver driver;
        public FlightSearchPage _flightSearchPage;
        private readonly IObjectContainer _container;

        SearchTestStepDefinitions(IWebDriver driver, IObjectContainer container)
        {
            driver = driver;
            _container = container;
            _flightSearchPage = new FlightSearchPage(driver);
        }

        [BeforeScenario(Order = -1)]
        public static void SetUpDriver(IObjectContainer objectContainer)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArguments("--disable-notifications");
            options.AddArgument("--headless=new");

            driver = new ChromeDriver(options);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [Given(@"the user navigates to the home page")]
        public void GivenTheUserNavigatesToTheHomePage()
        {
            driver.Navigate().GoToUrl("https://www.jet2holidays.com/search");
        }

        [Given(@"the user clicks search")]
        public void GivenTheUserClicksSearch()
        {
            _flightSearchPage.ClickSearchButton();
        }

        [Then(@"thea pop up should be visible")]
        public void ThenTheaPopUpShouldBeVisible()
        {
            Assert.That(_flightSearchPage.IsPopUpVisible);
        }

        [Then(@"the test passes")]
        public void ThenTheTestPasses()
        {
            Assert.That(0, Is.EqualTo(0));
        }

        [AfterScenario]
        public static void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}