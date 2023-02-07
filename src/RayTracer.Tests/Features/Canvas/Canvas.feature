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

# Scenario: Constructing the PPM pixel data
# 	Given c ← canvas(5, 3)
# 	And c1 ← color(1.5, 0, 0)
# 	And c2 ← color(0, 0.5, 0)
# 	And c3 ← color(-0.5, 0, 1)
# 	When write_pixel(c, 0, 0, c1)
# 	And write_pixel(c, 2, 1, c2)
# 	And write_pixel(c, 4, 2, c3)
# 	And ppm ← canvas_to_ppm(c)
# 	Then lines 4-6 of ppm are
# 	"""
# 	255 0 0 0 0 0 0 0 0 0 0 0 0 0 0
# 	0 0 0 0 0 0 0 128 0 0 0 0 0 0 0
# 	0 0 0 0 0 0 0 0 0 0 0 0 0 0 255
# 	"""