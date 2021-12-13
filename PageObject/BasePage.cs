using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObject
{
    public class BasePage
    {
        protected static IWebDriver driver;
        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public static bool elexists(By by, IWebDriver driver)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static void waitforelement(IWebDriver driver, By by)
        {
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(1000);
                if (elexists(by, driver))
                {
                    break;
                }
            }
        }

    }
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

    }
    public static class MyAssert
    {
        public static bool MyIsTrue(int first, string second)
        {
            string numericString = "";
            foreach (char c in second)
            {
                if ((c >= '0' && c <= '9') || c == ' ' || c == '-')
                {
                    numericString = String.Concat(numericString, c);
                }
                else
                    break;
            }
            if (first < Convert.ToInt32(numericString))
            {
                return true;
            }
            else
                return false;
        }
    }

}