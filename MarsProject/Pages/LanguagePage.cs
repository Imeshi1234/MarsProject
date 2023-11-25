using MarsProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarsProject.Pages
{

    public class LanguagePage
    {
        public void ClearAllPreviousAddedLanguage(IWebDriver driver)
        {
            // Wait for the table to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement languageTable = wait.Until(ExpectedConditions.ElementExists(By.XPath("//table[@class='ui fixed table']")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = languageTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and click the "Remove" button
            foreach (IWebElement row in rows)
            {
                IWebElement removeButton = row.FindElement(By.XPath(".//span[@class='button']/i[@class='remove icon']"));
                removeButton.Click();

                // Re-find the table after removing a row to avoid stale element reference
                languageTable = wait.Until(ExpectedConditions.ElementExists(By.XPath("//table[@class='ui fixed table']")));

                // Re-find all rows in the updated table
                rows = languageTable.FindElements(By.XPath(".//tbody/tr"));

                // You might want to add a confirmation step if needed (e.g., handling a confirmation dialog)
            }
        }

        public void CreateNewLanguageRecord(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for the "Languages" tab to be visible
            IWebElement languagesTab = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@data-tab='first']")));
            languagesTab.Click();  // Click on the "Languages" tab

            // Wait for the "Add New" button under the "Languages" tab to be clickable
            IWebElement addNewButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-tab='first']//div[@class='ui teal button']")));
            addNewButton.Click();  // Click on the "Add New" button

            // Wait for the input fields to be visible
            IWebElement languageInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-wrapper']//input[@name='name']")));
            IWebElement levelDropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-wrapper']//select[@name='level']")));

            // Fill in the language and level
            languageInput.SendKeys("French");

            // Select the level from the dropdown
            SelectElement levelDropdownSelect = new SelectElement(levelDropdown);
            levelDropdownSelect.SelectByText("Fluent");

            // Find and click the "Add" button
            IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='form-wrapper']//input[@value='Add']")));
            addButton.Click();

        }

        public void VerifyAddedLanguageRecord(IWebDriver driver, string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Wait for the table to be present and visible
            IWebElement languageTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@class='ui fixed table']")));

            // Wait for all rows to be present in the table
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//table[@class='ui fixed table']//tbody/tr")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = languageTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and check if the added language is present
            bool languageFound = false;
            foreach (IWebElement row in rows)
            {
                IWebElement languageCell = row.FindElement(By.XPath(".//td[1]")); // Assuming the language is in the first column
                if (languageCell.Text.Trim().Equals(language))
                {
                    languageFound = true;
                    break;
                }
            }

            // Assert that the language is found
            Assert.IsTrue(languageFound, $"The added language '{language}' was not found in the table.");
        }

        public void UpdateNewLanguageRecord(IWebDriver driver)
        {
            // Replace "French" and "Advanced" with the values you want to set during editing
            string editedLanguage = "French";
            string editedLevel = "Basic";

            // Wait for the table to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement languageTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@class='ui fixed table']")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = languageTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and check if the language to edit is present
            foreach (IWebElement row in rows)
            {
                IWebElement languageCell = row.FindElement(By.XPath(".//td[1]")); // Assuming the language is in the first column
                if (languageCell.Text.Trim().Equals("French"))
                {
                    // Click on the "Edit" button in the same row
                    IWebElement editButton = row.FindElement(By.XPath(".//span[@class='button']/i[@class='outline write icon']"));
                    editButton.Click();

                    // Wait for the input fields to be visible
                    IWebElement languageInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-wrapper']//input[@name='name']")));
                    IWebElement levelDropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-wrapper']//select[@name='level']")));

                    // Clear the existing text in the input field and enter the new language
                    languageInput.Clear();
                    languageInput.SendKeys(editedLanguage);

                    // Select the new level from the dropdown
                    SelectElement levelDropdownSelect = new SelectElement(levelDropdown);
                    levelDropdownSelect.SelectByText(editedLevel);

                    // Find and click the "Update" button
                    IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='form-wrapper']//input[@value='Update']")));
                    addButton.Click();

                    // Wait for the table or relevant elements to be present or visible
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//table[@class='ui fixed table']")));

                    // Introduce a longer wait after clicking "Update" (adjust the sleep time as needed)
                    Thread.Sleep(5000); // 5 seconds
                    break; // Break the loop after editing the desired language
                }
            }
        }

        public void VerifyUpdatedLanguageRecord(IWebDriver driver, string language, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Wait for the table to be present and visible
            IWebElement languageTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@class='ui fixed table']")));

            // Wait for all rows to be present in the table
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//table[@class='ui fixed table']//tbody/tr")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = languageTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and check if the added language is present
            bool languageFound = false;
            foreach (IWebElement row in rows)
            {
                IWebElement languageCell = row.FindElement(By.XPath(".//td[1]")); // Assuming the language is in the first column
                if (languageCell.Text.Trim().Equals(language))
                {
                    // Add additional checks if needed, for example, checking the level
                    IWebElement levelCell = row.FindElement(By.XPath(".//td[2]")); // Assuming the level is in the second column
                    if (levelCell.Text.Trim().Equals(level))
                    {
                        languageFound = true;
                        break;
                    }
                }
            }

            // Assert that the language is found
            Assert.IsTrue(languageFound, $"The edited language '{language}' with level '{level}' was not found in the table.");
        }

        public void DeleteLanguageRecord(IWebDriver driver, string languageToDelete)
        {

            // Wait for the table to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement languageTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@class='ui fixed table']")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = languageTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and check if the language to delete is present
            foreach (IWebElement row in rows)
            {
                IWebElement languageCell = row.FindElement(By.XPath(".//td[1]")); // Assuming the language is in the first column
                if (languageCell.Text.Trim().Equals(languageToDelete))
                {
                    // Click on the "Remove" button in the same row
                    IWebElement removeButton = row.FindElement(By.XPath(".//span[@class='button']/i[@class='remove icon']"));
                    removeButton.Click();

                    break; // Break the loop after finding and clicking the "Remove" button
                }
            }
        }

        public void VerifyDeletedLanguageRecord(IWebDriver driver, string deletedLanguage)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Wait for the table to be present and visible
            IWebElement languageTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathToFind: "//table[@class='ui fixed table']")));

            try
            {
                // Explicitly wait for the presence of the language to ensure it is not found
                wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//table[@class='ui fixed table']//td[1][contains(text(), '{deletedLanguage}')]"), ""));
            }
            catch (WebDriverTimeoutException)
            {
                // If timeout exception occurs, it means the language record is not found, which is expected
                return;
            }

            // If the code reaches here, it means the language record is still present
            Assert.Fail($"The deleted language '{deletedLanguage}' was found in the table.");
        }
    }
}
