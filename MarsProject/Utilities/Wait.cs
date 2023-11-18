using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Utilities
{
    public class Wait
    { 
            //if you use static we dont wangt to make objects to call the methods, we can directly call it.
            public static void WaitToBeClickable(IWebDriver driver, string locatorType, string locatorValue, int seconds)

            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                //to intrduce multiple contions
                if (locatorValue == "Xpath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
                }
                if (locatorValue == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
                }
                if (locatorValue == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
                }
                if (locatorValue == "Name")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));
                }
            }

            public static void WaitToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)

            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                //to intrduce multiple contions
                if (locatorValue == "Xpath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                }
                if (locatorValue == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
                }
                if (locatorValue == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
                }
                if (locatorValue == "Name")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));
                }
            }
        }
    }


