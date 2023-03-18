Feature: Ray

Scenario: Creating and querying a ray
	Given an origin point (1, 2, 3) origin
	And a direction vector (4, 5, 6) direction
	And a ray (origin, direction) r
	Then the origin of ray r is equal to point origin
	And the direction of ray r is equal to vector direction

Scenario: Computing a point from a distance
	Given an origin point (2, 3, 4) origin
	And a direction vector (1, 0, 0) direction
	And a ray (origin, direction) r
	When the position p of ray r is calculated for t = 0
	Then position p is equal to point (2, 3, 4)
	When the position p1 of ray r is calculated for t = 1
	Then position p1 is equal to point (3, 3, 4)
	When the position p2 of ray r is calculated for t = -1
	Then position p2 is equal to point (1, 3, 4)
	When the position p3 of ray r is calculated for t = 2.5
	Then position p3 is equal to point (4.5, 3, 4)

Scenario: A ray intersects a sphere at two points
	Given an origin point (0, 0, -5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	When the intersection xs is calculated for sphere s and ray r
	Then the result of the intersection has count 2
	And the result of the intersection index 0 = 4.0
	And the result of the intersection index 1 = 6.0

Scenario: A ray intersects at a tangent
	Given an origin point (0, 1, -5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	When the intersection xs is calculated for sphere s and ray r
	Then the result of the intersection has count 2
	And the result of the intersection index 0 = 5.0
	And the result of the intersection index 1 = 5.0

Scenario: A ray does not intersect a sphere
	Given an origin point (0, 2, -5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	When the intersection xs is calculated for sphere s and ray r
	Then the result of the intersection has count 0

Scenario: A ray originates inside a sphere
	Given an origin point (0, 0, 0) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	When the intersection xs is calculated for sphere s and ray r
	Then the result of the intersection has count 2
	And the result of the intersection index 0 = -1.0
	And the result of the intersection index 1 = 1.0

Scenario: A sphere is behind a ray
	Given an origin point (0, 0, 5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	When the intersection xs is calculated for sphere s and ray r
	Then the result of the intersection has count 2
	And the result of the intersection index 0 = -6.0
	And the result of the intersection index 1 = -4.0

# TODO: make sure the intersections are returned in
# increasing order, to make it easier to determine which intersections are sig-
# nificant, later.