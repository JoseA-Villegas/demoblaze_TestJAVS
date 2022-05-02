using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using demoBlazeAutomation_JAVS.PageObject;
using System.IO;
using System;

namespace demoBlazeAutomation_JAVS
{
    public class SignUpTests :BaseTest
    {

        [TestCase("distilleryTest0", "Test123")]
        public void SuccesfulSignUp(string username, string password)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToSignUp();
            Assert.IsTrue(homepage.SignUpIsPresent());
            homepage.FillSignUpForm(username+ rnd.Next(),password);
            homepage.SubmitSignUp();
            Assert.AreEqual("Sign up successful.",homepage.AlertMessage());
            homepage.dismissAlert();
        }

        [TestCase("test", "Test123")]
        public void SignUpFailsUserExists(string username, string password)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToSignUp();
            Assert.IsTrue(homepage.SignUpIsPresent());
            homepage.FillSignUpForm(username, password);
            homepage.SubmitSignUp();
            Assert.AreEqual("This user already exist.", homepage.AlertMessage());
            homepage.dismissAlert();
        }

        [TestCase("","Test123")]
        public void ValidateSignUpEmptyUsername(string username, string password)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToSignUp();
            Assert.IsTrue(homepage.SignUpIsPresent());
            homepage.FillSignUpForm(username, password);
            homepage.SubmitSignUp();
            Assert.AreEqual("Please fill out Username and Password.", homepage.AlertMessage());
            homepage.dismissAlert();
        }

        [TestCase("distilleryTest0", "")]
        public void ValidateSignUpEmptyPassword(string username, string password)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToSignUp();
            Assert.IsTrue(homepage.SignUpIsPresent());
            homepage.FillSignUpForm(username + rnd.Next(), password);
            homepage.SubmitSignUp();
            Assert.AreEqual("Please fill out Username and Password.", homepage.AlertMessage());
            homepage.dismissAlert();
        }

    }
}
