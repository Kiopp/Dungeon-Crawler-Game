using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

/// <summary>
/// Script base from official Unity documentation: https://docs.unity.com/embeddedlinux/en/manual/how-to-build-using-cli
/// </summary>
public class Builder
{
    private static void BuildEmbeddedLinux(EmbeddedLinuxArchitecture architecture)
    {
        // Set architecture in BuildSettings
        EditorUserBuildSettings.selectedEmbeddedLinuxArchitecture = architecture;

        // Setup build options (e.g. scenes, build output location)
        var options = new BuildPlayerOptions
        {
            // Change to scenes from your project
            scenes = new[]
            {
                "Assets/Scenes/SampleScene.unity",
            },
            // Change to location the output should go
            locationPathName = "../EmbeddedLinuxPlayer/",
            options = BuildOptions.CleanBuildCache | BuildOptions.StrictMode,
            target = BuildTarget.EmbeddedLinux
        };

        var report = BuildPipeline.BuildPlayer(options);

        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log($"Build successful - Build written to {options.locationPathName}");
        }
        else if (report.summary.result == BuildResult.Failed)
        {
            Debug.LogError($"Build failed");
        }
    }

    // This function will be called from the build process
    public static void Build()
    {
        // Build EmbeddedLinux ARM64 Unity player
        BuildEmbeddedLinux(EmbeddedLinuxArchitecture.Arm64);
    }
}