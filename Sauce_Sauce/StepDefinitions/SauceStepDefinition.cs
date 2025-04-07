using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using Sauce_Sauce.Pages;

using TechTalk.SpecFlow;

namespace Sauce_Sauce.StepDefinitions
{
	[Binding]
	public class SauceStepDefinition
	{
		IWebDriver driver;
		HomePage homePage;
		ItemsPage itemsPage;
		string url = "https://www.saucedemo.com/";
		

		public SauceStepDefinition(IObjectContainer _container)
		{
			driver = _container.Resolve<IWebDriver>();
			homePage = _container.Resolve<HomePage>();
			itemsPage= _container.Resolve<ItemsPage>();
			
		}

		[Given(@"user is on sauce url")]
		public void GivenUserIsOnSauceurl()
		{
			homePage.NavigateToSite(url);
		}

		[Given(@"user login with the following credentials")]
		public void GivenUserLoginWithTheFollowingcredentials(Table table)
		{
			
			homePage.EnterUserName(table.Rows[0]["userName"]);
			homePage.EnterPassword(table.Rows[0]["password"]);
            homePage.ClickLogin();

		}

	[When(@"user select the option '(highest|lowest|any|second)' price item and add to shopping basket")]
		public void WhenUserSelectTheOptionPriceItemAndAddToCart(string option)
		{
			itemsPage.AddHighestPriceToBag(option);
		}

	}
}