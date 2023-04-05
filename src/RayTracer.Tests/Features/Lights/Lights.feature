Feature: Lights
Simple Light implementation

# Construction

Scenario: A point light has a position and intensity
	Given a color(1, 1, 1) intensity
	And position = point(0, 0, 0)
	When light = point_light(position, intensity)
	Then light.position = position
	And light.intensity = intensity

Scenario: The default material
	Given a material m
	And a color(1, 1, 1) c
	Then the material m has color c
	And the material m has ambient 0.1
	And the material m has diffuse 0.9
	And the material m has specular 0.9
	And the material m has shininess 200.0