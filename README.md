Lotto visualization simulation game.  This is a webgl game built in unity that will allow the user to visualize low probability outcome environments by having the player walk through a large world of buildings, each representing 69 floors of libraries.  The user is challenged with finding the single book contained within the right library, floor and bookshelf in order to win the game. 

Release Notes:
------------------------------------------
10/6/22
---------------------------
Currently the game is split across multiple code branches while some of the scenes and prefabs are being constructed individually.

PlayerPrefab branch: 
This branch is where the player prefab that will be shared across all scenes is being constructed.  The player will be a blocky charcter similar to what you see in games like minecraft.  Currently just the basic outlines and camera movements are implemented. 

LobbbyScene branch:
Basic scene layout. Rough outline for the lobby scene. Includes opening room and beginning of simple lobby and elevator.

Development branch:
This is where we will merge all other branches for M2 but is also being used by Lance Lindstrom as he is working on the bookshelf scene. The scene so far consists of 16 rectangular prisms that are selectable by mouse click. Each prism either tells the player they win or lose.

JoseBranckv2 branch:
This branch is for the development of the Floor Scene (the floor with many bookshelfs)
Created spawning scripts to layout the high amount of bookshelves in the scene
Created two scenes. The first scene (FloorBookshelfScene) was an early version of the vision we had, but the second scene (FloorScenev2) is the scene that will be worked on going forward. It contains 2001 bookshelfs, 4 walls, 9 planes, and 12 pillars.

lute/development:
This branch is the work of the OverWorld Scene (the initial scene where the player will be spawned)
It currently contains a block or parcel of 69 buildings where there is 3 different types of buildings to account for a feeling of variety and massiveness.
It will be iterated to include 69 of this parcels or blocks that will correspond with the 69 rows by 69 columns of buildings.
There are some particle systems representing clouds too.

10/20/22:
------------------------------
Merged all active scenes into the development branch after everyone added trags and box colliders. Added global variables that will persist across scene changes and added the player code to change scenes.


11/3/22: 
------------------------------
All Changes are currently only in the Development Branch, but changes are as follows:

Player Prefab:
Camera and player movement changed, instead of up/down/left/right, it is now rotational with forward/back 
type movement
Current Bug: Player freaks out when a collision is detected and throws player

Overworld:
Polished assets that were glitching (roads were glitching)

Lobby:
Added scene and it now contains a room and an elvator to walk into
Elevator now contains an animation 
Elevator entry prompts user to input the floor they want to go to
Current Bug: Number input is glitched

Library Scene:
Made scene layout be 69 x 69 to be accurate to powerball tickets from the global variables scene
Updated scripts to take in 69 by 69 value based on row and column

Bookshelf scene:
Changed orinetation based on bookshelf prefab, and alligned it based on scene before it

11/17/2022
------------------------------
All changes are still pushed to the development Branch with the exception of the webGL build and doxygen which are located http://csci3510.klinksys.net/Capstone/ and http://csci3510.klinksys.net/Doxygen/ respectively. 

Player Prefab:
We fixed the bug where the player is thrown drom the walls during a collsion that that does not initiate a trigger, but we are having an issue now where a user can push past the collsion and walk through walls. The OnCollisionEnter script has now been updated to read the variables of the overworld and bookshelves to grab the proper numbers presented by the collision objects to attempt to "win" the game.

Overworld:
The runtime creation of the building has been expanded to additional city blocks and the buildings withing the blocks all now have doors.  All of the buildings now have two variables which are called from the player prefab on collision to select the first two numbers of the "lottery".

Lobby:
Fixed the number input popup when the user enters the elevated and that value now properly passes to the next scenes as the 3rd value in the "lotter"

Library Scene:
Added a bookshelf prefab that looks more detailed
Changed lighting in scene to increase performance
Added symmetrical walls
Scene now passes current value properly based on player decision
Changed player position at start of the scene
Added elevator to scene to make it look more consistent from the lobby scene

Bookshelf scene:
Updated the skin for the bookshelf so it matches the look of the bookshelves from the library scene. The win/loose script is now working however the chances of winning are very rare by design.  
