using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SampleCSharpConcept.Pages
{
	public class HCHBHomePage
	{
		// instance for webdriver
		public static IWebDriver driver;

		// constructor
		public HCHBHomePage(IWebDriver driver)
		{
			HCHBHomePage.driver = driver;
		}

		/* Page Objects
		 */

		public static readonly By requestDemoButton = By.CssSelector("[data-id='5b4438e7']");
		public static readonly By phoneLabel = By.CssSelector("[href='tel:8665354242'] .elementor-icon-list-text");
		public static readonly By emailLabel = By.CssSelector("[href='mailto:info@hchb.com'] .elementor-icon-list-text");


		public void ComparePhoneAndEmail(string phoneCompared, string emailCompared)
		{
			IWebElement el = driver.FindElement(phoneLabel);
			IWebElement elEmail = driver.FindElement(emailLabel);

			string phoneShown = el.Text;
			string emailShown = elEmail.Text;

			Assert.AreEqual(phoneShown, phoneCompared);
			Assert.AreEqual(emailShown, emailCompared);
		}

		public void ClickRequestDemoButton()
		{
			driver.FindElement(requestDemoButton).Click();
		}
	}
}