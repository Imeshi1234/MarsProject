using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MarsProject.Pages
{
    public class SkillPage
    {
        public void ClearAllPreviousAddedSkills(IWebDriver driver)
        {
            // Wait for the table to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement SkillTable = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active' and @data-tab='second']//table[@class='ui fixed table']")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = SkillTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and click the "Remove" button
            foreach (IWebElement row in rows)
            {
                IWebElement removeButton = row.FindElement(By.XPath(".//span[@class='button']/i[@class='remove icon']"));
                removeButton.Click();

                // Re-find the table after removing a row to avoid stale element reference
                SkillTable = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active' and @data-tab='second']//table[@class='ui fixed table']")));

                // Re-find all rows in the updated table
                rows = SkillTable.FindElements(By.XPath(".//tbody/tr"));

                // You might want to add a confirmation step if needed (e.g., handling a confirmation dialog)
            }
        }

        public void CreateNewSkillRecord(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for the "Skill" tab to be visible
            IWebElement skillTab = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@data-tab='second']")));
            skillTab.Click();  // Click on the "Languages" tab

            // Wait for the "Add New" button under the "Skill" tab to be clickable
            IWebElement addNewButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-tab='second']//div[@class='ui teal button']")));
            addNewButton.Click();  // Click on the "Add New" button

            // Wait for the input fields to be visible
            IWebElement skillInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-wrapper']//input[@name='name']")));
            IWebElement levelDropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-wrapper']//select[@name='level']")));

            // Fill in the language and level
            skillInput.SendKeys("Dancing");

            // Select the level from the dropdown
            SelectElement levelDropdownSelect = new SelectElement(levelDropdown);
            levelDropdownSelect.SelectByText("Intermediate");

            // Find and click the "Add" button
            IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='form-wrapper']//input[@value='Add']")));
            addButton.Click();

        }

        public void VerifyAddedSkillRecord(IWebDriver driver, string skill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Wait for the table to be present and visible
            IWebElement skillTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active' and @data-tab='second']//table[@class='ui fixed table']")));

            // Wait for all rows to be present in the table
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//table[@class='ui fixed table']//tbody/tr")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = skillTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and check if the added language is present
            bool skillFound = false;
            foreach (IWebElement row in rows)
            {
                IWebElement skillCell = row.FindElement(By.XPath(".//td[1]")); // Assuming the language is in the first column
                if (skillCell.Text.Trim().Equals(skill))
                {
                    skillFound = true;
                    break;
                }
            }

            // Assert that the language is found
            Assert.IsTrue(skillFound, $"The added skill '{skill}' was not found in the table.");
        }
        public void UpdateNewSkillRecord(IWebDriver driver)
        {
            // Replace "French" and "Advanced" with the values you want to set during editing
            string editedSkill = "Dancing";
            string editedLevel = "Expert";

            // Wait for the table to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement skillTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active' and @data-tab='second']//table[@class='ui fixed table']")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = skillTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and check if the language to edit is present
            foreach (IWebElement row in rows)
            {
                IWebElement skillCell = row.FindElement(By.XPath(".//td[1]")); // Assuming the language is in the first column
                if (skillCell.Text.Trim().Equals("Dancing"))
                {
                    // Click on the "Edit" button in the same row
                    IWebElement editButton = row.FindElement(By.XPath(".//span[@class='button']/i[@class='outline write icon']"));
                    editButton.Click();

                    // Wait for the input fields to be visible
                    IWebElement skillInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-wrapper']//input[@name='name']")));
                    IWebElement levelDropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-wrapper']//select[@name='level']")));

                    // Clear the existing text in the input field and enter the new language
                    skillInput.Clear();
                    skillInput.SendKeys(editedSkill);

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

        public void VerifyUpdatedSkillRecord(IWebDriver driver, string skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Wait for the table to be present and visible
            IWebElement SkillTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active' and @data-tab='second']//table[@class='ui fixed table']")));

            // Wait for all rows to be present in the table
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//table[@class='ui fixed table']//tbody/tr")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = SkillTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and check if the added language is present
            bool skillFound = false;
            foreach (IWebElement row in rows)
            {
                IWebElement skillCell = row.FindElement(By.XPath(".//td[1]")); // Assuming the language is in the first column
                if (skillCell.Text.Trim().Equals(skill))
                {
                    // Add additional checks if needed, for example, checking the level
                    IWebElement levelCell = row.FindElement(By.XPath(".//td[2]")); // Assuming the level is in the second column
                    if (levelCell.Text.Trim().Equals(level))
                    {
                        skillFound = true;
                        break;
                    }
                }
            }

            // Assert that the language is found
            Assert.IsTrue(skillFound, $"The edited skill '{skill}' with level '{level}' was not found in the table.");
        }

        public void DeleteSkillRecord(IWebDriver driver, string skillToDelete)
        {

            // Wait for the table to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement SkillTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active' and @data-tab='second']//table[@class='ui fixed table']")));

            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = SkillTable.FindElements(By.XPath(".//tbody/tr"));

            // Iterate through each row and check if the skill to delete is present
            foreach (IWebElement row in rows)
            {
                IWebElement skillCell = row.FindElement(By.XPath(".//td[1]")); // Assuming the skill is in the first column
                if (skillCell.Text.Trim().Equals(skillToDelete))
                {
                    // Click on the "Remove" button in the same row
                    IWebElement removeButton = row.FindElement(By.XPath(".//span[@class='button']/i[@class='remove icon']"));
                    removeButton.Click();

                    break; // Break the loop after finding and clicking the "Remove" button
                }
            }
        }

        public void VerifyDeletedSkillRecord(IWebDriver driver, string deletedSkill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Wait for the table to be present and visible
            IWebElement SkillTable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathToFind: "//div[@class='ui bottom attached tab segment tooltip-target active' and @data-tab='second']//table[@class='ui fixed table']")));

            try
            {
                // Explicitly wait for the presence of the skill to ensure it is not found
                wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//table[@class='ui fixed table']//td[1][contains(text(), '{deletedSkill}')]"), ""));
            }
            catch (WebDriverTimeoutException)
            {
                // If timeout exception occurs, it means the skill record is not found, which is expected
                return;
            }

            // If the code reaches here, it means the skill record is still present
            Assert.Fail($"The deleted skill '{deletedSkill}' was found in the table.");
        }

    }
}
