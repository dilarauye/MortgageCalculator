Feature: Mortgage Calculator

Background: 
Given user is on the Home Page


Scenario: User should be able to see product depending on age and zip code 
When user fills in Borrower Details '<age>', '<propertyValue>', '<zipCode>', '<firstMortgageBalance>'
Examples: 
| age | propertyValue | zipCode | firstMortgageBalance |
| 50  | 125000        | 77498   | 300000               |

Scenario: User should be able to see product depending on age and zip code - with second mortgage 
When user fills in Borrower Details with second mortgage '<age>', '<propertyValue>', '<zipCode>', '<firstMortgageBalance>', '<secondMortgageBalance>'
Examples: 
| age | propertyValue | zipCode | firstMortgageBalance | secondMortgageBalance |
| 50  | 125000        | 77498   | 300000               | 200000                |