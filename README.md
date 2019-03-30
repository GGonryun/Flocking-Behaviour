# Flocking-Behaviour
Fall 2019 CS-596 school project made to display the various types of AI flocking behaviours.

![Game Screen](https://github.com/GGonryun/Flocking-Behaviour/blob/master/Flocking1.png?raw=true)
## Features:
4 Unique Flocking Behaviors:
##### No targeting\*
- \**No behaviour is technically a behaviour!*
##### Follow the leader
- Use QWEASD to move the leader around the school.
|Control|Direction|
|:-:|:-:|
| Q & E | Up & Down |
| W & S | Forwards & Backwards |
| A & D | Left & Right |
##### Go in circles
- The flock will go in circles following waypoints as they go along.
##### Lazy flocking mode (Random mode)
- The flock will target random way points that will spawn on the map.

## Menu:

![Game Screen](https://github.com/GGonryun/Flocking-Behaviour/blob/master/Flock2.png?raw=true)

#### Flock Size:
Changes the number of boids in the flock real-time.
#### Flock Speed
Changes the movement speed of the boids in the flock.
#### Alignment
Determines how much weight alignment is given.

Alignment is determined as the average direction that the flock currently moving towards.
#### Cohesion
Determines how much cohesion a flock has relative to its target point.

Cohesion is determined as the distance to the center of the target, the closer the cohesion is to 0 the closer that the flock is towards the center of the target.
#### Separation
Determines how spread apart boids will be from their target.

The larger the value the more spread apart boids will appear to be. They will also attempt to seperate from eachother but not much.
#### Follow
Determines the weight given to following a target.

The higher the value the faster boids respond to a moving target, best used in "Follow the leader" mode.

## Resources:
https://github.com/PacktPublishing/Unity-2017-Game-AI-Programming-Third-Edition/
