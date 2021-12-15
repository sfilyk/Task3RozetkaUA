using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://rozetka.com.ua");
            driver.Manage().Window.Maximize();
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}