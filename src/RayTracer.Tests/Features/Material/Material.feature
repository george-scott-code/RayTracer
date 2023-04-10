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

Scenario: The default world
	Given a point_light(point(-10, 10, -10), color(1, 1, 1)) light
	# And a sphere s1 with:
	# | material.color | (0.8, 1.0, 0.6) |
	# | material.diffuse | 0.7 |
	# | material.specular | 0.2 |
	Given a sphere s
	And material m with:
		# | material.color    | (0.8, 1.0, 0.6) |
		| material.diffuse  |  0.7            |
		| material.specular |  0.2            |
	# And the material m has color c
	# And the material m has diffuse 0.7
	# And the material m has specular 0.2
	# And sphere s has material m
	# And s2 ← sphere() with:
	# | transform | scaling(0.5, 0.5, 0.5) |
	# When w ← default_world()
	# Then w.light = light
	# And w contains s1
	# And w contains s2