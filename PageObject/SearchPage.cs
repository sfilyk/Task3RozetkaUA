using OpenQA.Selenium;

namespace PageObject
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver) { }

        private readonly By _fieldSearch = By.Name("search");
        private readonly By _searchLineFirm = By.Name("searchline");
        private readonly By _searchLineFirmClick = By.CssSelector("div:nth-child(3)  rz-filter-section-autocomplete > ul:nth-child(2) > li > a");
       
        public void searchText(string text) => driver.FindElement(_fieldSearch).SendKeys(text);
        public void searchTextEnter() => driver.FindElement(_fieldSearch).SendKeys(Keys.Enter);
        public void searchLineFirm(string text) => driver.FindElement(_searchLineFirm).SendKeys(text);
        public void searchLineTextClick() => driver.FindElement(_searchLineFirmClick,600).Click();
        public void waitSearchLineTextClick() => waitforelement(driver,_searchLineFirmClick);

    }
}
