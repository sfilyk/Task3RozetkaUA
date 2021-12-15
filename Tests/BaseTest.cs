using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.Xml.Linq;

namespace Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;

        public static IEnumerable testDataXml => GetTestDataXml();
        private static IEnumerable GetTestDataXml()
        {
            var doc = XDocument.Load(@"C:\Users\Serhii\Desktop\EpamWEBtest\Task3RozetkaUA\PageObject\TestData.xml");
            return
            from testdata in doc.Descendants("testdata")
            let searchProduct = testdata.Attribute("searchProduct").Value
            let searchFirm = testdata.Attribute("searchFirm").Value
            let textSum = testdata.Attribute("textSum").Value
            select new object[] { searchProduct, searchFirm, textSum };
        }

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