using MarsProject.Pages;
using MarsProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class SkillStepDefinition : CommonDriver
    {

        LoginPage _loginPage = new LoginPage();
        HomePage homeObj = new HomePage();
        SkillPage _skillPage = new SkillPage();

        [Given(@"user log into Mars Portal with email ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenUserLogIntoMarsPortalWithEmailAndPassword(string email, string password)
        {
            driver = new ChromeDriver();
            _loginPage.LoginActions(driver);
            _loginPage.ClickSignInButton(driver);
            _loginPage.EnterLoginCredentials(driver, "anuttara1989@gmail.com", "d@.u53M6U!BCCk");
            _loginPage.ClickLoginButton(driver);
        }


        [Given(@"user navigates to skill section")]
        public void GivenUserNavigatesToSkillSection()
        {
            homeObj.selectSkillOption(driver);
        }

        [Given(@"user needs to clear all the previous skill records")]
        public void GivenUserNeedsToClearAllThePreviousSkillRecords()
        {
            _skillPage.ClearAllPreviousAddedSkills(driver);
        }

        [When(@"user adds a new skill record with skill ""([^""]*)"" and level ""([^""]*)""")]
        public void WhenUserAddsANewSkillRecordWithSkillAndLevel(string skill, string level)
        {
            _skillPage.CreateNewSkillRecord(driver,skill,level);
        }

        [Then(@"Mars portal should save the new added skill records")]
        public void ThenMarsPortalShouldSaveTheNewAddedSkillRecords()
        {
            _skillPage.VerifyAddedSkillRecord(driver,"Dancing");
        }
        [Given(@"user adds a new skill record with skill ""([^""]*)"" and level ""([^""]*)""")]
        public void GivenUserAddsANewSkillRecordWithSkillAndLevel(string skill, string level)
        {
            _skillPage.CreateNewSkillRecord(driver,skill,level);
        }

        [When(@"user edits the skill record with skill ""([^""]*)"" and level ""([^""]*)""")]
        public void WhenUserEditsTheSkillRecordWithSkillAndLevel(string skill, string newlevel)
        {
            _skillPage.UpdateNewSkillRecord(driver, skill, newlevel);
    
         }
        [Then(@"Mars portal should save the edited skill records")]
        public void ThenMarsPortalShouldSaveTheEditedSkillRecords()
        {
            _skillPage.VerifyUpdatedSkillRecord(driver,"Dancing", "Intermediate");
        }
        [Given(@"user adds a the skill record with skill ""([^""]*)"" and level ""([^""]*)""")]
        public void GivenUserAddsATheSkillRecordWithSkillAndLevel(string skill, string level)
        {
            _skillPage.CreateNewSkillRecord(driver, skill, level);
        }

        [When(@"user deletes the skill record with skill ""([^""]*)""")]
        public void WhenUserDeletesTheSkillRecordWithSkill(string skill)
        {
            _skillPage.DeleteSkillRecord(driver, skill);
        }

        [Then(@"Mars portal should verify no more skill record")]
        public void ThenMarsPortalShouldVerifyNoMoreSkillRecord()
        {
            // Assuming you have a method in your page object to check if there are no skill records
            bool noSkillRecords = _skillPage.VerifyNoSkillRecord(driver);

            // Assert that there are no skill records
            Assert.IsTrue(noSkillRecords, "Mars portal should have no more skill records.");
        }

    }




}



       

        