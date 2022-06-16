using OpenQA.Selenium;

namespace UITest.Locators
{
    public static class MainPageLocators
    {
        public static IWebElement FirstLogInButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='login-button-module--wrapper--_Sndu']/button[@class='btn-gym btn--flex btn--small btn-gym--secondary']/div[@class='btn-gym__content'][1]"));
        }
    }
}
