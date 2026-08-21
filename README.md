# Doofus Adventure
A 3D platform-survival game developed as part of the Hitwicket Game Developer Challenge 2026.

## 🎮 Game Overview
Doofus is a cube exploring a series of green platforms called **Pulpits**.
Each Pulpit exists only for a limited amount of time. Doofus must move from one Pulpit to another before the current platform disappears.
The objective is to survive as long as possible and achieve the highest score.
If Doofus walks off a Pulpit or the Pulpit disappears while he is standing on it, he falls and the game ends.

## 🎥 Gameplay Demo
https://drive.google.com/file/d/1jJLVlPQA4s1_5yvgtK6ROKR7g6ext11H/view?usp=sharing

| Start Screen | In-Game | Game Over |
|---|---|---|
| ![Start](media/StartMenu.png) | ![Score](media/ScoreUI.png) | ![Game Over](media/GameOverMenu.png) |

## 🎯 Features
- WASD and Arrow Key movement
- Random adjacent Pulpit generation
- Pulpit lifetime countdown
- Automatic Pulpit destruction
- Score tracking for successfully reached Pulpits
- Start screen
- Game Over screen
- Game state management
- Configuration loaded from the provided JSON file
- 3D gameplay environment
- Custom UI and visual presentation

## 🏆 Assignment Levels

### Level 1 — Character Movement & Pulpits
- Doofus movement implemented using WASD / Arrow Keys
- Movement speed loaded from the Doofus Diary JSON
- Pulpits spawn adjacent to the previous Pulpit
- Pulpit spawn and destruction timings are loaded from JSON
- Each Pulpit displays its remaining lifetime

### Level 2 — Score System
- Score increases when Doofus successfully moves onto a different Pulpit
- Score is displayed through an in-game HUD
- Score is maintained independently from the Pulpit spawning system

### Level 3 — Start & Game Over
- Start screen before gameplay
- Gameplay begins only after pressing Start
- Game Over is triggered when Doofus falls
- Game Over screen displays after the run ends

## ⚙️ Configuration
Gameplay values are read from the provided **Doofus Diary JSON** rather than being hardcoded.
The configuration controls values such as:
- Doofus movement speed
- Minimum Pulpit destruction time
- Maximum Pulpit destruction time
- Pulpit spawn timing

## 🚀 How to Run
1. Clone this repository
2. Open the project in Unity 6+ (tested on Unity 6.3 LTS)
3. Open `Assets/Scenes/Game.unity`
4. Press Play in the Unity Editor

## 🧩 Project Structure
```text
Assets/
├── Scripts/
│   ├── GameConfig.cs
│   ├── GameSession.cs
│   ├── DoofusController.cs
│   ├── PulpitManager.cs
│   ├── PulpitTimer.cs
│   └── ScoreManager.cs
│
├── Scenes/
├── Prefabs/
├── Materials/
└── ...
```
