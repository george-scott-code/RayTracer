Feature: Colors
Simple Color implementation

# Construction
Scenario: Colors are (red, green, blue) tuples
	Given a color(-0.5, 0.4, 1.7)
	Then c.red = -0.5
	And c.green = 0.4
	And c.blue = 1.7

# Addition

Scenario: Adding colors
	Given a color(0.9, 0.6, 0.75)
	And a color(0.7, 0.1, 0.25)
	When c1 is added to c2
	Then the result is color(1.6, 0.7, 1.0)

# Subtraction
Scenario: Subtracting colors
	Given a color(0.9, 0.6, 0.75)
	And a color(0.7, 0.1, 0.25)
	When c2 is subtracted from c1
	Then the result is color(0.2, 0.5, 0.5)

# Multiplication
Scenario: Multiplying a color by a scalar
	Given a color(0.2, 0.3, 0.4)
	When c is multiplied by 2
	Then the result is color(0.4, 0.6, 0.8)

Scenario: Multiplying two colors
	Given a color(1, 0.2, 0.4)
	And a color(0.9, 1, 0.1)
	When c1 is multiplied by c2
	Then the result is color(0.9, 0.2, 0.04)