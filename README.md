# Captain Brad

Captain Brad is a simple endless runner/flyer game made in Unity. Control Brad as he flies, collects coins, and avoids obstacles. The game tracks your score and overall high score, with sound effects and smooth gameplay.

## How to Play

- Press and hold Spacebar to make Brad fly upward.
- Avoid obstacles; colliding with one ends the game.
- Collect coins for points.
- The game ends if Brad hits the ground or an obstacle.

## How to Run Locally

1. Clone or download the repository.  
2. Open the project folder in Unity 2022.3 LTS or later.  
3. Open the Start Menu scene (the entry point of the game).  
4. Press Play to start the game from the menu.  
5. From the Start Menu, you can launch the main gameplay scene.  


## Features

- In game music
- Smooth player flying controls
- Score and high score tracking with persistent saving across sessions
- Coins spawn in patterns and move left across the screen
- Obstacles move left and are destroyed when off-screen or hit
- Sound effects for coin collection and crashes
- Game over UI panel

## Setup

- Unity 2022.3 LTS or later recommended
- Uses TextMeshPro for UI
- Audio clips assigned in PlayerController and Collectible scripts

## Project Structure

- `Scripts/` - gameplay scripts (PlayerController, ScoreManager, CoinPatternSpawner, MoveLeft, etc.)
- `Prefabs/` - Player, Coins, Obstacles
- `Scenes/` - Start Menu/Main gameplay scene
- `Audio/` - sound effects and music

## Controls

- Spacebar: Fly upward


## Known Issues / TODO

- Occasional obstacle z-position glitches (working on locking z-axis strictly -- constraints locked, issue lies elsewhere).
- Future plans to add more obstacle types and power-ups.

## Play Captain Brad

Download the latest playable Windows build here:

 [Download CaptainBradBuild.zip](https://github.com/your-username/CaptainBrad/releases/latest)

> No install needed. Just unzip and run the `.exe`  
> Built in Unity using C#


## Credits

- Game created by Joey R

- 'Evolution' Music by: bensound.com 
License code: HNFHXK7HZQOFOHKV 
Artist: : Benjamin Tissot 

- 'Comedy Music Theme' by 
TheoJT -- https://freesound.org/s/511436/ -- 
License: Attribution 4.0

- 'CollectCoin' by 
bradwesson -- https://freesound.org/s/135936/ -- 
License: Attribution NonCommercial 4.0

- Other sounds sourced from Unity
