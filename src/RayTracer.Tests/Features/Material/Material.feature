Feature: Material
Matrial Lighting

Background:
	Given a material m
	And a point (0, 0, 0) position

Scenario: Lighting with the eye between the light and the surface
	Given a vector (0, 0, -1) eyev
	And a vector (0, 0, -1) normalv
	And a color(1, 1, 1) intensity
	And light = point_light(position, intensity)
	# And light ← point_light(point(0, 0, -10), color(1, 1, 1))
	# When result ← lighting(m, light, position, eyev, normalv)
	# Then result = color(1.9, 1.9, 1.9)