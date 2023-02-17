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
	When matrix A is multiplied by matrix B to create matrix result
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
	When matrix A is multiplied by matrix B to create matrix result
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
	When matrix A is multiplied by matrix identity to create matrix result
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

Scenario: Transposing a matrix
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 0    | 9    | 3    | 0    |
		| 9    | 8    | 0    | 8    |
		| 1    | 8    | 5    | 3    |
		| 0    | 0    | 5    | 8    |
	And a matrix B:
		| col0 | col1 | col2 | col3 |
		| 0    | 9    | 1    | 0    |
		| 9    | 8    | 8    | 0    |
		| 3    | 0    | 5    | 5    |
		| 0    | 8    | 3    | 8    |
	When matrix A is transposed
	Then matrix result is equal to matrix B

Scenario: Transposing the identity matrix
	Given a matrix identity:
		| col0 | col1 | col2 | col3 |
		| 1    | 0    | 0    | 0    |
		| 0    | 1    | 0    | 0    |
		| 0    | 0    | 1    | 0    |
		| 0    | 0    | 0    | 1    |
	When matrix identity is transposed
	Then matrix result is equal to matrix identity

# Inverting matrices

Scenario: Calculating the determinant of a 2x2 matrix
	Given a matrix A:
		| col0 | col1 |
		| 1    | 5    |
		| -3   | 2    |
	Then the determinant of matrix A is 17

Scenario: A submatrix of a 3x3 matrix is a 2x2 matrix
	Given a matrix A:
		| col0 | col1 | col2 |
		| 1    | 5    | 0    |
		| -3   | 2    | 7    |
		| 0    | 6    | -3   |
	And a matrix B:
		| col0 | col1 |
		| -3   | 2    |
		|  0   | 6    |
	When the submatrix (0, 2) of matrix A is calculated
	Then matrix result is equal to matrix B

Scenario: A submatrix of a 4x4 matrix is a 3x3 matrix
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| -6   | 1    | 1    | 6    |
		| -8   | 5    | 8    | 6    |
		| -1   | 0    | 8    | 2    |
		| -7   | 1    | -1   | 1    |
	And a matrix B:
		| col0 | col1 | col2 |
		| -6   |  1   | 6    |
		| -8   |  8   | 6    |
		| -7   | -1   | 1    |
	When the submatrix (2, 1) of matrix A is calculated
	Then matrix result is equal to matrix B

Scenario: Calculating a minor of a 3x3 matrix
	Given a matrix A:
		| col0 | col1 | col2 |
		| 3    | 5    | 0    |
		| 2    | -1   | -7   |
		| 6    | -1   | 5    |
	When the submatrix (1, 0) of matrix A is calculated
	Then the determinant of matrix result is 25
	And the minor (1, 0) of matrix A is 25

Scenario: Calculating a cofactor of a 3x3 matrix
	Given a matrix A:
		| col0 | col1 | col2 |
		| 3    | 5    | 0    |
		| 2    | -1   | -7   |
		| 6    | -1   | 5    |
	Then the minor (0, 0) of matrix A is -12
	And the minor (1, 0) of matrix A is 25
	And the cofactor (0, 0) of matrix A is -12
	And the cofactor (1, 0) of matrix A is -25

Scenario: Calculating the determinant of a 3x3 matrix
	Given a matrix A:
		| col0 | col1 | col2 |
		| 1    | 2    | 6    |
		| -5   | 8    | -4   |
		| 2    | 6    | 4    |
	Then the cofactor (0, 0) of matrix A is 56
	And the cofactor (0, 1) of matrix A is 12
	And the cofactor (0, 2) of matrix A is -46
	Then the determinant of matrix A is -196

Scenario: Calculating the determinant of a 4x4 matrix
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| -2   | -8   | 3    | 5    |
		| -3   | 1    | 7    | 3    |
		| 1    | 2    | -9   | 6    |
		| -6   | 7    | 7    | -9   |
	Then the cofactor (0, 0) of matrix A is 690
	And the cofactor (0, 1) of matrix A is 447
	And the cofactor (0, 2) of matrix A is 210
	And the cofactor (0, 3) of matrix A is 51
	Then the determinant of matrix A is -4071

