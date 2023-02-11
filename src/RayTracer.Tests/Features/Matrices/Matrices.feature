Feature: Matrices
Simple Matrix implementation

# Construction
Scenario: Constructing and inspecting a 4x4 matrix
	Given a matrix M:
		| col0 | col1 | col2 | col3 |
		| 1    | 2    | 3    | 4    |
		| 5.5  | 6.5  | 7.5  | 8.5  |
		| 9    | 10   | 11   | 12   |
		| 13.5 | 14.5 | 15.5 | 16.5 |
	Then in matrix M the element at (0, 0) is 1
	And in matrix M the element at (0, 3) is 4
	And in matrix M the element at (1, 0) is 5.5
	And in matrix M the element at (1, 2) is 7.5
	And in matrix M the element at (2, 2) is 11
	And in matrix M the element at (3, 0) is 13.5
	And in matrix M the element at (3, 2) is 15.5

Scenario: A 2x2 matrix ought to be representable
	Given a matrix M:
		| col0 | col1 |
		| -3   |  5   |
		|  1   | -2   |
	Then in matrix M the element at (0, 0) is -3
	And in matrix M the element at (0, 1) is 5
	And in matrix M the element at (1, 0) is 1
	And in matrix M the element at (1, 1) is -2

Scenario: A 3x3 matrix ought to be representable
	Given a matrix M:
		| col0 | col1 | col2 |
		| -3   |  5   | 0    |
		|  1   | -2   | -7   |
		|  0   | 1    | 1    |
	Then in matrix M the element at (0, 0) is -3
	And in matrix M the element at (1, 1) is -2
	And in matrix M the element at (2, 2) is  1

# Equality

# Scenario: Matrix equality with identical matrices
# 	Given the following matrix A:
# 		| 1 | 2 | 3 | 4 |
# 		| 5 | 6 | 7 | 8 |
# 		| 9 | 8 | 7 | 6 |
# 		| 5 | 4 | 3 | 2 |
# 	And the following matrix B:
# 		| 1 | 2 | 3 | 4 |
# 		| 5 | 6 | 7 | 8 |
# 		| 9 | 8 | 7 | 6 |
# 		| 5 | 4 | 3 | 2 |
# 	Then A = B

# Scenario: Matrix equality with different matrices
# 	Given the following matrix A:
# 		| 1 | 2 | 3 | 4 |
# 		| 5 | 6 | 7 | 8 |
# 		| 9 | 8 | 7 | 6 |
# 		| 5 | 4 | 3 | 2 |
# 	report erratum • discuss
# 	Creating a Matrix • 27
# 	And the following matrix B:
# 		| 2 | 3 | 4 | 5 |
# 		| 6 | 7 | 8 | 9 |
# 		| 8 | 7 | 6 | 5 |
# 		| 4 | 3 | 2 | 1 |
# 	Then A != B