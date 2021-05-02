# CPS498-S21-Team01
Into the Abyss student development team

## Into The Abyss
Into the Abyss is a horror/thriller video game that will be created to use in a flight simulator.
The main goal of the game is to navigate the deep depths of the ocean while avoiding large monsters that will destroy
your submarine if caught. 

## Table of Contents
- **Team**
- **Goals**
- **Installation**
- **Introduction**
- **Prototype Objectives and Functionality**
    - **Objectives**
    - **Implemented Features**
    - **Unimplemented Features**
- **UI Snapshots**
- **Changes Needed**
- **Team Contributions**

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
At the moment there is no installation available via Github. All code for the project is available here, but for installation please check our Unity Teams. 

## Introduction

Into the Abyss's main goal was to create a horror thriller game that relies on story and visual cues to make the players feel that they are in danger. This was the main vision that the team had going into production. However, one aspect of the game that was discussed constantly was whether this game would be in an arcade style or not. The idea of having this game being in an arcade style was a possibility as it would help making different levels and monsters that the player to explore with a more “collect an item” type of objective, but in the end, we decided against the idea, as we wanted to focus on making a game where the story takes the main stage. Another feature that was discussed at the beginning of the semester was having a radar inside of the submarine to help the player find items and crash sites, but we went with a distance to target system instead, as we though that the players could have more enjoyment exploring and trying to find information themselves with a simpler tool than having a radar that shows everything immediately. 

Most of the other goals that we had at the beginning of the semester were focused on the motion simulator and other I/O devices. We had originally planned to also set up the game for use in the motion simulator this semester, but unfortunately due to time constraints with the actual development of the game we were unable to do so. We have implemented different abilities that each pilot can control, which are stated in the tutorial of the game, but at the moment the controls are set up for use on a keyboard and not quite ready for the simulator. However, with those small grievances known, the Into the Abyss team is very proud of what we have accomplished with this concept in just 4 months.

## Prototype Objectives & Functionality

**Objectives**
Complete the Tutorial: In order to move forward in the game, the players must first complete a small tutorial of the controls for the submarine and move to the next section of the game

Find the Missing Submarines: Scattered around the first level there are 3 missing submarines. The players must locate these submarines and retrieve their blackboxes to find out more information about what happened.

Enter and Leave the Caves: Once all of the submarines are found, the player must enter a series of caves to find a final submarine. Once the final submarine is found, the players must escape the monster pursuing them and leave the caves.

**Implemented Features**

Voice Acting System: Scattered around the maps are objects that trigger both voice acting and subtitles. These help move the story forward and tell the players what to do next.

Tutorial: A small tutorial made to show the players how to play the game. It consists mostly of a voice telling the player what keys to push

Battery System: Some of the features used by the submarine require power. This battery system is used when certain abilities draw power, and stops these abilities when the power is out.

Flare System: The flare system is used as a deterrant for the monster. If a flare is sent out while the monster is attacking, the monster should run away.

Boost System: This helps the submarine go faster for a short period of time. Requires power:

Pickup System: Used to pickup items like batteries. submarine must touch the item to pick it up.

Distance System: Used to help the players find an item in range. This is used to find the downed submarines.

Submarine Health System: Used to measure how many hits the submarine has taken from the monster. After a certain amount of hits, the submarine fades to black and the players start at a checkpoint or the beginning.

Checkpoint System: Once the submarine makes it to a certain checkpoint scattered around the map, a small icon will appear showing that a checkpoint has been reached.

UI Control System: Used for the tutorial to show the players visually what to press or move for abilites or for moving the submarine.

Sub Balance System: Used to reset the submarine to default positioning.

Monster AI: Used to control the monster. This affects how and when the monster attacks the players.

**Unimplemented Features**

VR: the submarine in VR was a concept that we kept throwing around during development, but we decided against creating a VR version of the game due to time. 

Multiple Monsters: While 2 monsters are in the game that are ready to be implemented, we decided to only have one main monster in order to put more emphasis on it being dangerous.

Radar: Instead of doing a radar system, we decided instead to do a distance to target system in order to limit the player's knowledge of where items are.

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
