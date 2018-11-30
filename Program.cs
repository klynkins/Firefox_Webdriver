using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firefox_Webdriver
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://login.yahoo.com/?.src=finance&.intl=us&authMechanism=primary&done=https%3A%2F%2Ffinance.yahoo.com%2Fscreener%2Fpredefined&eid=100&add=1";

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);

            driver.FindElement(By.Id("login-username")).SendKeys("" + Keys.Enter);
            driver.FindElement(By.Id("login-passwd")).SendKeys("" + Keys.Enter);

            driver.FindElement(By.XPath("//a[contains(text(), 'My Portfolio')]")).Click();
            driver.FindElement(By.XPath("//*[@id='main']/section/section/div[2]/table/tbody/tr[2]/td[1]/a")).Click();

            IList<IWebElement> stockNames = driver.FindElements(By.ClassName("_61PYt"));
            IList<IWebElement> lastPrice = driver.FindElements(By.ClassName("aVPt9 Ylni0"));
            IList<IWebElement> currency = driver.FindElements(By.ClassName("_61PYt"));

            Console.WriteLine("Info on stocks in Katelynn's Portfolio: " + stockNames.Count);

            for (int i = 0; i < stockNames.Count; i++)
            {
                Console.WriteLine(stockNames[i].Text);
                Console.WriteLine(lastPrice[i]);
                Console.WriteLine(currency[i].Text);
            }

            Console.WriteLine("\n");

            driver.Close();
        }
    }
}
