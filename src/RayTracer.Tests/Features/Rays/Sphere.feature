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

Scenario: A sphere has a default material
	Given a sphere s
	And a material m
	Then the sphere s has material m

Scenario: A sphere may be assigned a material
	Given a sphere s
	And a material m
	When material m has ambient 1
	And sphere s has material m
	Then the sphere s has material m

Scenario: Changing a sphere's transformation
	Given a sphere s
	And a translation (2, 3, 4) t
	When sphere s has transform t
	Then the transform of sphere s is equal to transform t

Scenario: Intersecting a scaled sphere with a ray
	Given a point (0, 0, -5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	And a scaling (2, 2, 2) t
	And sphere s has transform t
	When the intersection xs is calculated for sphere s and ray r
	Then the intersection xs has count 2
	And the intersection xs index 0 = 3.0
	And the intersection xs index 1 = 7.0

Scenario: Intersecting a translated sphere with a ray
	Given a point (0, 0, -5) origin
	And a direction vector (0, 0, 1) direction
	And a ray (origin, direction) r
	And a sphere s
	And a translation (5, 0, 0) t
	And sphere s has transform t
	When the intersection xs is calculated for sphere s and ray r
	Then the intersection xs has count 0

# surface normals

Scenario: The normal on a sphere at a point on the x axis
	Given a sphere s
	And a point (1, 0, 0) p
	When the normal n is calculated for point p
	Then the vector n is equal to vector (1, 0, 0)

Scenario: The normal on a sphere at a point on the y axis
	Given a sphere s
	And a point (0, 1, 0) p
	When the normal n is calculated for point p
	Then the vector n is equal to vector (0, 1, 0)

Scenario: The normal on a sphere at a point on the z axis
	Given a sphere s
	And a point (0, 0, 1) p
	When the normal n is calculated for point p
	Then the vector n is equal to vector (0, 0, 1)

Scenario: The normal on a sphere at a nonaxial point
	Given a sphere s
	# √3/3
	And a point (0.577350, 0.577350, 0.577350) p 
	When the normal n is calculated for point p
	Then the vector n is equal to vector (0.577350, 0.577350, 0.577350)

Scenario: The normal is a normalized vector
	Given a sphere s
	And a point (0.577350, 0.577350, 0.577350) p 
	When the normal n is calculated for point p
	Then the vector n is normalized

Scenario: Computing the normal on a translated sphere
	Given a sphere s
	And a translation (0, 1, 0) t
	And sphere s has transform t
	And a point (0, 1.70711, -0.70711) p 
	When the normal n is calculated for point p
	Then the vector n is equal to vector (0, 0.70711, -0.70711)

Scenario: Computing the normal on a transformed sphere
	Given a sphere s
	And a rotation_x (π / 5) rz
	And a scaling (1, 0.5, 1) s
	And transform t = transform s * transform rz
	And sphere s has transform t
	And a point (0, 0.707106, -0.707106) p 
	When the normal n is calculated for point p
	Then the vector n is equal to vector (0, 0.97014, -0.24254)