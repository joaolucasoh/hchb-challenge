using System;

namespace SampleCSharpConcept.WebDriverExtensions
{
	public static class WebDriverExtensions
	{
		
		// Common methods or re-usable methods for page
		public static IWebDriver driver;

		public static void EnterText( this IWebDriver driver, By locator, string value)
		{
			IWebElement ele = driver.FindElement(locator);
			if (ele.Displayed && ele.Enabled) {
				ele.Clear();
				ele.SendKeys(value);
			}
		}

		public static void Click( this IWebDriver driver, By locator)
		{
			IWebElement ele = driver.FindElement(locator);
			if(ele.Displayed && ele.Enabled)
			{
				ele.Click();
			}
		}

		public static bool IsElementDisplayed(this IWebDriver driver, By locator)
		{
			IWebElement ele = driver.FindElement(locator);
			if(ele.Displayed)
			{
				return true;
			}
			return true;
		}

		public static string getText(this IWebDriver driver, By locator)
		{
			IWebElement ele = driver.FindElement(locator);
			var text = ""
;
			if (ele.Displayed)
			{
				text = ele.Text;
			}
			return text;
		}

		public static bool getTextWithValueDisplayed(this IWebDriver driver, string value)
		{
			var text = "";
			IWebElement ele = driver.FindElement(By.XPath("//*[text()='" + value + "']"));
			if (ele.Displayed)
			{
				return true;
			}
			return true;
		}

		public static void SelectTextByVisibleDropDown()
		{

		}
	}
}
