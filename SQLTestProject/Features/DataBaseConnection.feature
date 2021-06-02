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

Scenario: It is possible to delete row in database table
	Given Establish a database connection
	And Row created in database with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
	When I delete row in table with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
	Then Row with data deleted
	| id   | name   | count   |
	| <id> | <name> | <count> |
Examples:
	| id | name     | count |
	| 1  | testName | 123   |

Scenario: It is possible to edit row in database table
	Given Establish a database connection
	And Row created in database with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
	When I edit row in table with data
	| id   | name   | count   | newId   | newName   | newCount   |
	| <id> | <name> | <count> | <newId> | <newName> | <newCount> |
	Then Row modified with data
	| id      | name      | count      |
	| <newId> | <newName> | <newCount> |
Examples:
	| id | name     | count | newId | newName     | newCount |
	| 1  | testName | 123   | 2     | newTestName | 32       |