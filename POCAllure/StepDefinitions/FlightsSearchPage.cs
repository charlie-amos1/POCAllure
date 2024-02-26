using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace POCAllure.StepDefinitions
{
    [Binding]
    public class FlightSearchPage
    {
        private IWebDriver _driver;

        public FlightSearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By searchButton = By.CssSelector(".search-box-group.search-box-group--submit");
        private By popUP = By.CssSelector("div.full-screen-loader p:nth-child(5)");

        internal void ClickSearchButton()
        {
            _driver.FindElement(searchButton).Click();
        }

        internal bool IsPopUpVisible()
        {
            return _driver.FindElement(popUP).Displayed;
        }
    }
}