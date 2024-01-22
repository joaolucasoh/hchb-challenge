using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SampleCSharpConcept.Pages;

namespace SampleCSharpConcept.BasePage
{
    /*
     *  Initialize the driver - Setup Driver
     *  Re-usable methods
     */

	public class BaseClass
	{
        //creating an instance for WebDriver and navigating
        public static IWebDriver driver;
        public static WebDriverWait wait;

        [TestInitialize]
        public void init()
        {
            string siteUrl = "https://google.com";

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(siteUrl);
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }

        public void WaitElement(By selector)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
        }

        public void switchingToIframe(By selector)
        {
            IWebElement iframeElement = driver.FindElement(selector);
            driver.SwitchTo().Frame(iframeElement);
        }
        public void Scroll(string verticalDirection) 
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollBy(0, {verticalDirection}");
        }

	}
}

