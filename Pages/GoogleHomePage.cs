using System;
using SampleCSharpConcept.BasePage;
using SampleCSharpConcept.Pages;

namespace SampleCSharpConcept.Page
{
	public class GoogleHomePage : BaseClass
	{
		// instance of webdriver
		public static IWebDriver driver;

		public GoogleHomePage(IWebDriver driver)
		{
			GoogleHomePage.driver = driver;
		}

		/* Page Objects
         */

		public static readonly By inputSearch = By.TagName("textarea");
		public static readonly By submitButton = By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[1]");

		public void FillInputSearch(string text)
		{
			driver.FindElement(inputSearch).SendKeys(text);
		}

		public void ClearInputSearch()
		{
			driver.FindElement(inputSearch).Clear();
		}

		public void SubmitSearch()
		{
			driver.FindElement(submitButton).Click();
		}
	}
}