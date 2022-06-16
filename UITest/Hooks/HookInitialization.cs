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

        [BeforeScenario(Order = 3)]
        public void EnterLoginData()
        {
            //The user login with given username and password
            try
            {
                //wait
                Locators.LoginDialogBoxLocators.WaitForLogInDialogBox(driver);
                
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

        [BeforeScenario(Order = 4)]
        public void ClickFinalLogInbutton()
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

        [BeforeScenario(Order = 5)]
        public void WaitForHomePageToBeDisplayed()
        {
            //The user wait for the home page after login
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

    }
}
