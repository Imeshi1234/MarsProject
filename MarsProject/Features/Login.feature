Feature: Login Feature

  Scenario Outline: Login Testing Scenarios
    Given I navigate to the Mars Portal
    When I click on the Sign In button
    When I enter email "<email>" and password "<password>"
    When I click on the Login button
    Then the login outcome should be "<outcome>"

    Examples:
  | email                   | password            | outcome            |
  | anuttara1989@gmail.com  | d@.u53M6U!BCCk      | LoggedIn           |
  | invalid@example.com     | invalidPassword123  | InvalidCredentials |
  | invalid@example.com     | ValidPassword123    | InvalidCredentials |
  | valid@example.com       | InvalidPassword123  | InvalidCredentials |
  

 