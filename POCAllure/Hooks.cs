using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.Net.Commons;
using MonoMod.Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Page;
using TechTalk.SpecFlow;

namespace POCAllure
{
    [Binding]
    internal class Hooks
    {
        public static AllureLifecycle allure = AllureLifecycle.Instance;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            allure.CleanupResultDirectory();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError!= null)
            {
                byte[] content = CaptureScreenshot();
                    AllureApi.AddAttachment("Failed Screenshot","application/png", content);
            }
        }

        public static byte[] CaptureScreenshot()
        {
            return ((ITakesScreenshot)StepDefinitions.SearchTestStepDefinitions.driver).GetScreenshot().AsByteArray;
        }
    }
}
