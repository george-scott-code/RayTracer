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

Scenario: Matrix equality with identical matrices
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	And a matrix B:
		| col0 | col1 | col2 | col3 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	Then matrix A is equal to matrix B
	Then matrix B is equal to matrix A

Scenario: Matrix equality with ~identical matrices, floating point arithmetic
	Given a matrix A:
		| col0 | col1 |
		| 1    | 2    |
		| 5    | 6    |
	And a matrix B:
		| col0 | col1     |
		| 1    | 2        |
		| 5    | 6.000009 |
	Then matrix A is equal to matrix B
	And matrix B is equal to matrix A

Scenario: Matrix equality with different matrices
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	And a matrix B:
		| col0 | col1 | col2 | col3 |
		| 2    | 3    | 4    | 5    |
		| 6    | 7    | 8    | 9    |
		| 8    | 7    | 6    | 5    |
		| 4    | 3    | 2    | 1    |
	Then matrix A is not equal to matrix B
	And matrix B is not equal to matrix A

Scenario: Matrix equality with different size matrices
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	And a matrix B:
		| col0 | col1 | col2 |
		| 1    | 2    | 3    |
		| 5    | 6    | 7    |
		| 9    | 8    | 7    |
	Then matrix A is not equal to matrix B
	And matrix B is not equal to matrix A
	
# Multiplication

Scenario: Multiplying two matrices
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	And a matrix B:
		| col0 | col1 | col2 | col3 |
		| -2   | 1    | 2    | 3    |
		| 3    | 2    | 1    | -1   |
		| 4    | 3    | 6    | 5    |
		| 1    | 2    | 7    | 8    |
	And a matrix C:
		| col0 | col1 | col2 | col3 |
		| 20   | 22   | 50   | 48   |
		| 44   | 54   | 114  | 108  |
		| 40   | 58   | 110  | 102  |
		| 16   | 26   | 46   | 42   |
	When matrix A is multiplied by matrix B
	Then matrix result is equal to matrix C

Scenario: Multiplying two matrices of different sizes
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	And a matrix B:
		| col0 | col1 |
		| 20   | 22   |
		| 44   | 54   |
	When matrix A is multiplied by matrix B
	Then an ArgumentException was thrown

Scenario: A matrix multiplied by a tuple
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 1    | 2    | 3    | 4    |
		| 2    | 4    | 4    | 2    |
		| 8    | 6    | 4    | 1    |
		| 0    | 0    | 0    | 1    |
	And a tuple(1, 2, 3, 1) b
	When matrix A is multiplied by tuple b
	Then tuple result is equal to tuple(18, 24, 33, 1)

Scenario: Multiplying a matrix by the identity matrix
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 0    | 1    | 2    | 4    |
		| 1    | 2    | 4    | 8    |
		| 2    | 4    | 8    | 16   |
		| 4    | 8    | 16   | 32   |
	Given a matrix identity:
		| col0 | col1 | col2 | col3 |
		| 1    | 0    | 0    | 0    |
		| 0    | 1    | 0    | 0    |
		| 0    | 0    | 1    | 0    |
		| 0    | 0    | 0    | 1    |
	When matrix A is multiplied by matrix identity
	Then matrix result is equal to matrix A

Scenario: Multiplying the identity matrix by a tuple
	Given a tuple(1, 2, 3, 4) A
	And a matrix identity:
		| col0 | col1 | col2 | col3 |
		| 1    | 0    | 0    | 0    |
		| 0    | 1    | 0    | 0    |
		| 0    | 0    | 1    | 0    |
		| 0    | 0    | 0    | 1    |
	When matrix identity is multiplied by tuple A
	Then tuple result is equal to tuple(1, 2, 3, 4)
