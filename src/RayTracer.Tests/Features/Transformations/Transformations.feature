Feature: Transformations

Scenario: Multiplying by a translation matrix
	Given a transform (5, -3, 2)
	And a point(-3, 4, 5) p
	When point p is multiplied by the transform
	Then the result is equal to point(2, 1, 7)

Scenario: Multiplying by the inverse of a translation matrix
	Given a transform (5, -3, 2)
	And a point(-3, 4, 5) p
	When the inverse of the transform is calculated
	And point p is multiplied by the transform
	Then the result is equal to point(-8, 7, 3)
	
Scenario: Translation does not affect vectors
	Given a transform (5, -3, 2)
	And a vector(-3, 4, 5) v
	When vector v is multiplied by the transform
	Then the result is equal to vector(-3, 4, 5)