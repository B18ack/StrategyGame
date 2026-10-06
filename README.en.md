[🇷🇺 Русский](README.md) | 🇬🇧 English

# Strategy Game

A strategy game built with **Unity 6** (6000.4) and the **Universal Render Pipeline (URP)**. Build your base, produce vehicles and destroy the enemy cars.

<img width="1483" height="639" alt="image" src="https://github.com/user-attachments/assets/42463996-7adf-45bb-b31e-7b7b130dfcc9" />


## Story

Several years have passed since the old world fell. The roads are empty, the cities lie in ruins, and what was left of the army has scattered across the wasteland.

You command a small advance squad. Your mission is to secure a foothold on neutral ground, build a base and assemble a combat force. But you are not alone. Enemies already rule the area: their fast combat cars patrol the region and attack anyone who enters their territory.

Build your defenses, set up production and take the land back from the enemy, step by step.

## Gameplay
<img width="1484" height="637" alt="image" src="https://github.com/user-attachments/assets/36439bbb-26fd-4f3a-9058-adba51289f33" />


### Buildings

| Building | What it does |
|----------|--------------|
| 🏠 **House** | Spawns combat cars that shoot at enemy cars. |
| 🏭 **Hangar** | Spawns tanks. |

You can place a building on the map after rotating it to face the direction you want.

### Vehicles

- **Combat cars**: fast vehicles that shoot at enemy cars. Spawned from the house.
- **Tanks**: heavy vehicles. Spawned from the hangar.

## Controls

| Key | Action |
|-----|--------|
| **W / A / S / D** | Move the camera |
| **Q** | Rotate left |
| **E** | Rotate right |
| **Shift** | Speed up the action: the camera moves faster, and a building rotates faster while being placed |

## Features

- [x] Game map and environment
- [x] Camera controls
- [x] Building placement with rotation
- [x] House that spawns combat cars
- [x] Hangar that spawns tanks
- [x] Enemy cars
- [ ] New building types
- [ ] Enemy AI


## Getting Started

1. Install **Unity Hub** and **Unity 6000.4.3f1** (the exact version is listed in `ProjectSettings/ProjectVersion.txt`).
2. Clone the repository:
   ```
   git clone https://github.com/B18ack/StrategyGame.git
   ```
3. In Unity Hub, click **Add → Add project from disk** and select the project folder.
4. Open the scene `Assets/Scenes/MainScene` and press **Play**.

The first launch may take a few minutes while Unity regenerates the `Library` folder.

## Assets Used

- Brick House
- ithappy: Military Free
- Military Pack (Off-road vehicle)
- Simple Nature Pack

## Author

[B18ack](https://github.com/B18ack)
