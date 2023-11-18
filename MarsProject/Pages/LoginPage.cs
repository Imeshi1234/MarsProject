using MarsProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            //Lanch Mars Portal
            driver.Navigate().GoToUrl("http://localhost:5000/Home");


            IWebElement signInBtn = driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']"));
            signInBtn.Click();
            

            //Identify email textbox and enter valid email
            Wait.WaitToBeVisible(driver, "Xpath", "(\"//input[@placeholder=\\\"Email address'']\")", 5);
            IWebElement emailTextBox = driver.FindElement(By.XPath("//input[@placeholder=\"Email address'']"));
            emailTextBox.SendKeys("mvpstudio.qa@gmail.com");


            //Identify password textbox and enter valid password
            IWebElement passwordTextBox = driver.FindElement(By.XPath("//input[@placeholder=\"Password']"));
            passwordTextBox.SendKeys("SydneyQa2018");

            IWebElement loginButton = driver.FindElement(By.XPath("//button[@class=\"fluid ui teal button\"]"));
            loginButton.Click();
        }

    }
}
