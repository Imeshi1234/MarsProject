using MarsProject.Pages;
using MarsProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinition : CommonDriver
    {

        LoginPage _loginPage = new LoginPage();
        HomePage homeObj = new HomePage();
        LanguagePage _languagePage = new LanguagePage();

        [Given(@"user logs into Mars Portal with email ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenUserLogsIntoMarsPortalWithEmailAndPassword(string email, string password)
        {
            driver = new ChromeDriver();
            _loginPage.LoginActions(driver);
            _loginPage.ClickSignInButton(driver);
            _loginPage.EnterLoginCredentials(driver, "anuttara1989@gmail.com", "d@.u53M6U!BCCk");
            _loginPage.ClickLoginButton(driver);
        }



        [Given(@"user navigates to Language section")]
        public void GivenUserNavigatesToLanguageSection()
        {
            homeObj.selectLanguageOption(driver);
        }

        [Given(@"user needs to clear all the previous records")]
        public void GivenUserNeedsToClearAllThePreviousRecords()
        {
            _languagePage.ClearAllPreviousAddedLanguage(driver);
        }

        [When(@"user adds a new language record with language ""([^""]*)"" and level ""([^""]*)""")]
        public void WhenUserAddsANewLanguageRecordWithLanguageAndLevel(string language, string level)
        {
            _languagePage.CreateNewLanguageRecord(driver,language, level);

        }
        [Then(@"Mars portal should save the new added language record")]
        public void ThenMarsPortalShouldSaveTheNewAddedLanguageRecord()
        {
             _languagePage.VerifyAddedLanguageRecord(driver,"English");
        }

        [Given(@"user adds a new language record with language ""([^""]*)"" and level ""([^""]*)""")]
        public void GivenUserAddsANewLanguageRecordWithLanguageAndLevel(string language, string level)
        {
            _languagePage.CreateNewLanguageRecord(driver, language, level);
        }

        [When(@"user edits the language record with language ""([^""]*)"" and level ""([^""]*)""")]
        public void WhenUserEditsTheLanguageRecordWithLanguageAndLevel(string language, string newLevel)
        {

            _languagePage.UpdateNewLanguageRecord(driver, language, newLevel);
        }

        [Then(@"Mars portal should save the edited language record")]
        public void ThenMarsPortalShouldSaveTheEditedLanguageRecord()
        {
            _languagePage.VerifyUpdatedLanguageRecord(driver, "English", "Conversational");

        }
        [Given(@"user adds a the language record with language ""([^""]*)"" and level ""([^""]*)""")]
        public void GivenUserAddsATheLanguageRecordWithLanguageAndLevel(string language, string level)
        {
            _languagePage.CreateNewLanguageRecord(driver, language, level);
        }

        [When(@"user deletes the language record with language ""([^""]*)""")]
        public void WhenUserDeletesTheLanguageRecordWithLanguage(string language)
        {
            _languagePage.DeleteLanguageRecord(driver, language);
        }

        [Then(@"Mars portal should verify no more language record")]
        public void ThenMarsPortalShouldVerifyNoMoreLanguageRecord()
        {
            // Assuming you have a method in your page object to check if there are no language records
            bool noLanguageRecords = _languagePage.VerifyNoLanguageRecords(driver);

            // Assert that there are no language records
            Assert.IsTrue(noLanguageRecords, "Mars portal should have no more language records.");
        }


    }
}