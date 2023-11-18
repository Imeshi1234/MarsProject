using MarsProject.Pages;
using MarsProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinition:CommonDriver
    {
        LoginPage loginObj = new LoginPage();
       // HomePage homeObj = new HomePage();


        

        [Given(@"user logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            driver = new ChromeDriver();
            

            loginObj.LoginActions(driver);

           
        }

        [Given(@"user navigates to Language section")]
        public void GivenUserNavigatesToLanguageSection()
        {
           // homeObj.();
        }

        [Given(@"user need to clear all the previous records")]
        public void GivenUserNeedToClearAllThePreviousRecords()
        {
            throw new PendingStepException();
        }
        // add
        [BeforeScenario("language")]
        [When(@"user add a new language record")]
        public void WhenUserAddANewLanguageRecord()
        {
            throw new PendingStepException();
        }

        [Then(@"Mars portal should save the new added language record")]
        public void ThenMarsPortalShouldSaveTheNewAddedLanguageRecord()
        {
            throw new PendingStepException();
        }
        [AfterScenario("language")]
        //edit
        [BeforeScenario("language")]
        [Given(@"user add a new language record")]
        public void GivenUserAddANewLanguageRecord()
        {
            throw new PendingStepException();
        }

        [When(@"user edits an existing language record")]
        public void WhenUserEditsAnExistingLanguageRecord()
        {
            throw new PendingStepException();
        }

        [Then(@"Mars portal should save the edited language record")]
        public void ThenMarsPortalShouldSaveTheEditedLanguageRecord()
        {
            throw new PendingStepException();
        }
        [AfterScenario("language")]

        //delete
        [BeforeScenario("language")]

        [Given(@"user add a new language record")]
        public void GivenUserAddForDeleteNewLanguageRecord()
        {
            throw new PendingStepException();
        }

        [When(@"user delete an existing language record")]
        public void WhenUserDeleteAnExistingLanguageRecord()
        {
            throw new PendingStepException();
        }

        [Then(@"Mars portal should delete the language record")]
        public void ThenMarsPortalShouldDeleteTheLanguageRecord()
        {
            throw new PendingStepException();
        }
       

    }
}
       






