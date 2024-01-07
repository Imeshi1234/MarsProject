using MarsProject.Pages;
using MarsProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class LoginPageSteps : CommonDriver
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        public LoginPageSteps()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage();
        }

        [Given(@"I navigate to the Mars Portal")]
        public void GivenINavigateToTheMarsPortal()
        {
            _loginPage.LoginActions(_driver);
        }

        [When(@"I click on the Sign In button")]
        public void WhenIClickOnTheSignInButton()
        {
            // Assuming you have a method in LoginPage for clicking the Sign In button
            _loginPage.ClickSignInButton(_driver);
        }

        [When(@"I enter email ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterEmailAndPassword(string p0, string p1)
        {
            // Assuming you have a method in LoginPage for entering login credentials
            _loginPage.EnterLoginCredentials(_driver, p0, p1);
        }

        [When(@"I click on the Login button")]
        public void WhenIClickOnTheLoginButton()
        {
            // Assuming you have a method in LoginPage for clicking the Login button
            _loginPage.ClickLoginButton(_driver);
        }

        [Then(@"the login outcome should be ""([^""]*)""")]
        public void ThenTheLoginOutcomeShouldBe(string loggedIn)
        {
            if (loggedIn.Equals("LoggedIn", StringComparison.OrdinalIgnoreCase))
            {
                Assert.IsTrue(_loginPage.IsUserLoggedIn(_driver), "Login failed");
            }
            else if (loggedIn.Equals("InvalidCredentials", StringComparison.OrdinalIgnoreCase))
            {
                Assert.IsFalse(_loginPage.IsUserLoggedIn(_driver), "Unexpected successful login");
                // You may add additional assertions or validation for error messages, etc.
            }
            else
            {
                throw new ArgumentException($"Invalid login status: {loggedIn}");

            }



        }
    }
}
