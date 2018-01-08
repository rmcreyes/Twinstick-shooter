Twinstick Shooter  
===  
  
This is a game I developed to get an introduction to scripting in C#, and also to use Unity's game development tools. You can play the game by pulling or downloading this repository, going into the `Builds` directory, and running `twinstick_shooter.exe`.  
  
[![https://gyazo.com/f6a7304dd6ce00a9d942c35ccfdb432b](https://i.gyazo.com/f6a7304dd6ce00a9d942c35ccfdb432b.gif)](https://gyazo.com/f6a7304dd6ce00a9d942c35ccfdb432b)
  
### Goal:  
Destroy as many enemies as you can while trying to survive. The game ends when you run out of health.  
* Enemies spawn from the red spawn points on the 4 corners of the map. Each wave of enemies comes quicker than the last.  
* Health pickups will spawn on the blue spawn point on the lower portion of the map. Pick these up to live longer.  
  
### Controls:  
* Use the `W`, `A`, `S`, `D`, keys to move around, aim with your mouse, and `left click` to shoot.  
  
### Areas for improvement:  
* modulizing much of the code used in my scripts  
* giving the player a health cap  
* adding sound effects to the game  
* fix a bug where the "Enemies defeated" count will increment by 2 if the script was written in a way where it made sense not to  
* fix a bug where enemies' speeds increase dramatically when graphic settings are set to low or very low