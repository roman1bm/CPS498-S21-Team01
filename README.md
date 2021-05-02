# CPS498-S21-Team01
Into the Abyss student development team

## Into The Abyss
Into the Abyss is a horror/thriller video game that will be created to use in a flight simulator.
The main goal of the game is to navigate the deep depths of the ocean while avoiding large monsters that will destroy
your submarine if caught. 


## Team

Name | Role
---: | :---
Colin Van Brabant | Stakeholder
Taeho Kim | Developer
Brendan Roman | Developer
Hannah Seccia | Developer
Nathan Wisniewski | Developer

## Goals
1. To have the submarine in game connect to the flight simulator correctly.
2. To have an interesting story that allows players to become invested in the game.
3. To have abilities for both players to control that will affect how the game plays (Sonar, Flares, Etc.).
4. To have an enemy that correctly locks onto and attacks the player submarine if found. 
5. To have the atmosphere of the video game be frightening through sound and visual cues. 

## Installation
temptext


## UI Snapshots
![screenshot1](https://user-images.githubusercontent.com/56941469/116795135-b7331680-aaa0-11eb-8632-c2d8648cdcac.PNG)
  - Display of the introduction cutscene.

![screenshot2](https://user-images.githubusercontent.com/56941469/116795193-1ee96180-aaa1-11eb-85ea-4f26c68b6c86.PNG)
  - Display of the "Distance To Objective" indicator, located on the right of the submarine's interface.

![screenshot3](https://user-images.githubusercontent.com/56941469/116795194-21e45200-aaa1-11eb-8ea7-768978af74b3.PNG)
  - General view of the submarine's interface. This includes the lighting, battery levels, flare count, and depth indicator.

![screenshot4](https://user-images.githubusercontent.com/56941469/116795252-ab941f80-aaa1-11eb-94a6-23717a6c080c.PNG)
  - One of the monster AI enemies players can find.

![screenshot5](https://user-images.githubusercontent.com/56941469/116795253-ad5de300-aaa1-11eb-9950-c91199e77f52.PNG)
  - One of the battery pickups players can find.

![screenshot6](https://user-images.githubusercontent.com/56941469/116795413-bef3ba80-aaa2-11eb-8437-791aa48ffd77.PNG)
  - Example of subtitles, displaying a line of dialog in the foreground.

![screenshot7](https://user-images.githubusercontent.com/56941469/116795429-e480c400-aaa2-11eb-9aaa-7dcc0964ba1a.PNG)
  - Display of the flare asset.

![screenshot8](https://user-images.githubusercontent.com/54714888/116797943-db9aed00-aab8-11eb-8050-74aafe9ab784.PNG)
  - Display of the main menu.

![screenshot9](https://user-images.githubusercontent.com/54714888/116797952-f40b0780-aab8-11eb-8ae1-a0f4eea75146.PNG)
  - Example of the Checkpoint Reached notification display in the foreground.





## Changes Needed
  The main change needed to the project at the moment is to connect the game to the motion simulator. This was one of our goals near the beginning of the semester, and we have the code needed to do so, it just needs to be implemented correctly. We were focused on completing the game that this portion of the project was not done. Another change that is needed is the monster's AI and how it reacts to the flare system. In theory, the monster is supposed to go the opposite direction of the player when a flare is shot off. However, the monster does not even react to the flare at the moment, so to fix that would make the game more complete. Along with that, fixing the monster's ai so that it can also animate is something that needs to be done. At the moment the monster glides toward the player, but does not animate in any way. Fixing the animator for the monster would make the project look much more professional. As for the checkpoint system, proper save states can be implemented that would save the progress achieved by players.
  
## Team Contributions

Brendan Roman: Wrote story script, cast characters, edited and implemented voice files, small terrain additions and decorations. Wrote Vascript, VascriptTUTORIAL, SpawnFlare, SpawnMonster. Made changes to SubmarineHealthSystem, EvilFishMonsterAI, and CrascMonsterAI. Estimated work time: 50 Hours. 

Hannah Seccia: Programmed the health system and AI system, modeleds the prefab of disc box, seaweed, and the evil fish. Implemented the cutscene and wrote dialogue in that. Worked on the basis of the old level system. Estimated work hours: 50 hours

Taeho Kim: Implement calculation of distance from submarine to target/ UI for showing it in submarine, level changing system with collision, UI for instruction of what kinds of keys can be used and how it works, Estimated work time: 40 Hours.

Nathan Wisniewski: Created logo, icon, and checkpoint image assets. Work on checkpoint system, alongside a balance submarine script. Work on foreground canvas animations, including checkpoint notifications, item pick-up notifications, and fade-in/fade-out transitions. Estimated work time: 35 hours.

Colin Van Brabant:
