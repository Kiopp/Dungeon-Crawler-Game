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
   ### Windows:
   ```
   "<PathToUnityEditor>" -quit -batchmode -executeMethod Builder.BuildWindows -projectPath "<PathToProject>"
   ```
   ### Linux:
   ```
   "<PathToUnityEditor>" -quit -batchmode -executeMethod Builder.BuildLinux -projectPath "<PathToProject>"
   ```
   #### Example compilation for windows:
   ```
   "C:\Program Files\Unity\Hub\Editor\2022.3.22f1\Editor\Unity.exe" -quit -batchmode -executeMethod Builder.BuildWindows -projectPath "C:\Users\MyUserName\Documents\MyUnityProject"
   ```
4. After completed compilation process you can find the compiled program in `\Dungeon Crawler\bin`
5. To learn more or resolve any issues with the command refer to the [Unity documentation](https://docs.unity3d.com/Manual/EditorCommandLineArguments.html).

## Unit tests
### Command line:
To manually run unit tests with unity from the command-line you can run these commands:
#### Run PlayMode tests:
```
"<PathToUnityEditor>" -quit -batchmode -runTests -testPlatform PlayMode -projectPath "<PathToTheProject>"
```
#### Run EditMode tests:
```
"<PathToUnityEditor>" -quit -batchmode -runTests -testPlatform EditMode -projectPath "<PathToTheProject>"
```
- **The test results will be presented as an .xml file in the project folder, named something like TestResults-638491452845542675.xml**
- Choosing between PlayMode and EditMode determines if the editor should run an actual game environment for the tests or not.
   - If you are running tests that directly depend on or interacts with GameObjects in the environment, then you should run PlayMode.
   - If you are running tests that only tests code logic you should run EditMode.
- To learn more or resolve any issues refer to the official [Unity Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/reference-command-line.html) documentation.
## Code coverage information:
To generate code coverage information add the following flag to the unit testing command:
```
-enableCodeCoverage
```
- The code coverage information is presented as an HTML page. The HTML file will be located at `\Dungeon Crawler\CodeCoverage\Report`. 
- The system also saves a less detailed history of all the code coverage you do as xml files at `\Dungeon Crawler\CodeCoverage\Report-history`.
- If you also want to generate .svg and .png badges, add the following flag to the command:
```
-coverageOptions generateBadgeReport
```
- To learn more or resolve any issues with the code coverage information refer to the [Unity Code Coverage](https://docs.unity3d.com/Packages/com.unity.testtools.codecoverage@1.1/manual/CoverageBatchmode.html)  documentation.

## Linter
A linter will automatically run alongside our CI using Super-Linter through github actions.

## Kanban board
https://github.com/users/Kiopp/projects/2

## Licence
Dungeon Crawler Game is a 2024 Student Project. It is free software, and may be redistributed under the terms of the [Unity License version 4.x](https://unity.com/legal/eula)

## Assets used
- Dungeon walls, floor, ceiling and decoration meshes/textures made by [Gridness Studio](https://assetstore.unity.com/packages/3d/environments/dungeons/lite-dungeon-pack-low-poly-3d-art-by-gridness-242692)
- Enemy sprites from [itch.io](https://free-game-assets.itch.io/free-chaos-monsters-3232-icon-pack)
- Item sprites from [itch.io](https://gianqui.itch.io/pixel-game-sprite-pack)

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
