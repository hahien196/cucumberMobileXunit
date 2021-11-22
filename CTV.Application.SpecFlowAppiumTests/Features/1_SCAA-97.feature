Feature: Activation elements are visible

	#*Summary*
	#Test to confirm all expected elements on the activation screen are visible
	#
	#*Precondition*
	#Fresh app install.
	@TEST_SCAA-97
	Scenario Outline: Activation elements are visible
		Given the app is running
		When the user is on the <view> screen
		Then they are able to see the expected element <element>
		
		Examples:
		| title            | view       | element                 |
		| CompanyLogo      | Activation | companyLogoImage        |
		| ActivationTitle  | Activation | activationTitle         |
		| ActivationDesc   | Activation | activationDesc          |
		| CodeField        | Activation | activationCodeInput     |
		| ActivationButton | Activation | activationContinueInput |
		| T and C's        | Activation | termsAgreedInput        |
