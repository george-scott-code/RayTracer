Feature: Material
Matrial Lighting

Background:
	Given a material m
	And a point (0, 0, 0) position

Scenario: Lighting with the eye between the light and the surface
	Given a vector (0, 0, -1) eyev
	And a vector (0, 0, -1) normalv
	And a point_light(point(0, 0, -10), color(1, 1, 1)) light
	When the color result is lighting (m, light, position, eyev, normalv)
	Then the color result is color(1.9, 1.9, 1.9)

Scenario: Lighting with the eye between light and surface, eye offset 45°
	Given a vector (0, 0.707106, -0.707106) eyev
	And a vector (0, 0, -1) normalv
	And a point_light(point(0, 0, -10), color(1, 1, 1)) light
	When the color result is lighting (m, light, position, eyev, normalv)
	Then the color result is color(1.0, 1.0, 1.0)

Scenario: Lighting with eye opposite surface, light offset 45°
	Given a vector (0, 0, -1) eyev
	And a vector (0, 0, -1) normalv
	And a point_light(point(0, 10, -10), color(1, 1, 1)) light
	When the color result is lighting (m, light, position, eyev, normalv)
	Then the color result is color(0.7364, 0.7364, 0.7364)

Scenario: Lighting with eye in the path of the reflection vector
	Given a vector (0, -0.70710678118, -0.70710678118) eyev
	And a vector (0, 0, -1) normalv
	And a point_light(point(0, 10, -10), color(1, 1, 1)) light
	When the color result is lighting (m, light, position, eyev, normalv)
	Then the color result is color(1.6364, 1.6364, 1.6364)

Scenario: Lighting with the light behind the surface
	Given a vector (0, 0, -1) eyev
	And a vector (0, 0, -1) normalv
	And a point_light(point(0, 0, 10), color(1, 1, 1)) light
	When the color result is lighting (m, light, position, eyev, normalv)
	Then the color result is color(0.1, 0.1, 0.1)

Scenario: Creating a world
	Given a world w
	Then world w has light null
	And world w has no objects

Scenario: The default world
	Given a point_light(point(-10, 10, -10), color(1, 1, 1)) light
	And a sphere s1
	And material m with:
		| parameter         | value			|
		| material.color    | 0.8, 1.0, 0.6 |
		| material.diffuse  | 0.7           |
		| material.specular | 0.2           |
	And sphere s1 has material m
	And a sphere s2 with:
		| parameter         | value			  	  |
		| transform 		| scaling 0.5,0.5,0.5 |
	And a default_world w
	Then world w has light is light
	And world w contains object s1
	And world w contains object s2