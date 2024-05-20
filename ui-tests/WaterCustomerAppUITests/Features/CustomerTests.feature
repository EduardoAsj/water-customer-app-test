Feature: Customer Tests
	In order to ensure the application works correctly
	As a user
	I want to verify customer size categorization, handle missing contact info, and verify contact info display

	Background:
		Given I am on the welcome screen
		When I enter my name
		And submit the form

	Scenario Outline: Verify customer size categorization
		And check the customer "<CustomerName>"
		Then I should see the size categorized correctly for "<CustomerName>" with <EmployeeCount> employees

		Examples:
			| CustomerName          | EmployeeCount |
			| Las Vegas Water       | 3200          |
			| Los Angels Water      | 5050          |
			| San Francisco's Water | 40            |
			| New York's Water      | 9053          |
			| Miami's Water         | 2450          |
			| Chicago's Water       | 1107          |
			| Denver's Water        | 1507          |

	Scenario Outline: Display message for missing or partial contact info
		And I click on the customer "<CustomerName>"
		Then I should see a message "<ExpectedMessage>"

		Examples:
			| CustomerName   | ExpectedMessage           |
			| Denver's Water | No contact info available |

	Scenario Outline: Click on customer name to navigate to Contacts Detail Screen
		And I click on the customer "<CustomerName>"
		Then I should see the Contacts Detail Screen for "<CustomerName>"

		Examples:
			| CustomerName          |
			| Las Vegas Water       |
			| Los Angels Water      |
			| San Francisco's Water |
			| New York's Water      |
			| Miami's Water         |
			| Chicago's Water       |
			| Denver's Water        |
