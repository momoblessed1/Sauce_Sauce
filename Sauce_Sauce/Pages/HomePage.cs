using OpenQA.Selenium;


namespace Sauce_Sauce.Pages
{
	public class HomePage
	{
		IWebDriver driver;
		public HomePage (IWebDriver Driver)
	{
		driver = Driver;
        
}

	IWebElement uName => driver.FindElement(By.Id("user-name"));
	IWebElement pWord => driver.FindElement(By.Id("password"));
	IWebElement login => driver.FindElement(By.Id("login-button"));

	public void NavigateToSite(string url)
	{
		driver.Navigate().GoToUrl(url);
		
	}

		public void EnterUserName(string userName)
		{
			uName.SendKeys(userName);
		}

		public void EnterPassword(string password)
		{
			pWord.SendKeys(password);
		}

		public void ClickLogin()
		{
			login.Click();
		}

	}
}
