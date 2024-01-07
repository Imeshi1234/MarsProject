using MarsProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class LoginPage 
    {
     
        public void LoginActions(IWebDriver _driver)
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://localhost:5000/Home");

         
        }

        public void ClickSignInButton(IWebDriver _driver)
        {
            // Implement this method to click the Sign In button
            IWebElement signInBtn = _driver.FindElement(By.XPath("//a[@class='item'][text()='Sign In']"));
            signInBtn.Click();
        }

        public void EnterLoginCredentials(IWebDriver _driver, string email, string password)
        {
            // Implement this method to enter login credentials
            IWebElement emailTextBox = _driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
            emailTextBox.SendKeys(email);

            IWebElement passwordTextBox = _driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            passwordTextBox.SendKeys(password);
        }

        public void ClickLoginButton(IWebDriver _driver)
        {
            // Implement this method to click the Login button
            IWebElement loginButton = _driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));
            loginButton.Click();
            Thread.Sleep(1000);
        }
        public bool IsUserLoggedIn(IWebDriver _driver)
        {
            try
            {
                // Attempt to find the "Sign Out" button
                IWebElement signOutButton = _driver.FindElement(By.XPath("//a[@class='item']//button[@class='ui green basic button']"));

                // If the button is found, the user is logged in
                return signOutButton != null;

            }
            catch(NoSuchElementException)
            {
                return false;
            }
            
        }
    }
}
