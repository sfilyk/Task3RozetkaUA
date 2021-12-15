using NUnit.Framework;
using PageObject;
using System.Collections;
using System.Xml.Linq;

namespace Tests
{
    [TestFixture]
    public class ProductSearchTest: BaseTest
    {
        //private const int _textSum = 100000;
        //private const string _searchProduct = "Ноутбуки";
        //private const string _searchFirm = "HP";

        [TestCaseSource("TestDataXml")]
        public void productToCartViaSearch(string searchProduct, string searchFirm, string textSum)
        {
            HomePage homePage = new(driver);
            homePage.ClickMenuCategoriesNetboock();
            SearchPage searchPage = new(driver);
            searchPage.searchText(searchProduct);
            searchPage.searchTextEnter();
            searchPage.searchLineFirm(searchFirm);
            searchPage.waitSearchLineTextClick();
            searchPage.searchLineTextClick();
            ProductPage productPage = new(driver);
            productPage.buttonChoiceByPric();
            productPage.buttonChoiceByPriceExpensive();
            productPage.waitButtonIconAddProductBay();
            productPage.buttonIconAddProductBay();
            productPage.buttonProductsInCart();
            ShoppingCartPage shoppingCartPage = new(driver);
            Assert.IsTrue(MyAssert.MyIsTrue(textSum, shoppingCartPage.textSumProductsInCart()), "don't incorect sum product in cart");
        }
        private static IEnumerable TestDataXml => GetBaseTestXml();
        private static IEnumerable GetBaseTestXml()
        {
            var doc = XDocument.Load(@"C:\Users\Serhii\Desktop\EpamWEBtest\Task3RozetkaUA\PageObject\TestData.xml");
            return
            from vars in doc.Descendants("vars")
            let searchProduct = vars.Attribute("searchProduct").Value
            let searchFirm = vars.Attribute("searchFirm").Value
            let textSum = vars.Attribute("textSum").Value
            select new object[] { searchProduct, searchFirm, textSum };
        }
    }
}