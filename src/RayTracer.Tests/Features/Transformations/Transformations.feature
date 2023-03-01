Feature: Transformations

#translation

Scenario: Multiplying by a translation matrix
	Given a translation (5, -3, 2)
	And a point(-3, 4, 5) p
	When point p is multiplied by the transform
	Then the result is equal to point(2, 1, 7)

Scenario: Multiplying by the inverse of a translation matrix
	Given a translation (5, -3, 2)
	And a point(-3, 4, 5) p
	When the inverse of the transform is calculated
	And point p is multiplied by the transform
	Then the result is equal to point(-8, 7, 3)
	
Scenario: Translation does not affect vectors
	Given a translation (5, -3, 2)
	And a vector(-3, 4, 5) v
	When vector v is multiplied by the transform
	Then the result is equal to vector(-3, 4, 5)

#scaling

Scenario: A scaling matrix applied to a point
	Given a scaling (2, 3, 4)
	And a point(-4, 6, 8) p
	When point p is multiplied by the transform
	Then the result is equal to point(-8, 18, 32)

Scenario: A scaling matrix applied to a vector
	Given a scaling (2, 3, 4)
	And a vector(-4, 6, 8) v
	When vector v is multiplied by the transform
	Then the result is equal to vector(-8, 18, 32)

Scenario: Multiplying by the inverse of a scaling matrix
	Given a scaling (2, 3, 4)
	And a vector(-4, 6, 8) v
	When the inverse of the transform is calculated
	And vector v is multiplied by the transform
	Then the result is equal to vector(-2, 2, 2)

Scenario: Reflection is scaling by a negative value
	Given a scaling (-1, 1, 1)
	And a point(2, 3, 4) p
	When point p is multiplied by the transform
	Then the result is equal to point(-2, 3, 4)

#rotation

Scenario: Rotating a point around the x axis
	Given a point(0, 1, 0) p
	And a rotation_x(π / 4) half_quarter
	When point p is multiplied by the transform
	Then the result is equal to point(0, 0.70710678118, 0.70710678118)

Scenario: Rotating a point around the x axis - quarter
	Given a point(0, 1, 0) p
	And a rotation_x(π / 2) full_quarter
	When point p is multiplied by the transform
	Then the result is equal to point(0, 0, 1)

Scenario: The inverse of an x-rotation rotates in the opposite direction
	Given a point(0, 1, 0) p
	And a rotation_x(π / 2) full_quarter
	When the inverse of the transform is calculated
	And point p is multiplied by the transform
	Then the result is equal to point(0, 0, -1)