using OpenQA.Selenium;

namespace UITest.Locators
{
    public static class FatBurnerBeginnerDialoBoxLocators
    {
        public static IWebElement CloseFatBurnerDialogBoxButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='modal_closeWrapper__BBoXJ']"));
        }

        public static IWebElement FatBurnerDialogBoxTitle(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='program-training-settings_programWrapper__lHq6H']/div[contains(text(),'Fat Burner Beginner')]"));
        }
        public static IWebElement FatBurnerDialogBoxDescription(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class=('program-training-settings_programWrapper__lHq6H')]/p[contains(text(),'You can change your workout days here. For this program, we recommend ')]"));
        }

        public static IWebElement FatBurnerPauseButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[contains(text(),'Pause')]"));
        }

        public static IWebElement FatBurnerEndButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[contains(text(),'End')]"));
        }

        public static IWebElement FatBurnerSaveButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[contains(text(),'Save')]"));
        }

        //Pause program? locators section
        public static IWebElement PauseProgramDialogBoxTitle(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[@class='settings-confirmation_content__7cvIH']/div[contains(text(),'Pause Program?')]"));
        }
        public static IWebElement PauseProgramDialogBoxDescription(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[contains(text(),'We’ll stop scheduling your upcoming workouts for this program. You can always restart by visiting your Program Settings menu.')]"));
        }

        public static IWebElement PauseProgramButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[contains(text(),'Pause program')]"));
        }

        //Paused program locators section
        public static IWebElement ResumeProgramButton(IWebDriver driver)
        {
            return driver.FindElement(By
                .XPath("//div[contains(text(),'Resume program')]"));
        }

        //wait section
        public static IWebElement WaitForFatBurnerDialogBox(IWebDriver driver)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait =
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(60));

            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By
                    .XPath("//div[@role='dialog']")));
        }
    }
}
