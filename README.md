Lotto visualization simulation game.  This is a webgl game built in unity that will allow the user to visualize low probability outcome environments by having the player walk through a large world of buildings, each representing 69 floors of libraries.  The user is challenged with finding the single book contained within the right library, floor and bookshelf in order to win the game. 

Release Notes:
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
Currently the game is split across multiple code branches while some of the scenes and prefabs are being constructed individually. 
=======
Currently the game is split across multiple code branches while some of the scenes and prefabs are being constructed individually. 

10/20/22:
Merged all active scenes into the development branch after everyone added trags and box colliders.  Added global variables that will persist across scene changes and added the player code to change scenes. 
>>>>>>> 871c3085e7a997a01fb914ec5a95e27bf21f5a86
=======
Currently the game is split across multiple code branches while some of the scenes and prefabs are being constructed individually.

10/20/22: Merged all active scenes into the development branch after everyone added trags and box colliders. Added global variables that will persist across scene changes and added the player code to change scenes.
<<<<<<< HEAD
>>>>>>> 2055530ae4a7b1a57241f387d0bbb31ee249d15d
=======
Currently the game is split across multiple code branches while some of the scenes and prefabs are being constructed individually.

10/20/22: Merged all active scenes into the development branch after everyone added trags and box colliders. Added global variables that will persist across scene changes and added the player code to change scenes.
>>>>>>> e83c598efde7b339a7df345f151a7b76c9b19b4d
=======
>>>>>>> 7647390db1a57df96a8bdf47b393b23c0ce46616
>>>>>>> 871c3085e7a997a01fb914ec5a95e27bf21f5a86

=======
------------------------------------------
10/6/22
---------------------------
Currently the game is split across multiple code branches while some of the scenes and prefabs are being constructed individually.

>>>>>>> cc781f8a93983b83fb133d93026728634f196ef6
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
