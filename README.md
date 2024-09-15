# Block Drop Survival

**Block Drop Survival** is a simple 2D game where the player avoids falling obstacles while collecting power-ups. The game increases in difficulty over time, making it progressively more challenging as the player survives longer. Power-ups include Shield, Health, and Slow-Motion, which can aid the player in surviving longer against the Block Drop Survival.

## 🎮 Play the Game
You can play the WebGL version of the game online: [**Play Block Drop Survival (WebGL)**](https://play.unity.com/en/games/b501f302-ca2d-41de-a977-485822516f75/block-drop-survival)  


## 🕹️ How to Play
- Move the player left and right using the **arrow keys** or **A/D keys**.
- Avoid Block Drop Survival that will end the game if they hit the player.
- Collect power-ups that appear randomly to gain abilities like:
  - **Shield**: Protects the player from one hit.
  - **Health**: Heals part of the player's health bar.
  - **Slow-Motion**: Temporarily slows the speed of Block Drop Survival.

### Controls
- **Move Left**: `Left Arrow` or `A`
- **Move Right**: `Right Arrow` or `D`


## 🔥 Game Features
- **Dynamic Difficulty**: The game progressively becomes harder as more blocks spawn faster and at greater numbers.
- **Power-Ups**:
  - **Shield**: Protects you from one falling block.
  - **Health**: Restores a portion of the player's health.
  - **Slow-Motion**: Slows the Block Drop Survival for a limited time.
- **Player Health Bar**: Displays the current health of the player.
- **Timers**: Tracks the duration of active power-ups and displays the progress via on-screen meters.

## 💡 Power-Ups
- **Shield**: Provides temporary invulnerability.
- **Slow Motion**: Reduces the speed of Block Drop Survival, giving the player time to react.
- **Health**: Restores a portion of the player's health.

## 📦 How to Build the Game (Unity WebGL)
If you wish to run the game locally or rebuild it:

1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   ```

2. **Open in Unity**:
   - Make sure you have **Unity 2020.x** or newer installed.
   - Open the project in Unity.

3. **Build for WebGL**:
   - Go to **File > Build Settings**.
   - Select **WebGL** as the platform.
   - Click **Build** and choose a directory to save the build.

4. **Run the Game**:
   - After the build completes, you can host the WebGL game on a web server or locally by opening the generated `index.html` file in a browser.

## 🛠️ Development
The game is developed using Unity and the following concepts:
- **Unity 2D Physics**: Used to manage collisions between the player and Block Drop Survival.
- **Timers**: For managing power-up durations like shield and slow motion.
- **Global Speed Manager**: Controls the overall speed of Block Drop Survival and allows for slow-motion effects during gameplay.

## ✨ Future Enhancements
- **Additional Power-Ups**: Adding more types of power-ups to enhance gameplay variety.
- **Levels**: Introduce level-based progression to make the game more dynamic.
- **Enhanced Visuals**: Further polish the game's graphics and add more visual effects.

## 🚀 Publishing (Unity WebGL)
To publish the game as a WebGL build:
- Use the Unity WebGL build target, as described in the build instructions above.
- Host the game on a static web hosting service such as GitHub Pages, itch.io, or any other suitable platform.

## 📝 License
This project is licensed under the MIT License.

