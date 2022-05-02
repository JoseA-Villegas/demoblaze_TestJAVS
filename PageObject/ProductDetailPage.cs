using demoBlazeAutomation_JAVS.Handler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoBlazeAutomation_JAVS.PageObject
{
    public class ProductDetailPage
    {
        protected IWebDriver Driver;

        protected By ProductNameHeader = By.XPath("//div[@class='product-content product-wrap clearfix product-deatil']//h2[@class='name']");
        protected By ProductPriceHeader = By.XPath("//h3[@class='price-container']");
        protected By ProductDescription = By.XPath("//div[@id='myTabContent']//p");
        protected By AddCartBtn = By.XPath("//a[@class='btn btn-success btn-lg'][text()='Add to cart']");

        // links-tabs for navigation (sign,up, log out, log in, cart, home page, etc)
        protected By CartLink = By.XPath("//a[@id='cartur']");
        protected By HomePageLink = By.XPath("//a[text()='Home ']");

        public ProductDetailPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public string ProductTitleText()
        {
            return Driver.FindElement(ProductNameHeader).Text;
        }

        public string ProductPriceText()
        {
            return Driver.FindElement(ProductPriceHeader).Text;
        }

        public string ProductDescriptionText()
        {
            return Driver.FindElement(ProductDescription).Text;

        }

        public bool ProductTitleIsPresent()
        {
            return waitHandler.ElementIsPresent(Driver, ProductNameHeader);

        }
        public bool ProductPriceIsPresent()
        {
            return waitHandler.ElementIsPresent(Driver, ProductPriceHeader);

        }
        public bool ProductDescriptionIsPresent()
        {
            return waitHandler.ElementIsPresent(Driver, ProductDescription);

        }

        public HomePage GoToHomePage()
        {
            Driver.FindElement(HomePageLink).Click();
            return new HomePage(Driver);
        }

        public CartPage GoToCart()
        {
            Driver.FindElement(CartLink).Click();
            return new CartPage(Driver);
        }

        public void AddProductToCart()
        {
            Driver.FindElement(AddCartBtn).Click();
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

        
    }
}
