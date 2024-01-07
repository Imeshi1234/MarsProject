Feature: Add, Edit, and Delete Language record

Background:
  Given user logs into Mars Portal with email "<email>" and password "<password>"
  And user navigates to Language section
  And user needs to clear all the previous records


Scenario Outline: Create a new language record
  When user adds a new language record with language "<language>" and level "<level>"
  Then Mars portal should save the new added language record

   Examples:
  | email                    | password           | language   | level          | newLevel      |
  | anuttara1989@gmail.com   | d@.u53M6U!BCCk     | English    | Basic          | Conversational|

Scenario Outline: Editing a language record
  And user adds a new language record with language "<language>" and level "<level>"
  When user edits the language record with language "<language>" and level "<newLevel>"
  Then Mars portal should save the edited language record

  Examples:
  | email                    | password           | language   | level          | newLevel      |
  | anuttara1989@gmail.com   | d@.u53M6U!BCCk     | English    | Basic          | Conversational|


Scenario Outline: Delete a language record
 And user adds a the language record with language "<language>" and level "<level>"
 When user deletes the language record with language "<language>" 
 Then Mars portal should verify no more language record


 Examples:
  | email                    | password           | language   | level          | newLevel      |
  | anuttara1989@gmail.com   | d@.u53M6U!BCCk     | English    | Basic          | Conversational|