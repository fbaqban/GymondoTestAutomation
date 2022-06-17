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

        //after pause a program elements
        public static IWebElement PausedProgramLable(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='progress-circle__description']/div[contains(text(),'Paused')]"));
        }

        //logout section
        public static IWebElement UserProfileMenu(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='header_menuItem__Yuxa+ user-dropdown_wrapper__opc1Y']/img[@class='user-dropdown_userImg__Re66m']"));
        }

        public static IWebElement LogOutItem(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//li[@class='user-actions_logoutItem__8fx2t']/div[contains(text(),'Log out')]"));
        }


        //wait section
        public static IWebElement WaitForMyPlanPage(IWebDriver driver)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait =
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(60));

            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By
                    .XPath("//div[@class='header_greeting__B-XLP']")));
        }

    }
}
