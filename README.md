# Dungeon Crawler

![main workflow](https://github.com/Kiopp/Softwere-Development-Repository/actions/workflows/main.yml/badge.svg)

## Description 
We're creating a simple first-person dungeon crawler. Players will navigate a 3D environment, interact with objects, and fight enemies. During their exploration, they'll encounter various situations like meeting other adventurers and solving puzzles. Finding and collecting items will make the player more powerful, increasing their chances of survival. The game will feature 3D graphics and grid-like movement.

### Technical details:
- A GameManager class will manage interactions between the user and the code.
- Battles will be turn-based. Where the player and the enemy take turns attacking each other.
- A BattleManager class will manage the turn-based combat. 
- Levels will have a grid representation in code, used to track the player's position within the level. This grid might also be used to create a visual map of the dungeon for the player.
- If time allows, the levels will be randomly generated.
- The player can carry a maximum of six items.
- Items can be either a weapon (swords) or a consumable (potions). If time allows, there might be keys and other progression items.
- The player can use either the arrow keys or WASD keys to move. Up moves the player forward, left rotates them left, and right rotates them right.
- All relevant data and statistics should be easily visible to the player on their GUI.

### Language: 
We will write in C# using a long-term support version of unity: 2022.3.22f1

### Build system: 
Unity LTS version 2022.3.22f1

## Compilation instructions
1. Download unity LTS version 2022.3.22f1, Unity download can be found [here](https://unity.com/releases/editor/qa/lts-releases)
2. Open your command terminal of choice.
3. Execute the following command for your respective platform, specifying your own paths:
   #### Windows:
   ```
   "<PathToUnityEditor>" -quit -batchmode -executeMethod Builder.BuildWindows -projectPath "<PathToProject>"
   ```
   #### Linux:
   ```
   "<PathToUnityEditor>" -quit -batchmode -executeMethod Builder.BuildLinux -projectPath "<PathToProject>"
   ```
   ##### Example compilation for windows:
   ```
   "C:\Program Files\Unity\Hub\Editor\2022.3.22f1\Editor\Unity.exe" -quit -batchmode -executeMethod Builder.BuildWindows -projectPath "C:\Users\MyUserName\Documents\MyUnityProject"
   ```
4. After completed compilation process you can find the compiled program in `\Dungeon Crawler\bin`
5. To learn more or resolve any issues with the command refer to the [Unity documentation](https://docs.unity3d.com/Manual/EditorCommandLineArguments.html).

## Unit tests
### Command line:
To run unit tests with unity from the command line you can run these commands:
#### Run PlayMode tests:
```
"<PathToUnityEditor>" -quit -batchmode -runTests -testPlatform PlayMode -projectPath "<PathToTheProject>"
```
#### Run EditMode tests:
```
"<PathToUnityEditor>" -quit -batchmode -runTests -testPlatform EditMode -projectPath "<PathToTheProject>"
```
- **The test results will be presented as a .xml file in the project folder, named something along the lines of TestResults-638491452845542675.xml**
- Choosing between PlayMode and EditMode determines if the editor should run an actual game environment for the tests or not.
   - If you are running tests that directly depends on or interacts with GameObjects in the environment, then you should run it in PlayMode.
   - If you are running tests that **don't** interact with the game environment you should run it in EditMode.
- To learn more or resolve any issues refer to the official [Unity Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/reference-command-line.html) documentation.
### Code coverage information:
To generate code coverage information add the following flag to the command:
```
-enableCodeCoverage
```
- The code coverage information is presented as a html page. The html file will be located at `\Dungeon Crawler\CodeCoverage\Report`. 
- The system will also save a less detailed history of all the times you generate the code coverage information as xml files in `\Dungeon Crawler\CodeCoverage\Report-history`.
- To generate badges in svg and png format add the following to the command:
```
-coverageOptions generateBadgeReport
```
- To learn more or resolve any issues with the code coverage information refer to the [Unity documentation](https://docs.unity3d.com/Packages/com.unity.testtools.codecoverage@1.1/manual/CoverageBatchmode.html).

## Kanban board
https://github.com/users/Kiopp/projects/2

## Assets used
- Dungeon walls, floor, ceiling and decoration meshes/textures made by [Gridness Studio](https://assetstore.unity.com/packages/3d/environments/dungeons/lite-dungeon-pack-low-poly-3d-art-by-gridness-242692)

## Created by:
- Kiopp, Jesper Wentzell
- Vencilo, Axel Bechtel
- majo22wx, Joel Majava
- mowaab, Mohmmad Abbas
- CarlNord01, Carl Nordenadler

### Declarations
- I, Jesper Wentzell, declare that I am the sole author of the content I add to this repository.
- I, Axel Bechtel, declare that I am the sole author of the content I add to this repository.
- I, Joel Majava, declare that I am the sole author of the content I add to this repository.
- I, Mohammad Abbas, declare that I am the sole author of the content I add to this repository.
- I, Carl Nordenadler, declare that I am the sole author of the content I add to this repository.
