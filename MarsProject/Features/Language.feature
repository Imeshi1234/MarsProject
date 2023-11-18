Feature: Add,Edit and Delete Language record

Scenario: Create a new language record
Given user logs into Mars Portal
And user navigates to Language section
And user need to clear all the previous records
When user add a new language record
Then Mars portal should save the new added language record


#Scenario: Editing a language record
#Given user logs into Mars Portal
#And user navigates to Language section
#And user need to clear all the previous records
#And user add a new language record
#When user edits an existing language record
#Then Mars portal should save the edited language record
#
#Scenario: Delete a language record
#Given user logs into Mars Portal
#And user navigates to Language section
#And user need to clear all the previous records
#And user add a new language record
#When user delete an existing language record
#Then Mars portal should delete the language record