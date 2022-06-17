Feature: PausePlanSettings

The user pauses his plan setting

@pause		@planSettings		@successful
Scenario: Pause the plan settings
	When The user clicks on the plan settings button
	Then The fat burner beginner dialog box is displayed
	When The user clicks on the pause button
	Then The pause program form is displayed in the dialog box
	When The user clicks on pause program button
	Then The program is paused 
