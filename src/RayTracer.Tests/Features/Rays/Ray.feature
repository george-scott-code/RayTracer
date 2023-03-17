Feature: Ray

Scenario: Creating and querying a ray
	Given an origin point (1, 2, 3) origin
	And a direction vector (4, 5, 6) direction
	And a ray (origin, direction) r
	Then the origin of ray r is equal to point origin
	And the direction of ray r is equal to vector direction