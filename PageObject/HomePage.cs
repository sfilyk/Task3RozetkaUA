using OpenQA.Selenium;

namespace PageObject
{
   public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        private readonly By _menuCategoriesNetboock = By.CssSelector("sidebar-fat-menu li:nth-child(1)");

        public void ClickMenuCategoriesNetboock() => driver.FindElement(_menuCategoriesNetboock).Click();

    }
}
