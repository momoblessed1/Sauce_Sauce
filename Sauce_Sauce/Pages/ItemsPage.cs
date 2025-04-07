using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sauce_Sauce.Pages
{
	public class ItemsPage
	{
		IWebDriver driver;
		public ItemsPage(IWebDriver Driver)
		{
			driver = Driver;
		}

		IList<IWebElement> itemPrice => driver.FindElements(By.XPath("//div[@data-test='inventory-item-price']"));
		IWebElement itemButton(decimal num) =>
			driver.FindElement(By.XPath($"//div[text()='{num}']//following-sibling::button"));
		IWebElement itemCount => driver.FindElement(By.CssSelector("[data-test='shopping-cart-badge']"));

		IWebElement itemLabel(string text) => driver.FindElement(By.XPath($"//div[text()='{text}']"));


       public void AddHighestPriceToBag(string option)
		{
			

           List<decimal> num = itemPrice
	      .Where(price => !string.IsNullOrEmpty(price.Text))
	      .Select(price => Convert.ToDecimal(Regex.Replace(price.Text, @"[^\d.]", "")))
	      .ToList();

				if (num.Any())
				{
					// Map option to corresponding index or logic
					var optionMap = new Dictionary<string, Func<List<decimal>, decimal>>
	{
		{ "highest", list => list.Max() },
		{ "lowest", list => list.Min() },
		{ "second", list => list.ElementAtOrDefault(1) },
		{ "third", list => list.ElementAtOrDefault(2) },
		{ "fourth", list => list.ElementAtOrDefault(3) },
		{ "last", list => list.LastOrDefault() }
	};

					// Get the chosen number based on the option
					var choice = optionMap.ContainsKey(option) ? optionMap[option](num) : num.LastOrDefault();

					// Click the corresponding button
					itemButton(choice).Click();
				}
		}

		 public void AddAnyItemToBagag(decimal value)
		{
			itemButton(value).Click();
		}
    public string BagCount() => itemCount.Text;

	
	}
}