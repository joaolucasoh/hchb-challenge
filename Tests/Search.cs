using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using SampleCSharpConcept.BasePage;
using SampleCSharpConcept.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SampleCSharpConcept.Page;

namespace SampleCSharpConcept.Tests
{
    [TestClass]
    public class SearchTest : BaseClass
    {
        private GoogleHomePage googlehomePage;
        private HCHBHomePage hchbHomePage;
        private HCHB_RequestDemoFormPage hchbRequestDemoPage;

        [TestMethod]
        public void TestGoogleSearchForSeleniumHQ()
        {
            googlehomePage = new GoogleHomePage(driver);
            hchbHomePage = new HCHBHomePage(driver);
            hchbRequestDemoPage = new HCHB_RequestDemoFormPage(driver);

            // First wait for the elements be visible
            WaitElement(GoogleHomePage.inputSearch);

            // fill the input
            googlehomePage.fillInputSearch("Selenium HQ");
            googlehomePage.submitSearch();
            googlehomePage.fillInputSearch(Keys.Enter);

            WaitElement(GoogleHomePage.inputSearch);
            googlehomePage.clearInputSearch();
            googlehomePage.fillInputSearch("HCHB");
            googlehomePage.fillInputSearch(Keys.Enter);

            // Verify if hchb.com is on the 2nd row
            WaitElement(By.CssSelector("h3"));
            var results = driver.FindElements(By.CssSelector("h3"));
            Assert.IsTrue(results[2].Text.Contains("Home Care Software Designed By Nurses for Nurses"), "hchb.com not found in the second row.");

            // Go through home page and check email and phone
            results[2].Click();
            WaitElement(HCHBHomePage.emailLabel);

            hchbHomePage.comparePhoneAndEmail("866-535-4242", "info@hchb.com");
            
            //clicking in request demo
            hchbHomePage.ClickRequestDemoButton();

            //checking url
            
            
            // scroll until make the whole form visible
            Scroll("500");
            // ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 500)");

            //fill up the mandatory fields
            hchbRequestDemoPage.fullOnlyRequiredFields();

            //check the error messages
            hchbRequestDemoPage.checkErrorsMessages();
        }
    }
}

