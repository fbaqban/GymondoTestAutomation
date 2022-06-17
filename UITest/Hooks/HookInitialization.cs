using UITest.Drivers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Xunit;

namespace UITest.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        public static IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        private bool DialogBoxTitle;
        private bool DialogBoxDescription;
        private bool PausedProgramLable;

        public HookInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario(Order = 0)]
        public void CreateADriver()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [BeforeScenario(Order = 1)]
        public void NavigateTheUrl()
        {
            //The user opens the browser and launch the application
            try
            {
                driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
                driver.Url = "https://gymondo.com/";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The web page is not reachable", e);
            }
        }

        [BeforeScenario(Order = 2)]
        public void ClickAcceptCookiesButton()
        {
            //The user clicks on the first log in button in order to open the login form
            try
            {
                    Locators.MainPageLocators.AcceptCookiesButton(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The LOG IN button does not found!");
            }
        }

        [BeforeScenario(Order = 3)]
        public void ClickFirstSignInButton()
        {
            //The user clicks on the first log in button in order to open the login form
            try
            {
                if (Locators.MainPageLocators.FirstLogInButton(driver).Displayed)
                    Locators.MainPageLocators.FirstLogInButton(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The LOG IN button does not found!");
            }
        }

        [BeforeScenario(Order = 4)]
        public void EnterLoginData()
        {
            //The user login with given username and password
            try
            {
                //insert user and password
                Locators.LoginDialogBoxLocators.Username(driver).SendKeys("qa-prod1@gymondo.de");
                Locators.LoginDialogBoxLocators.Password(driver).SendKeys("purpleSquid22!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot insert inputs");
            }
        }

        [BeforeScenario(Order = 5)]
        public void ClickFinalLogInButton()
        {
            //The user log in
            try
            {
                Locators.LoginDialogBoxLocators.FinalLogInButton(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot login to gymondo.com");
            }
        }

        [BeforeScenario(Order = 6)]
        public void WaitForGotNewsDialogToBeDisplayed()
        {
            //The user wait for the got news dialog box after login
            try
            {
                //wait
                Locators.MainPageLocators.WaitForGotNewsDialogBox(driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Home page is not displayed!");
            }
        }

        [BeforeScenario(Order = 7)]
        public void ClickGotNewsButton()
        {
            //The user accept got news
            try
            {
                Locators.MainPageLocators.GotNewsButton(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot accept got news button!");
            }
        }

        [BeforeScenario(Order = 8)]
        public void WaitForHomePageToBeDisplayed()
        {
            //The user wait for the home page after accept got news
            try
            {
                //wait
                Locators.MyPlanTimelineLocators.WaitForMyPlanPage(driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Home page is not displayed!");
            }
        }

        [BeforeScenario(Order = 9)]
        public void ChangeStatusFromResumeToPause()
        {
            string xpathPauseLable = "//div[@class='progress-circle__description']/div[contains(text(),'Paused')]";

            //The user resume the program 
            try
            {
                if (driver.FindElements(By.XPath(xpathPauseLable)).Count!=0)
                {

                Locators.MyPlanTimelineLocators.PlanSettingsButton(Hooks.HookInitialization.driver).Click();

                //wait
                Locators.FatBurnerBeginnerDialoBoxLocators.WaitForFatBurnerDialogBox(Hooks.HookInitialization.driver);

                //check elements
                DialogBoxTitle = Locators.FatBurnerBeginnerDialoBoxLocators
                   .FatBurnerDialogBoxTitle(Hooks.HookInitialization.driver).Displayed;

                DialogBoxDescription = Locators.FatBurnerBeginnerDialoBoxLocators
                    .FatBurnerDialogBoxDescription(Hooks.HookInitialization.driver).Displayed;
                //click on resume button
                Locators.FatBurnerBeginnerDialoBoxLocators
                    .ResumeProgramButton(Hooks.HookInitialization.driver).Click();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Previous public spaces could not remove!");
            }
        }


        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                //logout
                Locators.MyPlanTimelineLocators.UserProfileMenu(driver).Click();

                Locators.MyPlanTimelineLocators.LogOutItem(driver).Click();

                //quit browser
                Console.WriteLine("Selenium webdriver quit");
                _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Test closure has problem!");
            }
        }

    }
}
