Feature: sphere

Scenario: A sphere's default transformation
	Given a sphere s
	And a matrix identity:
		| col0 | col1 | col2 | col3 |
		| 1    | 0    | 0    | 0    |
		| 0    | 1    | 0    | 0    |
		| 0    | 0    | 1    | 0    |
		| 0    | 0    | 0    | 1    |
	Then the transform of sphere s is equal to matrix identity

Scenario: Changing a sphere's transformation
	Given a sphere s
	And a translation (2, 3, 4) t
	When sphere s has transform t
	Then the transform of sphere s is equal to transform t

Scenario: Intersecting a scaled sphere with a ray
	Given an origin point (0, 0, -5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	And a scaling (2, 2, 2) t
	And sphere s has transform t
	When the intersection xs is calculated for sphere s and ray r
	Then the intersection xs has count 2
	And the intersection xs index 0 = 3.0
	And the intersection xs index 1 = 7.0