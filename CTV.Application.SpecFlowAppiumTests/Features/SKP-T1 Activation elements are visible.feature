Feature: Activation elements are visible

    Scenario: Activation elements are visible
        Given the app is running
        When the user is on the <view> screen
        Then they are able to see the expected element <element>
        
        Examples: 
        | view        | element          |
        | Activation  | SpiritLogo       |
        | Activation2 | ActivationTitle  |