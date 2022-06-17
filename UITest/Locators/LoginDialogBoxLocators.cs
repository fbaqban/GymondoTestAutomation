using OpenQA.Selenium;

namespace UITest.Locators
{
    public static class LoginDialogBoxLocators
    {
        public static IWebElement LogInDialogBox(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='login-modal-module--content--3In0j']/div[@class='modal-title-module--titleWrapper--FHYfi']"));
        }
        public static IWebElement Username(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='input-wrapper']/input[@id='mail']"));
        }
        public static IWebElement Password(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='input-wrapper']/input[@id='password']"));
        }
        public static IWebElement FinalLogInButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//button[@class='btn-gym btn--flex btn--fluid']"));
        }

        //wait section
        public static IWebElement WaitForLogInDialogBox(IWebDriver driver)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait =
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));

            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//form[@class='user-login-form']")));
        }
    }
}