Scenario: Testing an invertible matrix for invertibility
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 6    | 4    | 4    | 4    |
		| 5    | 5    | 7    | 6    |
		| 4    | -9   | 3    | -7   |
		| 9    | 1    | 7    | -6   |
	Then the determinant of matrix A is -2120
	And the matrix A is invertible

Scenario: Testing a noninvertible matrix for invertibility
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| -4   | 2    | -2   | -3   |
		| 9    | 6    | 2    | 6    |
		| 0    | -5   | 1    | -5   |
		| 0    | 0    | 0    | 0    |
	Then the determinant of matrix A is 0
	And the matrix A is not invertible

# inversion

Scenario: Calculating the inverse of a matrix
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| -5   | 2    | 6    | -8   |
		| 1    | -5   | 1    | 8    |
		| 7    | 7    | -6   | -7   |
		| 1    | -3   | 7    | 4    |
	And a matrix B:
		| col0     | col1     | col2     | col3     |
		| 0.21805  | 0.45113  | 0.24060  | -0.04511 |
		| -0.80827 | -1.45677 | -0.44361 | 0.52068  |
		| -0.07895 | -0.22368 | -0.05263 | 0.19737  |
		| -0.52256 | -0.81391 | -0.30075 | 0.30639  |
	Then the determinant of matrix A is 532
	And the cofactor (2, 3) of matrix A is -160
	And the cofactor (3, 2) of matrix A is 105
	When the inverse of matrix A is calculated
	Then matrix result is equal to matrix B
	# -160/532
	And in matrix result the element at (3, 2) is -0.30075
	# 105/532
	And in matrix result the element at (2, 3) is 0.197368 
	
Scenario: Calculating the inverse of another matrix
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 8    | -5   | 9    | 2    |
		| 7    | 5    | 6    | 1    |
		| -6   | 0    | 9    | 6    |
		| -3   | 0    | -9   | -4   |
	And a matrix B:
		| col0     | col1     | col2     | col3     |
		| -0.15385 | -0.15385 | -0.28205 | -0.53846 |
		| -0.07692 | 0.12308  | 0.02564  | 0.03077  |
		| 0.35897  | 0.35897  | 0.43590  | 0.92308  |
		| -0.69231 | -0.69231 | -0.76923 | -1.92308 |
	When the inverse of matrix A is calculated
	Then matrix result is equal to matrix B

Scenario: Calculating the inverse of a third matrix
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 9    | 3    | 0    | 9    |
		| -5   | -2   | -6   | -3   |
		| -4   | 9    | 6    | 4    |
		| -7   | 6    | 6    | 2    |
	And a matrix B:
		| col0     | col1     | col2     | col3     |
		| -0.04074 | -0.07778 | 0.14444  | -0.22222 |
		| -0.07778 | 0.03333  | 0.36667  | -0.33333 |
		| -0.02901 | -0.14630 | -0.10926 | 0.12963  |
		| 0.17778  | 0.06667  | -0.26667 | 0.33333  |
	When the inverse of matrix A is calculated
	Then matrix result is equal to matrix B

Scenario: Multiplying a product by its inverse
	Given a matrix A:
		| col0 | col1 | col2 | col3 |
		| 3    | -9   | 7    | 3    |
		| 3    | -8   | 2    | -9   |
		| -4   | 4    | 4    | 1    |
		| -6   | 5    | -1   | 1    |
	And a matrix B:
		| col0 | col1 | col2 | col3 |
		| 8    | 2    | 2    | 2    |
		| 3    | -1   | 7    | 0    |
		| 7    | 0    | 5    | 4    |
		| 6    | -2   | 0    | 5    |
	When matrix A is multiplied by matrix B to create matrix C
	# Then matrix result is equal to matrix A
	And the inverse of matrix B is calculated
	And matrix C is multiplied by matrix result to create matrix D
	Then matrix D is equal to matrix A