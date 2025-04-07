Feature: Sauce

@tag1
Scenario: Add highest item to bag
	Given user is on sauce url
	And user login with the following credentials
	| userName      | password     |
	| standard_user | secret_sauce |
	When user select the option 'highest' price item and add to shopping basket