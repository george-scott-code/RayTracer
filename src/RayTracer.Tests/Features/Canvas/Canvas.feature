Feature: Canvas
Simple Canvas implementation

# Construction
Scenario: Creating a canvas
	Given a canvas(10, 20)
	Then c.width = 10
	And c.height = 20
	And every pixel of c is color(0, 0, 0)
