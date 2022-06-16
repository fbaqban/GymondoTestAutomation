using OpenQA.Selenium;

namespace UITest.Locators
{
    public static class MyPlanTimelineLocators
    {
        public static IWebElement PlanSettingsButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//button[@class='btn-gym btn--flex btn--medium btn--border plan-settings-button_button__1npuE']/div[@class='btn-gym__content']"));
        }
        
        //wait section
        public static IWebElement WaitForMyPlanPage(IWebDriver driver)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait =
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));

            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By
                    .XPath("//div[@class='header_greeting__B-XLP']/h1[contains(text(),'Good afternoon, Test!')]")));
        }
    }
}
