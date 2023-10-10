Feature: Search listings on Barfoot and Thompson website

@SearchFilter
Scenario: Searching listings using suburb - bedroom and bathroom filters.
	Given the barfoot and thompson website is launched
	And search listings using "Blockhouse Bay"
	When the bedroom and bathroom filters are applied
	Then the result should show the results
	And the property can be viewed


Scenario: Searching listings using suburb - price, property type and land area filter.
	Given the barfoot and thompson website is launched
	And search listings using "Blockhouse Bay"
	When the price property and land area filters are applied
	Then the filter should show appropriate results
