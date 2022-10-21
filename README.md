Lotto visualization simulation game.  This is a webgl game built in unity that will allow the user to visualize low probability outcome environments by having the player walk through a large world of buildings, each representing 69 floors of libraries.  The user is challenged with finding the single book contained within the right library, floor and bookshelf in order to win the game. 

Release Notes:
Currently the game is split across multiple code branches while some of the scenes and prefabs are being constructed individually. 

10/20/22: Merged all active scenes into the development branch after everyone added trags and box colliders. Added global variables that will persist across scene changes and added the player code to change scenes.

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
