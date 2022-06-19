using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Xunit;

namespace UITest.StepDefinitions
{
    [Binding]
    public sealed class PausePlanSettingsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private bool DialogBoxTitle;
        private bool DialogBoxDescription;
        private bool PauseButton;
        private bool EndButton;
        private bool SaveButton;
        private bool PauseProgramTitle;
        private bool PauseProgramDescription;
        private bool PauseProgramButton;
        private bool PausedProgramLable;

        public PausePlanSettingsStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [When(@"The user clicks on the plan settings button")]
        public void WhenTheUserClicksOnThePlanSettingsButton()
        {
            try
            {
                Locators.MyPlanTimelineLocators.PlanSettingsButton(Hooks.HookInitialization.driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot click on plan settings");
            }
        }

        [Then(@"The fat burner beginner dialog box is displayed")]
        public void ThenTheFatBurnerBeginnerDialogBoxIsDisplayed()
        {
            
             //The user wait for the fat burner dialog box then check its elements
             try
             {
                 //wait
                 Locators.FatBurnerBeginnerDialoBoxLocators.WaitForFatBurnerDialogBox(Hooks.HookInitialization.driver);

                 //check dialog box title and description
                 DialogBoxTitle = Locators.FatBurnerBeginnerDialoBoxLocators
                    .FatBurnerDialogBoxTitle(Hooks.HookInitialization.driver).Displayed;

                    //fat burner dialog box title css assertion
                    Assert.Equal("rgba(240, 117, 128, 1)", Locators.FatBurnerBeginnerDialoBoxLocators
                        .FatBurnerDialogBoxTitle(Hooks.HookInitialization.driver).GetCssValue("color"));

                DialogBoxDescription = Locators.FatBurnerBeginnerDialoBoxLocators
                    .FatBurnerDialogBoxDescription(Hooks.HookInitialization.driver).Displayed;

                //check pause button
                PauseButton = Locators.FatBurnerBeginnerDialoBoxLocators
                    .FatBurnerPauseButton(Hooks.HookInitialization.driver).Displayed;

                    //pause button css assertion
                    Assert.Equal("rgba(85, 85, 85, 1)", Locators.FatBurnerBeginnerDialoBoxLocators
                        .FatBurnerPauseButton(Hooks.HookInitialization.driver).GetCssValue("color"));

                    Assert.Equal("rgba(0, 0, 0, 0)", Locators.FatBurnerBeginnerDialoBoxLocators
                        .FatBurnerPauseButton(Hooks.HookInitialization.driver).GetCssValue("background-color"));

                //check end button
                EndButton = Locators.FatBurnerBeginnerDialoBoxLocators
                    .FatBurnerEndButton(Hooks.HookInitialization.driver).Displayed;

                    //end button css assertion
                    Assert.Equal("rgba(255, 255, 255, 1)", Locators.FatBurnerBeginnerDialoBoxLocators
                        .FatBurnerEndButton(Hooks.HookInitialization.driver).GetCssValue("color"));

                    Assert.Equal("rgba(0, 0, 0, 0)", Locators.FatBurnerBeginnerDialoBoxLocators
                        .FatBurnerEndButton(Hooks.HookInitialization.driver).GetCssValue("background-color"));

                //check save button
                SaveButton = Locators.FatBurnerBeginnerDialoBoxLocators
                    .FatBurnerSaveButton(Hooks.HookInitialization.driver).Displayed;

                    //save button css assertion
                    Assert.Equal("rgba(136, 136, 136, 1)", Locators.FatBurnerBeginnerDialoBoxLocators
                        .FatBurnerSaveButton(Hooks.HookInitialization.driver).GetCssValue("color"));

                    Assert.Equal("rgba(0, 0, 0, 0)", Locators.FatBurnerBeginnerDialoBoxLocators
                        .FatBurnerSaveButton(Hooks.HookInitialization.driver).GetCssValue("background-color"));
            }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 throw new Exception("Fat burner dialog is not loaded correctly!");
             }
        }

        [When(@"The user clicks on the pause button")]
        public void WhenTheUserClicksOnThePauseButton()
        {
            try
            {
                Locators.FatBurnerBeginnerDialoBoxLocators.FatBurnerPauseButton(Hooks.HookInitialization.driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot click on pause button");
            }
        }

        [Then(@"The pause program form is displayed in the dialog box")]
        public void ThenThePauseProgramFormIsDisplayedInTheDialogBox()
        {
            //The user wait for the pause program? then check its elements
            try
            {
                //check elements
                PauseProgramTitle = Locators.FatBurnerBeginnerDialoBoxLocators
                   .PauseProgramDialogBoxTitle(Hooks.HookInitialization.driver).Displayed;

                PauseProgramDescription = Locators.FatBurnerBeginnerDialoBoxLocators
                    .PauseProgramDialogBoxDescription(Hooks.HookInitialization.driver).Displayed;

                PauseProgramButton = Locators.FatBurnerBeginnerDialoBoxLocators
                    .PauseProgramButton(Hooks.HookInitialization.driver).Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Pause program content is not loaded correctly!");
            }
        }

        [When(@"The user clicks on pause program button")]
        public void WhenTheUserClicksOnPauseProgramButton()
        {
            try
            {
                Locators.FatBurnerBeginnerDialoBoxLocators
                    .PauseProgramButton(Hooks.HookInitialization.driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Pause program content is clickable!");
            }
        }

        [Then(@"The program is paused")]
        public void ThenTheProgramIsPaused()
        {
            try
            {
                Locators.MyPlanTimelineLocators.WaitForMyPlanPage(Hooks.HookInitialization.driver);

                PausedProgramLable = Locators.MyPlanTimelineLocators
                    .PausedProgramLable(Hooks.HookInitialization.driver).Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The program did not paused!");
            }
        }
    }
}
