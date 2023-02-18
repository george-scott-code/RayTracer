Feature: Transformations

Scenario: Multiplying by a translation matrix
	Given a transform (5, -3, 2)
	And a point(-3, 4, 5) p
	When point p is multiplied by the transform
	Then the result is equal to point(2, 1, 7)

# Scenario: Multiplying by the inverse of a translation matrix
# 	Given transform ← translation(5, -3, 2)
# 	And inv ← inverse(transform)
# 	#When the inverse of matrix A is calculated
# 	And p ← point(-3, 4, 5)
# 	Then inv * p = point(-8, 7, 3)

# Scenario: Translation does not affect vectors
# 	Given transform ← translation(5, -3, 2)
# 	And v ← vector(-3, 4, 5)
# 	Then transform * v = v