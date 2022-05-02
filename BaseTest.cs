using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System;
using demoBlazeAutomation_JAVS.Handler;
using System.Reflection;
using NUnit.Framework.Interfaces;
using System.Configuration;

namespace demoBlazeAutomation_JAVS
{
    public abstract class BaseTest
    {

        protected IWebDriver Driver;
       // protected string Url = ConfigurationManager.AppSettings["Url"];
        protected Random rnd;


        [SetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            Driver = new ChromeDriver(path + @"\driver\");
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            rnd = new Random();

        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
            {
                ScreenShotHandler.TakeScreenShot(Driver);
            }

            Driver.Quit();
        }
    }
}
