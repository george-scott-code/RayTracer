Feature: Material
Matrial Lighting

Background:
	Given a material m
	And a point (0, 0, 0) position

Scenario: Lighting with the eye between the light and the surface
	Given a vector (0, 0, -1) eyev
	And a vector (0, 0, -1) normalv
	And a color(1, 1, 1) intensity
	And a point (0, 0, -10) poisiton
	And a point_light (position, intensity) light