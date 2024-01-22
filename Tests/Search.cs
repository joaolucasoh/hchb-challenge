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
            googlehomePage.FillInputSearch("Selenium HQ");
            googlehomePage.SubmitSearch();
            googlehomePage.FillInputSearch(Keys.Enter);

            WaitElement(GoogleHomePage.inputSearch);
            googlehomePage.ClearInputSearch();
            googlehomePage.FillInputSearch("HCHB");
            googlehomePage.FillInputSearch(Keys.Enter);

            // Verify if hchb.com is on the 2nd row
            WaitElement(By.CssSelector("h3"));
            var results = driver.FindElements(By.CssSelector("h3"));
            Assert.IsTrue(results[2].Text.Contains("Home Care Software Designed By Nurses for Nurses"), "hchb.com not found in the second row.");

            // Go through home page and check email and phone
            results[2].Click();
            WaitElement(HCHBHomePage.emailLabel);
            hchbHomePage.ComparePhoneAndEmail("866-535-4242", "info@hchb.com");
            
            //clicking in request demo
            hchbHomePage.ClickRequestDemoButton();

            //checking url
            CheckAndCompareCurrentUrl("https://hchb.com/request-demo/");
            
            // scroll until make the whole form visible
            Scroll("500");

            //fill up the mandatory fields
            hchbRequestDemoPage.FullOnlyRequiredFields();

            //check the error messages
            hchbRequestDemoPage.CheckErrorsMessages();
        }
    }
}

