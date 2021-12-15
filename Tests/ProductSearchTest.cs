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

        [TestCaseSource("testDataXml")]
        public void productToCartViaSearch(string _searchProduct, string _searchFirm, string _textSum)
        {
            HomePage homePage = new(driver);
            homePage.ClickMenuCategoriesNetboock();
            SearchPage searchPage = new(driver);
            searchPage.searchText(_searchProduct);
            searchPage.searchTextEnter();
            searchPage.searchLineFirm(_searchFirm);
            searchPage.waitSearchLineTextClick();
            searchPage.searchLineTextClick();
            ProductPage productPage = new(driver);
            productPage.buttonChoiceByPric();
            productPage.buttonChoiceByPriceExpensive();
            productPage.waitButtonIconAddProductBay();
            productPage.buttonIconAddProductBay();
            productPage.buttonProductsInCart();
            ShoppingCartPage shoppingCartPage = new(driver);
            Assert.IsTrue(MyAssert.MyIsTrue(_textSum, shoppingCartPage.textSumProductsInCart()), "don't incorect sum product in cart");
        }        
    }
}