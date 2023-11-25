using MarsProject.Pages;
using MarsProject.Utilities;
using OpenQA.Selenium.Chrome;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class SkillStepDefinition : CommonDriver
    {

        LoginPage loginObj = new LoginPage();
        HomePage homeObj = new HomePage();
        SkillPage skillObj = new SkillPage();



        [Given(@"logging into Mars Portal")]
        public void GivenLoggingIntoMarsPortal()
        {
            driver = new ChromeDriver();
            loginObj.LoginActions(driver);
        }

        [Given(@"user navigates to skill section")]
        public void GivenUserNavigatesToSkillSection()
        {
            homeObj.selectSkillOption(driver);
        }

        [Given(@"user need to clear all the previous skill records")]
        public void GivenUserNeedToClearAllThePreviousSkillRecords()
        {
            skillObj.ClearAllPreviousAddedSkills(driver);
        }


        [When(@"user add a new skill record")]
        [Given(@"user add a new skill record")]
        public void WhenUserAddANewSkillRecord()
        {
            skillObj.CreateNewSkillRecord(driver);
        }

        [Then(@"Mars portal should save the new added skill record")]
        public void ThenMarsPortalShouldSaveTheNewAddedSkillRecord()
        {
            skillObj.VerifyAddedSkillRecord(driver,"Dancing");
        }

        //Edit
        [When(@"user edits an existing skill record")]
        public void WhenUserEditsAnExistingSkillRecord()
        {
            skillObj.UpdateNewSkillRecord(driver);
        }

        [Then(@"Mars portal should save the edited skill record")]
        public void ThenMarsPortalShouldSaveTheEditedSkillRecord()
        {
            // Replace these values with the ones you used during editing
            string editedSkill = "Dancing";
            string editedLevel = "Expert";

            // Verify the edited skill record
            skillObj.VerifyUpdatedSkillRecord(driver, editedSkill, editedLevel);
        }

        //Delete
        [When(@"user delete an existing skill record")]
        public void WhenUserDeleteAnExistingLanguageRecord()
        {
            // Replace "Dancing" with the skill you want to delete
            skillObj.DeleteSkillRecord(driver, "Dancing");
        }

        [Then(@"Mars portal should delete the skill record")]
        public void ThenMarsPortalShouldDeleteTheSkillRecord()
        {
            // Replace "Dancing" with the language you deleted in the previous step
            string deletedSkill = "Dancing";

            // Verify the absence of the deleted language record
            skillObj.VerifyDeletedSkillRecord(driver, deletedSkill);
        }
    }

    }