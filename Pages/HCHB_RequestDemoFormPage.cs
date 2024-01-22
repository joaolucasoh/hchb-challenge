using System;
using Bogus;
using SampleCSharpConcept.BasePage;
using OpenQA.Selenium.Support.UI;
using SampleCSharpConcept.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.DevTools.V118.WebAuthn;


namespace SampleCSharpConcept.Pages

{
	public class HCHB_RequestDemoFormPage : BaseClass
	{
		// instance of webdriver
		public static IWebDriver driver;

		public HCHB_RequestDemoFormPage(IWebDriver driver)
		{
			HCHB_RequestDemoFormPage.driver = driver;
		}

        /* Page Objects
         */

        public static readonly By firstName = By.Id("74282_206772pi_74282_206772");
        public static readonly By lastName = By.Id("74282_206775pi_74282_206775");
        public static readonly By email = By.Id("74282_206778pi_74282_206778");
        public static readonly By phone = By.Id("74282_206781pi_74282_206781");
        public static readonly By role = By.Id("74282_206784pi_74282_206784");
        public static readonly By company = By.Id("74282_206787pi_74282_206787");
        public static readonly By city = By.Id("74282_206790pi_74282_206790");
        public static readonly By state = By.Id("74282_206793pi_74282_206793");
        public static readonly By census = By.Id("74282_206796pi_74282_206796");
        public static readonly By homeHealth = By.CssSelector("label[for='74282_206799pi_74282_206799_2893875']");

        public static readonly By submitButton = By.CssSelector("input[type='submit'][value='Submit']");

        public void selectState(string fillState)
        {
            new SelectElement(driver.FindElement(state)).SelectByText(fillState);
        }
		
        public void selectCensus(string fillCensus)
        {
            new SelectElement(driver.FindElement(census)).SelectByText(fillCensus);
        }

        public void selectRole(string fillRole)
        {
            new SelectElement(driver.FindElement(role)).SelectByText(fillRole);
        }

        public void fullOnlyRequiredFields()
        {
            switchingToIframe(By.ClassName("pardotform"));
            driver.FindElement(firstName).Click();
            driver.FindElement(firstName).SendKeys(Faker.Name.First());
            driver.FindElement(lastName).SendKeys(Faker.Name.Last());
            driver.FindElement(email).SendKeys(Faker.Internet.FreeEmail());
            driver.FindElement(phone).SendKeys(Faker.Phone.Number());
            Scroll("300");
            selectRole("Clinical");
            driver.FindElement(company).SendKeys(Faker.Company.Name());
            driver.FindElement(city).SendKeys(Faker.Country.Name());
            selectState("CT");
            Scroll("600");
            // ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 600)");
            selectCensus("501 - 1,000");
            Scroll("600");
            driver.FindElement(submitButton).Click();
            Scroll("500");
            driver.SwitchTo().DefaultContent();
        }

        public void checkErrorsMessages()
        {
            switchingToIframe(By.ClassName("pardotform"));
            //a. Please correct the errors below: header is displayed on top.
            Scroll("-600");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, -600)");
            string topErrorMsg = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(topErrorMsg, "Please correct the errors below:");
            
            //b. This field is required error displayed next to Services offered field.
            string servicesOfferOferredError = driver.FindElement(By.XPath("//p[contains(@class, 'error') and contains(text(), 'This field is required')]")).Text;
            Assert.AreEqual(servicesOfferOferredError, "This field is required");

            //c. Invalid CAPTCHA error displayed next to Captcha element.
            string invalidCaptchaErroMsg = driver.FindElement(By.XPath("//p[contains(@class, 'error') and contains(text(), 'Invalid CAPTCHA')]")).Text;
            Assert.AreEqual(invalidCaptchaErroMsg, "Invalid CAPTCHA");
            driver.SwitchTo().DefaultContent();
        }
	}
}
