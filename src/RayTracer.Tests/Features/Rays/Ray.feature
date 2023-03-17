Feature: Ray

Scenario: Creating and querying a ray
	Given an origin point (1, 2, 3) origin
	And a direction vector (4, 5, 6) direction
	And a ray (origin, direction) r
	Then the origin of ray r is equal to point origin
	And the direction of ray r is equal to vector direction

Scenario: Computing a point from a distance
	# Given r ← ray(point(2, 3, 4), vector(1, 0, 0))
	Given an origin point (2, 3, 4) origin
	And a direction vector (1, 0, 0) direction
	And a ray (origin, direction) r
	When the position p of ray r is calculated for t = 0
	Then position p is equal to point (2, 3, 4)
	# And position(r, 1) = point(3, 3, 4)
	# And position(r, -1) = point(1, 3, 4)
	# And position(r, 2.5) = point(4.5, 3, 4)