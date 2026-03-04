Feature: BalanceVerification

Here we login and verify the balance

Background: 
	Given I open a new Chrome browser
	And I navigate to home page


Scenario: Navigation Verification - Verify URL 
	Then I verify that the url contains 'krak'


@Demo
Scenario: Balance Verification - Logging in and veryfying the balance
	Given I click on the Login button
	When I set the default username
	And I set the default password
	Then I click the continue button
	And I click on the authenticator app button
	Then I set the default 2FA token
	And I click on the Enter button
	Then I verify that I can see the portfolio value
	And I verify that the portfolio value is not 0