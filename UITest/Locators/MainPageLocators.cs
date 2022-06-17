using OpenQA.Selenium;

namespace UITest.Locators
{
    public static class MainPageLocators
    {
        public static IWebElement AcceptCookiesButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='cookie-consent-module--content--CqleO']/button[@class='btn-gym btn--flex btn--medium cookie-consent-module--button--3SMgW']"));
        }
        public static IWebElement GotNewsButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//button[@class='btn-gym']/div[contains(text(),'Got it')]"));
        }
        public static IWebElement FirstLogInButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='login-button-module--wrapper--_Sndu']/button[@class='btn-gym btn--flex btn--small btn-gym--secondary']/div[@class='btn-gym__content'][1]"));
        }

        //wait section
        public static IWebElement WaitForGotNewsDialogBox(IWebDriver driver)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait =
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(40));

            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//button[@class='btn-gym']/div[contains(text(),'Got it')]")));
        }

    }
}
