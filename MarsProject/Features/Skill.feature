Feature: Add,Edit and Delete Skill record

Scenario: Create a new skill record
Given logging into Mars Portal
And user navigates to skill section
And user need to clear all the previous skill records
When user add a new skill record
Then Mars portal should save the new added skill record

Scenario: Editing a skill record
Given logging into Mars Portal
And user navigates to skill section
And user need to clear all the previous skill records
And user add a new skill record
When user edits an existing skill record
Then Mars portal should save the edited skill record

Scenario: Delete a skill record
Given logging into Mars Portal
And user navigates to skill section
And user need to clear all the previous skill records
And user add a new skill record
When user delete an existing skill record
Then Mars portal should delete the skill record