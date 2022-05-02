using demoBlazeAutomation_JAVS.Handler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoBlazeAutomation_JAVS.PageObject
{
    public class CartPage
    {
        protected IWebDriver Driver;

        protected By PlaceOrderBtn = By.XPath("//button[text()='Place Order']");
        protected By PlaceOrderModal = By.XPath("//div[@id='orderModal']");

        //placeOrder Modal
        protected By NameOrderInput = By.XPath("//div[@id='orderModal']//input[@id='name']");
        protected By CountryOrderInput = By.XPath("//div[@id='orderModal']//input[@id='country']");
        protected By CityOrderInput = By.XPath("//div[@id='orderModal']//input[@id='city']");
        protected By CreditCardOrderInput = By.XPath("//div[@id='orderModal']//input[@id='card']");
        protected By CcMonthOrderInput = By.XPath("//div[@id='orderModal']//input[@id='month']");
        protected By CcYearOrderInput = By.XPath("//div[@id='orderModal']//input[@id='year']");
        protected By CloseOrderBtn = By.XPath("//div[@id='orderModal']//button[text()='Close']");
        protected By PurchaseOrderBtn = By.XPath("//div[@id='orderModal']//button[text()='Purchase']");

        //Purchase Success
        protected By PurchaseOkayBtn = By.XPath("//button[text()='OK']");
        protected By PurchaseSucessfulMessage = By.XPath("//h2[normalize-space()='Thank you for your purchase!']");

        // Cart Table 
        protected By CartProductsTable = By.XPath("//*[@id='tbodyid']");
        protected By CartProductDelBtn = By.XPath("//*[@id='tbodyid']//a[text()='Delete']");

        public CartPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void DeleteProduct()
        {
            Driver.FindElement(CartProductDelBtn).Click();
        }

        public void GoToPlaceOrder()
        {
            Driver.FindElement(PlaceOrderBtn).Click();
        }
        public bool PlaceOrderIsPresent()
        {
            return waitHandler.ElementIsPresent(Driver, PlaceOrderModal);
        }

        public void FillCCField(string ccNumber)
        {
            Driver.FindElement(CreditCardOrderInput).Clear();

            Driver.FindElement(CreditCardOrderInput).SendKeys(ccNumber);
        }

        public void FillOrderNameField(string name)
        {
            Driver.FindElement(NameOrderInput).Clear();
            Driver.FindElement(NameOrderInput).SendKeys(name);
        }

        public void BuyOrder()
        {
            Driver.FindElement(PurchaseOrderBtn).Click();
        }


        public string AlertMessage()
        {
            System.Threading.Thread.Sleep(650);
            var alert = Driver.SwitchTo().Alert();
            return alert.Text.ToString();
        }


        public void dismissAlert()
        {
            Driver.SwitchTo().Alert().Accept();
        }

        public bool PurchaseSuccesfulAlertIsPresent()
        {
            return waitHandler.ElementIsPresent(Driver, PurchaseSucessfulMessage);
        }
        public void dismissPurchaseAlert()
        {
            Driver.FindElement(PurchaseOkayBtn).Click();
        }
    }
}
