using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditorInternal;
using UnityEngine;

public class Builder
{
    private static void BuildWindows()
    {
        string outputPath = Path.Combine(Application.dataPath, "../bin/DungeonCrawler.exe"); // Application.dataPath points to the assets folder, this just sets a default path
        string[] scenes = EditorBuildSettings.scenes.Select(scene => scene.path).ToArray(); // Get active scenes
        BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.StandaloneWindows64, BuildOptions.None); // Customize build options as needed
    }
    private static void BuildLinux()
    {
        string outputPath = Path.Combine(Application.dataPath, "../bin/DungeonCrawler"); // Application.dataPath points to the assets folder, this just sets a default path
        string[] scenes = EditorBuildSettings.scenes.Select(scene => scene.path).ToArray(); // Get active scenes
        BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.StandaloneLinux64, BuildOptions.None); // Customize build options as needed
    }
}