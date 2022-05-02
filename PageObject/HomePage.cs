using OpenQA.Selenium;
using System;
using demoBlazeAutomation_JAVS.Handler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoBlazeAutomation_JAVS.PageObject
{
    public class HomePage
    {
        IWebDriver Driver;

        // login modal
        protected By LoginModal = By.XPath("//div[@id='logInModal']");
        protected By UserLoginInput = By.XPath("//input[@id='loginusername']");
        protected By PasswordLoginInput = By.XPath("//input[@id='loginpassword']");
        protected By LogInBtn = By.XPath("//div[@id='logInModal']//button[text()='Log in']");
        protected By CloseLogInBtn = By.XPath("//div[@id='logInModal']//button[text()='Close']");


        //Sign up modal elements
        protected By SignUpModal = By.XPath("//div[@id='signInModal']");
        protected By UserSignUpInput = By.XPath("//input[@id='sign-username']");
        protected By PassSignUpInput = By.XPath("//input[@id='sign-password']");
        protected By SignUpSubmitBtn = By.XPath("//div[@id='signInModal']//button[text()='Sign up']");
        protected By CloseSignUpBtn = By.XPath("//div[@id='signInModal']//button[text()='Close']");

        // links-tabs for navigation (sign,up, log out, log in, cart, home page, etc)
        protected By LoginLink = By.XPath("//a[@id='login2']");
        protected By SignUpLink = By.XPath("//a[@id='signin2']");
        protected By CartLink = By.XPath("//a[@id='cartur']");
        protected By UserNameText = By.XPath("//a[@id='nameofuser']");

        //Product Container
        protected By ProductCards = By.XPath("//div[@id='tbodyid']//div[@class='card h-100']");
        protected By PhonesCategoryLink = By.XPath("//a[text()='Phones']");
        protected By LaptopsCategoryLink = By.XPath("//a[text()='Laptops']");
        protected By MonitorsCategoryLink = By.XPath("//a[text()='Monitors']");
        protected By ProductNextPageBtn = By.XPath("//button[text()='Next']");
        protected By ProductPreviousPageBtn = By.XPath("//button[text()='Previous']");



        public HomePage(IWebDriver driver)
        {
            Driver = driver;

        }

        private void TypeUser(By input, string user)
        {
            Driver.FindElement(input).SendKeys(user);
        }

        private void TypePassword(By passInput, string password)
        {
            Driver.FindElement(passInput).SendKeys(password);
        }

        private void ClickLoginButton()
        {
            Driver.FindElement(LogInBtn).Click();
        }

        private void ClickLink(By locator)
        {
            Driver.FindElement(locator).Click();
        }

        public void GoToSignUp()
        {
            ClickLink(SignUpLink);
        }
        public void GoToLogin()
        {
            ClickLink(LoginLink);
        }
        public void GoToNextProductPage()
        {
            Driver.FindElement(ProductNextPageBtn).Click();
        }

        public void GoToPreviousProductPage()
        {
            Driver.FindElement(ProductPreviousPageBtn).Click();
        }

        public ProductDetailPage GoToProductDetail(string productName)
        {
            Driver.FindElement(By.XPath("//div[@id='tbodyid']//div[@class='card h-100']//a[text()='"+productName+"']")).Click() ;
            return new ProductDetailPage(Driver);
        }



        public bool SignUpIsPresent()
        {
            return waitHandler.ElementIsPresent(Driver,SignUpModal);
        }
        public bool LoginIsPresent()
        {
            return waitHandler.ElementIsPresent(Driver, LoginModal);
        }

        public bool ProductsIsPresent()
        {
             return Driver.FindElements(ProductCards).Count >= 1;
        }

        public int ProductsPresent()
        {
            System.Threading.Thread.Sleep(800);
            return Driver.FindElements(ProductCards).Count;
        }
        public void FilterCategorybyPhones()
        {
            Driver.FindElement(PhonesCategoryLink).Click();
        }

        public void FilterCategorybyLaptops()
        {
            Driver.FindElement(LaptopsCategoryLink).Click();
        }

        public void FilterCategorybyMonitors()
        {
            Driver.FindElement(MonitorsCategoryLink).Click();
        }

        public void FillSignUpForm(string userName, string password)
        {
            TypeUser(UserSignUpInput,userName);
            TypePassword(PassSignUpInput, password);
        }

        public void FillLoginForm(string userName, string password)
        {
            TypeUser(UserLoginInput, userName);
            TypePassword(PasswordLoginInput, password);
        }

        public void SubmitSignUp()
        {
            Driver.FindElement(SignUpSubmitBtn).Click();
        }

        public void SubmitLogin()
        {
            ClickLoginButton();
        }

        public string AlertMessage()
        {
            System.Threading.Thread.Sleep(500);
            var alert = Driver.SwitchTo().Alert();
            return alert.Text.ToString();
        }

        public void dismissAlert()
        {
            Driver.SwitchTo().Alert().Accept();
        }

        public string IsLoggedIn()
        {
            System.Threading.Thread.Sleep(1000);
           return Driver.FindElement(UserNameText).Text;
        }

    }
}
