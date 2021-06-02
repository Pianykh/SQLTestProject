@db
Feature: DataBase connection

Scenario: It is possible to create row in database table
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
	Given Row created in database with data
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
	Given Row created in database with data
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

Scenario: It is impossible to create row with invalid data in database table
	When I create row in table with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
	Then Displayed exception message '<message>'
Examples:
	| id  | name | count | message                         |
	| dsa | name | 1     | Недопустимое имя столбца "dsa". |
	| 1   | name | gaf   | Недопустимое имя столбца "gaf". |
