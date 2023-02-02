Feature: Colors
Simple Color implementation

# Construction

Scenario: Colors are (red, green, blue) tuples
	Given a color(-0.5, 0.4, 1.7)
	Then c.red = -0.5
	And c.green = 0.4
	And c.blue = 1.7