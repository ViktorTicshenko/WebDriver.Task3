using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NetAutomation_WebDriverTask3
{
    public class BasePage(IWebDriver driver, string url)
    {
        protected readonly IWebDriver driver = driver;
        protected readonly string url = url;

        public void NavigateToPage()
        {
            if(url.Length > 0)
                driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Dealing with potential ad banners :( that cover up the elements
        /// </summary>
        public void ScrollDown(int byAmount = -1)
        {
            var windowSize = driver.Manage().Window.Size;

            new Actions(driver)
                .ScrollByAmount(0, (byAmount == -1) ? windowSize.Height : byAmount)
                .Perform();
        }
    }
}