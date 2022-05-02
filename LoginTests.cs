using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using demoBlazeAutomation_JAVS.PageObject;
using System.IO;
using System;

namespace demoBlazeAutomation_JAVS
{
    public class LoginTests:BaseTest
    {

        [TestCase("distilleryTest1", "Test123")]
        public void ValidLogin(string username, string password)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            Assert.IsTrue(homepage.LoginIsPresent());
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
        }

        [TestCase("", "Test123", "Please fill out Username and Password.")]
        public void ValidateEmptyUsernameLogin(string username, string password, string alertMessage)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            Assert.IsTrue(homepage.LoginIsPresent());
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual(alertMessage, homepage.AlertMessage());
            homepage.dismissAlert();
        }

        [TestCase("distilleryTest1", "", "Please fill out Username and Password.")]
        public void ValidateEmptyPasswordLogin(string username, string password, string alertMessage)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            Assert.IsTrue(homepage.LoginIsPresent());
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual(alertMessage, homepage.AlertMessage());
            homepage.dismissAlert();
        }

        [TestCase("distTesting", "Test123", "User does not exist.")]
        public void ValidateNonExistentUserLogin(string username, string password, string alertMessage)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            Assert.IsTrue(homepage.LoginIsPresent());
            homepage.FillLoginForm(username + rnd.Next(), password);
            homepage.SubmitLogin();
            Assert.AreEqual(alertMessage, homepage.AlertMessage());
            homepage.dismissAlert();

        }

        [TestCase("distilleryTest1", "Test123", "Wrong password.")]
        public void ValidateIncorrectPassword(string username, string password, string alertMessage)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            Assert.IsTrue(homepage.LoginIsPresent());
            homepage.FillLoginForm(username, password + rnd.Next());
            homepage.SubmitLogin();
            Assert.AreEqual(alertMessage, homepage.AlertMessage());
            homepage.dismissAlert();

        }

       
    }
}
