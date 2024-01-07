Feature: Add, Edit, and Delete skill record

Background:
  Given user log into Mars Portal with email "<email>" and password "<password>"
  And user navigates to skill section
  And user needs to clear all the previous skill records


 Scenario Outline: Create a new skill record
  When user adds a new skill record with skill "<skill>" and level "<level>"
  Then Mars portal should save the new added skill records

   Examples:
  | email                    | password           | skill   | level          | newLevel      |
  | anuttara1989@gmail.com   | d@.u53M6U!BCCk     | Dancing    | Beginner       | Intermediate|

Scenario Outline: Editing a skill record
  And user adds a new skill record with skill "<skill>" and level "<level>"
  When user edits the skill record with skill "<skill>" and level "<newLevel>"
  Then Mars portal should save the edited skill records

  Examples:
  | email                    | password           | skill  | level          | newLevel      |
  | anuttara1989@gmail.com   | d@.u53M6U!BCCk     | Dancing    | Beginner   | Intermediate|


Scenario Outline: Delete a language record
 And user adds a the skill record with skill "<skill>" and level "<level>"
 When user deletes the skill record with skill "<skill>" 
 Then Mars portal should verify no more skill record
 
  Examples:
  | email                    | password           | skill  | level          | newLevel      |
  | anuttara1989@gmail.com   | d@.u53M6U!BCCk     | Dancing    | Beginner         | Intermediate|




