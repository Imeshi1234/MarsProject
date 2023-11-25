using MarsProject.Pages;
using MarsProject.Utilities;
using OpenQA.Selenium.Chrome;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinition : CommonDriver
    {

        LoginPage loginObj = new LoginPage();
        HomePage homeObj = new HomePage();
        LanguagePage languageObj = new LanguagePage();

        [Given(@"user logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            driver = new ChromeDriver();
            loginObj.LoginActions(driver);
        }

        [Given(@"user navigates to Language section")]
        public void GivenUserNavigatesToLanguageSection()
        {
            homeObj.selectLanguageOption(driver);
        }

        [Given(@"user need to clear all the previous records")]
        public void GivenUserNeedToClearAllThePreviousRecords()
        {
            languageObj.ClearAllPreviousAddedLanguage(driver);

        }

        [When(@"user add a new language record")]
        [Given(@"user add a new language record")]
        public void WhenUserAddANewLanguageRecord()
        {
            languageObj.CreateNewLanguageRecord(driver);
        }

        [Then(@"Mars portal should save the new added language record")]
        public void ThenMarsPortalShouldSaveTheNewAddedLanguageRecord()
        {
            languageObj.VerifyAddedLanguageRecord(driver, "French");
        }

        //Edit
        [When(@"user edits an existing language record")]
        public void WhenUserEditsAnExistingLanguageRecord()
        {
            languageObj.UpdateNewLanguageRecord(driver);
        }

        [Then(@"Mars portal should save the edited language record")]
        public void ThenMarsPortalShouldSaveTheEditedLanguageRecord()
        {
            // Replace these values with the ones you used during editing
            string editedLanguage = "French";
            string editedLevel = "Basic";

            // Verify the edited language record
            languageObj.VerifyUpdatedLanguageRecord(driver, editedLanguage, editedLevel);
        }
        //Delete
        [When(@"user delete an existing language record")]
        public void WhenUserDeleteAnExistingLanguageRecord()
        {
            // Replace "French" with the language you want to delete
            languageObj.DeleteLanguageRecord(driver, "French");
        }

        [Then(@"Mars portal should delete the language record")]
        public void ThenMarsPortalShouldDeleteTheLanguageRecord()
        {
            // Replace "French" with the language you deleted in the previous step
            string deletedLanguage = "French";

            // Verify the absence of the deleted language record
            languageObj.VerifyDeletedLanguageRecord(driver, deletedLanguage);
        }
    }
}