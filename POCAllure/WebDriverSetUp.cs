using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace POCAllure
{
    internal class WebDriverSetUp
    {
        private IWebDriver _driver;

        WebDriverSetUp(IWebDriver driver)
        {
            _driver = driver;
        }

        [BeforeTestRun]
        public void InstantiateDriver()
        {
            _driver.Navigate().GoToUrl("https://www.google.com");
        }
    }
}
