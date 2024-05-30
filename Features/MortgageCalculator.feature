Feature: Mortgage Calculator

Background: 
Given user is on the Home Page


Scenario: User should be able to see Estimate results 
When user fills in Borrower Details '<age>', '<propertyValue>', '<zipCode>', '<remainingMortgageBalance>'
Then estimate calculation link should be visible
Then Remaining Equity tooltip should be enabled
Then Remaining Equity value '<remainingEquity>' should be visible
Examples: 
| age | propertyValue | zipCode | remainingMortgageBalance | remainingEquity |
| 70  | 1,500,000     | 90210   | 300000                   |      $936,000   |


Scenario: User should be able to download Mortgage Calculator results 
When user fills in Borrower Details '<age>', '<propertyValue>', '<zipCode>', '<remainingMortgageBalance>'
And user clicks on Download PDF link
Then PDF should be dowloaded
Examples: 
| age | propertyValue | zipCode | remainingMortgageBalance | remainingEquity |
| 70  | 1,500,000     | 90210   | 300000                   | $936,000        | 
