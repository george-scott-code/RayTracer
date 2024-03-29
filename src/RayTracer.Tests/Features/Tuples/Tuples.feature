Feature: Tuples
Simple Tuple implementation

# Construction

Scenario: A tuple with w=1.0 is a point
	Given a tuple(4.3, -4.2, 3.1, 1.0)
	When the result is a
	Then a.x = 4.3
	And a.y = -4.2
	And a.z = 3.1
	And a.w = 1.0
	And a is a point
	And a is not a vector

Scenario: A tuple with w=0 is a vector
	Given a tuple(4.3, -4.2, 3.1, 0.0)
	When the result is a
	Then a.x = 4.3
	And a.y = -4.2
	And a.z = 3.1
	And a.w = 0.0
	And a is not a point
	And a is a vector

Scenario: point() creates tuples with w=1
	Given a point(4.3, -4.2, 3.1)
	When the result is a
	Then a.x = 4.3
	And a.y = -4.2
	And a.z = 3.1
	And a.w = 1.0
	And a is a point
	And a is not a vector

Scenario: vector() creates tuples with w=0
	Given a vector(4.3, -4.2, 3.1)
	When the result is a
	Then a.x = 4.3
	And a.y = -4.2
	And a.z = 3.1
	And a.w = 0.0
	And a is not a point
	And a is a vector

# Addition

Scenario: Adding two tuples
	Given a tuple(3, -2, 5, 1)
	And a tuple(-2, 3, 1, 0)
	When a1 is added to a2
	Then the result is tuple(1, 1, 6, 1)

Scenario: Adding a Vector to A Point is a Point
	Given a point(1, 2, 3)
	And a vector(1, 2, 3)
	When a1 is added to a2
	Then the result is tuple(2, 4, 6, 1)
	And a is a point

Scenario: Adding a Vector to a Vector is a Vector
	Given a vector(1, 2, 3)
	And a vector(1, 2, 3)
	When a1 is added to a2
	Then the result is tuple(2, 4, 6, 0)
	And a is a vector

Scenario: Adding a Point to a Point is a something
	Given a point(1, 2, 3)
	And a point(1, 2, 3)
	When a1 is added to a2
	Then the result is tuple(2, 4, 6, 2)
	And a is not a point
	And a is not a vector

# Subtraction

Scenario: Subtracting two points
	Given a point(3, 2, 1)
	And a point(5, 6, 7)
	When a2 is subtracted from a1
	Then the result is tuple(-2, -4, -6, 0)
	And a is a vector

Scenario: Subtracting a vector from a point
	Given a point(3, 2, 1)
	And a vector(5, 6, 7)
	When a2 is subtracted from a1
	Then the result is tuple(-2, -4, -6, 1)
	And a is a point

Scenario: Subtracting two vectors
	Given a vector(3, 2, 1)
	And a vector(5, 6, 7)
	When a2 is subtracted from a1
	Then the result is tuple(-2, -4, -6, 0)
	And a is a vector

# Negating Tuples

Scenario: Subtracting a vector from the zero vector
	Given a vector(0, 0, 0)
	And a vector(1, -2, 3)
	When a2 is subtracted from a1
	Then the result is tuple(-1, 2, -3, 0)
	And a is a vector

Scenario: Negating a tuple
	Given a tuple(1, -2, 3, -4)
	When the tuple is negated
	Then the result is tuple(-1, 2, -3, 4)

# Scalar Multiplication and Division

Scenario: Multiplying a tuple by a scalar
	Given a tuple(1, -2, 3, -4)
	When the tuple is multiplied by 3.5
	Then the result is tuple(3.5, -7, 10.5, -14)

Scenario: Multiplying a tuple by a fraction
	Given a tuple(1, -2, 3, -4)
	When the tuple is multiplied by 0.5
	Then the result is tuple(0.5, -1, 1.5, -2)

Scenario: Dividing a tuple by a scalar
	Given a tuple(1, -2, 3, -4)
	When a is divided by 2
	Then the result is tuple(0.5, -1, 1.5, -2)

# Magnitude

Scenario: Computing the magnitude of vector(1, 0, 0)
	Given a vector(1, 0, 0)
	Then a.Magnitude is 1

Scenario: Computing the magnitude of vector(0, 1, 0)
	Given a vector(0, 1, 0)
	Then a.Magnitude is 1

Scenario: Computing the magnitude of vector(0, 0, 1)
	Given a vector(0, 0, 1)
	Then a.Magnitude is 1

Scenario: Computing the magnitude of vector(1, 2, 3)
	Given a vector(1, 2, 3)
	Then a.Magnitude is 3.74165

Scenario: Computing the magnitude of vector(-1, -2, -3)
	Given a vector(-1, -2, -3)
	Then a.Magnitude is 3.74165

# Normalisation

Scenario: Normalizing vector(4, 0, 0) gives (1, 0, 0)
	Given a vector(4, 0, 0)
	When the tuple is normalized
	Then the result is tuple(1, 0, 0, 0)

Scenario: Normalizing vector(1, 2, 3)
	Given a vector(1, 2, 3)
	When the tuple is normalized
	Then the result is tuple(0.26726, 0.53452, 0.80178, 0) 
# ..approximately
# 	vector(1/
# 	√14, 2/
# 	√14, 3/
# 	√14)

Scenario: The magnitude of a normalized vector
	Given a vector(1, 2, 3)
	When the tuple is normalized
	Then the result has a Magnitude of 1

# dot product
Scenario: The dot product of two tuples
	Given a vector(1, 2, 3)
	And a vector(2, 3, 4)
	Then dot(a, b) is 20

# cross product
Scenario: The cross product of two vectors
	Given a vector(1, 2, 3)
	And a vector(2, 3, 4)
	When cross(a, b)
	Then the result is tuple(-1, 2, -1, 0)

Scenario: The cross product of two vectors - order is important
	Given a vector(2, 3, 4)
	And a vector(1, 2, 3)
	When cross(a, b)
	Then the result is tuple(1, -2, 1, 0)

# reflection
Scenario: Reflecting a vector approaching at 45°
	Given a vector(1, -1, 0)
	And a vector(0, 1, 0)
	When reflect(a, b)
	Then the result is tuple(1, 1, 0, 0)

Scenario: Reflecting a vector off a slanted surface
	Given a vector(0, -1, 0)
	And a vector(0.707106, 0.707106, 0)
	When reflect(a, b)
	Then the result is tuple(1, 0, 0, 0)
