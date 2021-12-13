using OpenQA.Selenium;
using System;

namespace PageObject
{
    public class ProductPage: BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        private readonly By _buttonChoiceByPrice = By.CssSelector("select[_ngcontent-rz-client-c42='']");
        private readonly By _buttonChoiceByPriceExpensive = By.CssSelector("select[_ngcontent-rz-client-c42=''] option[value='2: expensive']");
        private readonly By _buttonIconAddProductBay = By.XPath("//*[@class ='toOrder ng-star-inserted']");
        private readonly By _buttonProductsInCart = By.XPath("//button[@class ='header__button ng-star-inserted header__button--active']");
       
        public void buttonChoiceByPric() => driver.FindElement(_buttonChoiceByPrice, 300).Click();
        public void buttonChoiceByPriceExpensive() => driver.FindElement(_buttonChoiceByPriceExpensive, 300).Click();
        public void buttonIconAddProductBay() => driver.FindElement(_buttonIconAddProductBay, 300).Click();
        public void waitButtonIconAddProductBay() => waitforelement(driver, _buttonIconAddProductBay);
        public void buttonProductsInCart() => driver.FindElement(_buttonProductsInCart, 300).Click();
    }
}
