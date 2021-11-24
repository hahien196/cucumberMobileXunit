Feature: Welcome elements are visible

	#*Summary*
	#Test to confirm all expected elements on the welcome screen are visible
	#
	#*Precondition:*
	#Fresh app installed
	@TEST_SCAA-96
	Scenario Outline: Welcome elements are visible
		Given the app is running
		And the user has navigated to the "Welcome" screen
		When the user is on the <view> screen
		Then they are able to see the expected element <element>
		
		Examples:
		| title              | view    | element            |
		| CompanyLogo        | Welcome | companyLogoImage   |
		| WelcomeTitle       | Welcome | welcomeTitle       |
		| WelcomePatient     | Welcome | patientName        |
