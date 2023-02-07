Feature: Canvas
Simple Canvas implementation

# Construction
Scenario: Creating a canvas
	Given a canvas(10, 20)
	Then the width of the canvas is 10
	And the height of the canvas is 20
	And every pixel of the canvas is color(0, 0, 0)

Scenario: Writing pixels to a canvas
	Given a canvas(10, 20)
	And a color(1, 0, 0) red
	When write_pixel(c, 2, 3, red)
	Then pixel_at(c, 2, 3) = red

Scenario: Constructing the PPM header
	Given a canvas(5, 3)
	When the canvas is converted to ppm
	Then line 1 of the ppm is P3
	And line 2 of the ppm is 5 3
	And line 3 of the ppm is 255