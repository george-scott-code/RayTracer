Feature: Matrices
Simple Matrix implementation

# Construction
Scenario: Constructing and inspecting a 4x4 matrix
	Given a matrix M:
	| col 0 | col1 | col2 | col3 |
	| 1     | 2    | 3    | 4    |
	| 5.5   | 6.5  | 7.5  | 8.5  |
	| 9     | 10   | 11   | 12   |
	| 13.5  | 14.5 | 15.5 | 16.5 |
	Then the element at (0, 0) is 1
	And the element at (0, 3) is 4
	And the element at (1, 0) is 5.5
	And the element at (1, 2) is 7.5
	And the element at (2, 2) is 11
	And the element at (3, 0) is 13.5
	And the element at (3, 2) is 15.5

