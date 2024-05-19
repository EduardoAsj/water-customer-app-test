Feature: Customer API Tests

  Scenario: Attempting to create a customer with an empty name
    Given I have an empty name
    When I send a POST request to the customer API
    Then I should receive a bad request response
    And the error message should indicate that the name is required

  Scenario: Attempting to create a customer with a blank request body
    Given I have a blank request body
    When I send a POST request to the customer API
    Then I should receive a bad request response
    And the error message should indicate that the name is required

  Scenario: Verify customer size calculation
    Given I have a name "Eduardo Afonso"
    When I send a POST request to the customer API
    Then I should receive a success response
    And the response should contain correctly calculated customer sizes