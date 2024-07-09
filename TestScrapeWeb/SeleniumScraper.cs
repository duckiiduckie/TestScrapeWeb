using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScrapeWeb
{
    public class SeleniumScraper
    {
        public static string LoginAndGetPageSource(string url, string email, string password)
        {
            var options = new ChromeOptions();
            /* options.AddArgument("headless");*/
            IWebDriver driver = new ChromeDriver(options);

            try
            {
                driver.Navigate().GoToUrl("https://www.facebook.com/login");

                var emailField = driver.FindElement(By.Id("email"));
                var passwordField = driver.FindElement(By.Id("pass"));
                var loginButton = driver.FindElement(By.Name("login"));

                emailField.SendKeys(email);
                passwordField.SendKeys(password);
                loginButton.Click();

                Thread.Sleep(5000); 

                driver.Navigate().GoToUrl(url);

                Thread.Sleep(5000); 

                for (int i = 0; i < 1000; i++) 
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                    Thread.Sleep(3000); 
                }

                return driver.PageSource;
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
