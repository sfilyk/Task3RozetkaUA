using OpenQA.Selenium;

namespace PageObject
{
    public class ShoppingCartPage:BasePage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver) { }

        private readonly By _textSumProductsInCart = By.XPath("//div[@class ='cart-receipt__sum-price']//span[contains(@class,'')]");

        public string textSumProductsInCart() => driver.FindElement(_textSumProductsInCart,60).Text;
    }
}
