
#  Nebula Nexus
A classic space shooter game build implementing Object Pooling, State Machine and OOPS in Unity.

## Goal
The main goal of the project was build - 
1. A pool system for Bullets and Powerups
2. State machine for Enemy movement and Shooting State
3. Background Scrolling using UV Rect
4. Use Service Locator, MVC and Observer pattern as well

## Gameplay
Use **WASD** or **Left**/**Right** key to move player ship. Use Left mouse button to shoot bullet. 

After every interval a powerup is spawned which changes shooting style for player.
![Home](https://github.com/Roopesh16/Nebula-Nexus/blob/main/Pics/Home.png)

![Gameplay](https://github.com/Roopesh16/Nebula-Nexus/blob/main/Pics/Gameplay%20%282%29.png)

![Gameplay](https://github.com/Roopesh16/Nebula-Nexus/blob/main/Pics/Gameplay%20%283%29.png)

## Architecture
The architecture for code was broken down in following ways - 
1. Use Service Locator for communication between Services
2. MVC pattern for different entities in game
3. Generic Object Pool for Bullet and Powerup spawn
4. State Machine for Enemy state change
5. Observer pattern for Play, Game Over events

## Conclusion
I build this project over the course of 2 days and its been an incredible learning curve.