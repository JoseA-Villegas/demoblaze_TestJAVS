using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using demoBlazeAutomation_JAVS.PageObject;
using System.IO;
using System;

namespace demoBlazeAutomation_JAVS
{
    public class ProductsTest : BaseTest
    {


        [TestCase("distilleryTest1", "Test123")]
        public void ValidateProductsAreShown(string username, string password)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
        }

        [TestCase("distilleryTest1", "Test123", 7, 2, 6)]
        public void ValidateProductsAreShownByCategory(string username, string password,int phoneProducts, int monitorProducts, int laptopProducts)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            homepage.FilterCategorybyPhones();
            Assert.AreEqual(phoneProducts, homepage.ProductsPresent());
            homepage.FilterCategorybyMonitors();
            Assert.AreEqual(monitorProducts, homepage.ProductsPresent());
            homepage.FilterCategorybyLaptops();
            Assert.AreEqual(laptopProducts, homepage.ProductsPresent());
        }

        [TestCase("distilleryTest1", "Test123", 7, 2, 6)]
        public void ProductsNavigateNextPage(string username, string password, int phoneProducts, int monitorProducts, int laptopProducts)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            homepage.GoToNextProductPage();
            Assert.AreEqual(6, homepage.ProductsPresent());
        }

        [TestCase("distilleryTest1", "Test123", 9, 6)]
        public void ProductsNavigatePreviousPage(string username, string password, int firstProducts, int secondPageProducts)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            homepage.GoToNextProductPage();
            Assert.AreEqual(secondPageProducts, homepage.ProductsPresent());
            homepage.GoToPreviousProductPage();
            Assert.AreEqual(firstProducts, homepage.ProductsPresent());
        }

        [TestCase("distilleryTest1", "Test123", "HTC One M9")]
        public void NavigateToProductDetails(string username, string password, string productName)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            homepage.GoToProductDetail(productName);
        }

        [TestCase("distilleryTest1", "Test123", "HTC One M9", "$700", "The HTC One M9 is powered by 1.5GHz octa-core Qualcomm Snapdragon 810 processor and it comes with 3GB of RAM. The phone packs 32GB of internal storage that can be expanded up to 128GB via a microSD card.")]
        public void ValidateProductDetails(string username, string password, string productName, string productPrice, string productDescription)
        {
            HomePage homepage = new HomePage(Driver);
            homepage.GoToLogin();
            homepage.FillLoginForm(username, password);
            homepage.SubmitLogin();
            Assert.AreEqual("Welcome " + username, homepage.IsLoggedIn());
            Assert.IsTrue(homepage.ProductsIsPresent());
            ProductDetailPage prodDetailPage = homepage.GoToProductDetail(productName);
            Assert.AreEqual(productName, prodDetailPage.ProductTitleText());
            Assert.AreEqual(productPrice + " *includes tax", prodDetailPage.ProductPriceText());
            Assert.AreEqual(productDescription, prodDetailPage.ProductDescriptionText());
        }


    }
}
