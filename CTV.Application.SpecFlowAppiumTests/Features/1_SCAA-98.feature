Feature: Consent elements are visible

	#*Summary*
	#Test to confirm all expected elements on the consent screen are visible
	#
	#*Precondition*
	#Fresh app install. Navigated to the consent page
	@TEST_SCAA-98
	Scenario Outline: Consent elements are visible
		Given the app is running
		And the user has navigated to the "Consent" screen
		When the user is on the <view> screen
		Then they are able to see the expected element <element>
		
		Examples:
		| title          | view    | element          |
		| CompanyLogo    | Consent | companyLogoImage |
		| ConsentTitle   | Consent | consentTitle     |
		| ConsentDesc    | Consent | consentDesc      |
		| ConsentContent | Consent | consentContent   |
		| AcceptButton   | Consent | acceptInput      |
		| RejectButton   | Consent | rejectInput      |
