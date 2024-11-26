# Flappy Bird Clone - Unity Project

This is a simple Flappy Bird-style game built in Unity. The game features a player-controlled character navigating through gaps in pipes while collecting points. This README provides an overview of the project and a breakdown of each script used in the game.

---

## Table of Contents
1. [Overview](#overview)
2. [How to Play](#how-to-play)
3. [Scripts](#scripts)
   - [Scoring.cs](#scoringcs)
   - [Player.cs](#playercs)
   - [PipeSpawner.cs](#pipespawnercs)
   - [Parallax.cs](#parallaxcs)
   - [Mover.cs](#movercs)
   - [GameManager.cs](#gamemanagercs)
4. [Setup](#setup)

---

## Overview

In this game, the player controls a character that flaps upward by clicking or pressing a key, while gravity pulls the character downward. The objective is to navigate through gaps between pipes without hitting them or the ground, earning points for each successful gap crossed.

### Key Features:
- Scrolling background (parallax effect)
- Randomized pipe spawning
- Score tracking
- Game Over and reset functionality
- Smooth sprite animations for the player

---

## How to Play

1. Press the **Play** button to start the game.
2. Use the **Spacebar** or **Left Mouse Button** to make the player move upward.
3. Avoid colliding with the pipes or the ground.
4. Aim to get the highest score possible!
5. If you lose, press the **Play** button again to restart.

---

## Scripts

### Scoring.cs
This script tracks the player's score and updates the score display.

- **Purpose**: Detects when the player successfully navigates through a pipe and increments the score.
- **Key Features**:
  - Detects collisions with objects of a specific tag (e.g., "ScoreZone").
  - Updates the `TextMeshProUGUI` score display.
  - Includes a `ResetScore()` method for resetting the score when restarting the game.

---

### Player.cs
This script handles the player's movement and sprite animation.

- **Purpose**: Controls the player's vertical movement and applies gravity, allowing the character to "flap" upwards.
- **Key Features**:
  - Uses Unity's `InputAction` to bind controls (e.g., spacebar or mouse click).
  - Simulates gravity and upward movement when controls are pressed.
  - Animates the player's sprite for a visual flapping effect.
  - Includes functionality for re-enabling the player on game reset.

---

### PipeSpawner.cs
This script spawns pipes at regular intervals with randomized vertical positions.

- **Purpose**: Creates an endless series of obstacles for the player.
- **Key Features**:
  - Instantiates pipe prefabs at a defined spawn rate.
  - Randomizes pipe heights within a specified range.
  - Automatically starts and stops spawning based on the game's state.

---

### Parallax.cs
This script simulates a scrolling background for visual depth.

- **Purpose**: Provides a dynamic parallax effect by moving the background texture.
- **Key Features**:
  - Continuously scrolls the background texture at a configurable speed.
  - Resets the texture offset seamlessly for smooth animation.

---

### Mover.cs
This script moves game objects, such as pipes, from right to left.

- **Purpose**: Gives the appearance of pipes moving toward the player, simulating forward motion.
- **Key Features**:
  - Moves objects at a constant speed.
  - Destroys objects once they exit the screen, freeing up memory.

---

### GameManager.cs
This script manages the overall game flow, including starting, pausing, and resetting the game.

- **Purpose**: Handles game states, such as "Play" and "Game Over."
- **Key Features**:
  - Pauses and resumes the game by modifying `Time.timeScale`.
  - Resets the player's position and score on game restart.
  - Detects collisions that trigger the game-over state.
  - Destroys all pipes upon game reset to clear the screen.

---

## Setup

1. **Unity Version**: Ensure you are using Unity 2021 or newer.
2. **Import the Project**: Clone or download the repository and open it in Unity.
3. **Scene Configuration**:
   - Assign all required GameObjects to their corresponding script fields in the Inspector.
   - Configure pipe prefabs, score zones, and player GameObjects as needed.
4. **Input Bindings**: Customize input bindings in `Player.cs` to match your preferred controls.

---

Enjoy playing this Flappy Bird clone and tweak the game to your liking! 🎮
