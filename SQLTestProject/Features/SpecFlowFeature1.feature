@db
Feature: DataBase connection	

Scenario: It is possible to create row in database table
	Given Establish a database connection
	When I create row in table with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
	Then Row created with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
Examples:
	| id | name     | count |
	| 1  | testName | 123   |