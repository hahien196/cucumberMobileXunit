Feature: Activation elements are visible

	#*Summary*
	#Test to confirm all expected elements on the activation screen are visible
	#
	#*Precondition*
	#Fresh app install.
	@TEST_SKP-42
	Scenario Outline: Activation elements are visible
		Given the app is running
		When the user is on the <view> screen
		Then they are able to see the expected element <element>
		
		Examples:
		| title            | view       | element          |
		| SpiritLogo       | Activation | SpiritLogo       |
		| ActivationTitle  | Activation | ActivationTitle  |
		| ActivationDesc   | Activation | ActivationDesc   |
		| CodeField        | Activation | CodeField        |
		| ActivationButton | Activation | ActivationButton |
