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
	When a red pixel is written to (2, 3)
	Then the pixel at (2, 3) is color red

Scenario: Constructing the PPM header
	Given a canvas(5, 3)
	When the canvas is converted to ppm
	Then line 1 of the ppm is P3
	And line 2 of the ppm is 5 3
	And line 3 of the ppm is 255

Scenario: Constructing the PPM pixel data
	Given a canvas(5, 3)
	And a color(1.5, 0, 0) c1
	And a color(0, 0.5, 0) c2
	And a color(-0.5, 0, 1) c3
	When a c1 pixel is written to (0, 0)
	And a c2 pixel is written to (2, 1)
	And a c3 pixel is written to (4, 2)
	When the canvas is converted to ppm
	Then line 4 of the ppm is 255 0 0 0 0 0 0 0 0 0 0 0 0 0 0
	And line 5 of the ppm is 0 0 0 0 0 0 0 128 0 0 0 0 0 0 0
	And line 6 of the ppm is 0 0 0 0 0 0 0 0 0 0 0 0 0 0 255