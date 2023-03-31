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
	Then the intersection xs has count 2
	And the intersection xs index 0 = 4.0
	And the intersection xs index 1 = 6.0

Scenario: A ray intersects at a tangent
	Given an origin point (0, 1, -5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	When the intersection xs is calculated for sphere s and ray r
	Then the intersection xs has count 2
	And the intersection xs index 0 = 5.0
	And the intersection xs index 1 = 5.0

Scenario: A ray does not intersect a sphere
	Given an origin point (0, 2, -5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	When the intersection xs is calculated for sphere s and ray r
	Then the intersection xs has count 0

Scenario: A ray originates inside a sphere
	Given an origin point (0, 0, 0) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	When the intersection xs is calculated for sphere s and ray r
	Then the intersection xs has count 2
	And the intersection xs index 0 = -1.0
	And the intersection xs index 1 = 1.0

Scenario: A sphere is behind a ray
	Given an origin point (0, 0, 5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	When the intersection xs is calculated for sphere s and ray r
	Then the intersection xs has count 2
	And the intersection xs index 0 = -6.0
	And the intersection xs index 1 = -4.0
	And intersection xs index 0 has property obj = s
	And intersection xs index 1 has property obj = s

# TODO: make sure the intersections are returned in
# increasing order, to make it easier to determine which intersections are sig-
# nificant, later.

Scenario: An intersection encapsulates t and object
	Given a sphere s
	And an intersection(3.5, s) i
	Then the intersection i index 0 = 3.5
	And intersection i index 0 has property obj = s

Scenario: Aggregating intersections
	Given a sphere s
	And an intersection(1, s) i1
	And an intersection(2, s) i2
	And intersections(i1, i2) xs
	Then the intersection xs has count 2
	And the intersection xs index 0 = 1
	And the intersection xs index 1 = 2

Scenario: The hit, when all intersections have positive t
	Given a sphere s
	And an intersection(1, s) i1
	And an intersection(2, s) i2
	And intersections(i1, i2) xs
	When the hit is calculated for intersections xs
	Then the hit is equal to intersection i1

Scenario: The hit, when some intersections have negative t
	Given a sphere s
	And an intersection(-1, s) i1
	And an intersection(1, s) i2
	And intersections(i1, i2) xs
	When the hit is calculated for intersections xs
	Then the hit is equal to intersection i2

Scenario: The hit, when all intersections have negative t
	Given a sphere s
	And an intersection(-2, s) i1
	And an intersection(-1, s) i2
	And intersections(i1, i2) xs
	When the hit is calculated for intersections xs
	Then the hit is nothing

Scenario: The hit is always the lowest nonnegative intersection
	Given a sphere s
	And an intersection(5, s) i1
	And an intersection(7, s) i2
	And an intersection(-3, s) i3
	And an intersection(2, s) i4
	And multiple intersections(i1, i2, i3, i4) xs
	When the hit is calculated for intersections xs
	Then the hit is equal to intersection i4

Scenario: Translating a ray
	Given an origin point (1, 2, 3) origin
	And a direction vector (0, 1, 0) direction
	And a ray (origin, direction) r
	And a translation (3, 4, 5) t
	And an origin point (4, 6, 8) xOrigin
	When ray r is multiplied by the transform t
	Then the origin of ray result is equal to point xOrigin
	And the direction of ray result is equal to vector direction

Scenario: Scaling a ray
	Given an origin point (1, 2, 3) origin
	And a direction vector (0, 1, 0) direction
	And a ray (origin, direction) r
	And a scaling (2, 3, 4) t
	And an origin point (2, 6, 12) xOrigin
	And a direction vector (0, 3, 0) xDirection
	When ray r is multiplied by the transform t
	Then the origin of ray result is equal to point xOrigin
	And the direction of ray result is equal to vector xDirection

#sphere
Scenario: A sphere's default transformation
	Given a sphere s
	And a matrix identity:
		| col0 | col1 | col2 | col3 |
		| 1    | 0    | 0    | 0    |
		| 0    | 1    | 0    | 0    |
		| 0    | 0    | 1    | 0    |
		| 0    | 0    | 0    | 1    |
	Then the transform of sphere s is equal to matrix identity
