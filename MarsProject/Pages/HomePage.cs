using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class HomePage

    {
        public void selectLanguageOption(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for the element to be clickable
            IWebElement clickLanguageTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-tab='first']")));

            // Click the element
            clickLanguageTab.Click();
        }

        public void selectSkillOption(IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for the element to be clickable
            IWebElement clickSkillTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-tab='second']")));

            //Click the element
            clickSkillTab.Click();

        }

    }
}
