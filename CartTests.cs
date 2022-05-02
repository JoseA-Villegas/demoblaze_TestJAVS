using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using demoBlazeAutomation_JAVS.PageObject;
using System.IO;
using System;

namespace demoBlazeAutomation_JAVS
{
    public class CartTests : BaseTest
    {

        [TestCase("distilleryTest1", "Test123", "HTC One M9", "Product added.")]
        public void AddProductToCart(string username, string password, string productName, string alertMessage)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            ProductDetailPage prodDetailPage = homepage.GoToProductDetail(productName);
            Assert.AreEqual(productName, prodDetailPage.ProductTitleText());
            prodDetailPage.AddProductToCart();
            Assert.AreEqual(alertMessage, prodDetailPage.AlertMessage());
            prodDetailPage.dismissAlert();
        }

        [TestCase("distilleryTest2", "Test123", "HTC One M9", "Product added.", "ASUS Full HD")]
        public void AddProductsToCart(string username, string password, string productName, string alertMessage, string productName2)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            ProductDetailPage prodDetailPage = homepage.GoToProductDetail(productName);
            Assert.AreEqual(productName, prodDetailPage.ProductTitleText());
            prodDetailPage.AddProductToCart();
            Assert.AreEqual(alertMessage, prodDetailPage.AlertMessage());
            prodDetailPage.dismissAlert();
            homepage = prodDetailPage.GoToHomePage();

            Assert.IsTrue(homepage.ProductsIsPresent());
            homepage.FilterCategorybyMonitors();
            Assert.AreEqual(2, homepage.ProductsPresent());
            prodDetailPage = homepage.GoToProductDetail(productName2);
            Assert.AreEqual(productName2, prodDetailPage.ProductTitleText());
            prodDetailPage.AddProductToCart();
            Assert.AreEqual(alertMessage, prodDetailPage.AlertMessage());
            prodDetailPage.dismissAlert();
        }

        [TestCase("distilleryTest1", "Test123", "HTC One M9", "Product added.")]
        public void DeleteProductFromCart(string username, string password, string productName, string alertMessage)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            ProductDetailPage prodDetailPage = homepage.GoToProductDetail(productName);
            Assert.AreEqual(productName, prodDetailPage.ProductTitleText());
            prodDetailPage.AddProductToCart();
            Assert.AreEqual(alertMessage, prodDetailPage.AlertMessage());
            prodDetailPage.dismissAlert();
            CartPage cartpage = prodDetailPage.GoToCart();
            cartpage.DeleteProduct();
        }

        [TestCase("distilleryTest1", "Test123", "HTC One M9", "Product added.")]
        public void GoToPlaceOrder(string username, string password, string productName, string alertMessage)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            ProductDetailPage prodDetailPage = homepage.GoToProductDetail(productName);
            Assert.AreEqual(productName, prodDetailPage.ProductTitleText());
            prodDetailPage.AddProductToCart();
            Assert.AreEqual(alertMessage, prodDetailPage.AlertMessage());
            prodDetailPage.dismissAlert();
            CartPage cartpage = prodDetailPage.GoToCart();
            cartpage.GoToPlaceOrder();
            Assert.IsTrue(cartpage.PlaceOrderIsPresent());
        }


        [TestCase("distilleryTest1", "Test123", "HTC One M9", "Product added.", "1234567890")]
        public void ValidatePaymentFields(string username, string password, string productName, string alertMessage, string creditCard)
        {

            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            ProductDetailPage prodDetailPage = homepage.GoToProductDetail(productName);
            Assert.AreEqual(productName, prodDetailPage.ProductTitleText());
            prodDetailPage.AddProductToCart();
            Assert.AreEqual(alertMessage, prodDetailPage.AlertMessage());
            prodDetailPage.dismissAlert();
            CartPage cartpage = prodDetailPage.GoToCart();
            cartpage.GoToPlaceOrder();
            Assert.IsTrue(cartpage.PlaceOrderIsPresent());

            cartpage.FillCCField(creditCard);
            cartpage.BuyOrder();
            Assert.AreEqual("Please fill out Name and Creditcard.", cartpage.AlertMessage());
            prodDetailPage.dismissAlert();
            cartpage.FillCCField("");
            cartpage.FillOrderNameField("testname");
            cartpage.BuyOrder();
            Assert.AreEqual("Please fill out Name and Creditcard.", cartpage.AlertMessage());
            prodDetailPage.dismissAlert();

        }

        [TestCase("distilleryTest1", "Test123", "HTC One M9", "Product added.", "1234567890")]
        public void SucessfulPurchase(string username, string password, string productName, string alertMessage, string creditCard)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            ProductDetailPage prodDetailPage = homepage.GoToProductDetail(productName);
            Assert.AreEqual(productName, prodDetailPage.ProductTitleText());
            prodDetailPage.AddProductToCart();
            Assert.AreEqual(alertMessage, prodDetailPage.AlertMessage());
            prodDetailPage.dismissAlert();
            CartPage cartpage = prodDetailPage.GoToCart();
            cartpage.GoToPlaceOrder();
            Assert.IsTrue(cartpage.PlaceOrderIsPresent());

            cartpage.FillCCField(creditCard);
            cartpage.BuyOrder();
            Assert.AreEqual("Please fill out Name and Creditcard.", cartpage.AlertMessage());
            prodDetailPage.dismissAlert();
            cartpage.FillOrderNameField("testname");
            cartpage.BuyOrder();
            Assert.IsTrue(cartpage.PurchaseSuccesfulAlertIsPresent());
            cartpage.dismissPurchaseAlert();

        }

    }
}
