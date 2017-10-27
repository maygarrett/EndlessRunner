// folder named editor, goes anywhere
// script buildPlatforms


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class BuildPlatforms
{
    private static string[] scenes = new string[] {
        "Assets/Scenes/EndlessSideScroll"
    };


    #region MenuItems
    [MenuItem("Build/iOS/Dev")]
    public static void BuildiOSDev()
    {
        Build(true, BuildTarget.iOS);
    }

    [MenuItem("Build/iOS/Rel")]
    public static void BuildiOSRel()
    {
        Build(false, BuildTarget.iOS);
    }

    [MenuItem("Build/Android/Dev")]
    public static void BuildAndroidDev()
    {
        Build(true, BuildTarget.Android);
    }

    [MenuItem("Build/Android/Rel")]
    public static void BuildAndroidRel()
    {
        Build(false, BuildTarget.Android);
    }

    [MenuItem("Build/iOS/All")]
    public static void BuildiOSAll()
    {
        Build(true, BuildTarget.iOS);
        Build(false, BuildTarget.iOS);
    }

    [MenuItem("Build/Android/All")]
    public static void BuildAndroidAll()
    {
        Build(true, BuildTarget.Android);
        Build(false, BuildTarget.Android);
    }

    [MenuItem("Build/All")]
    public static void BuildAll()
    {
        Build(true, BuildTarget.iOS);
        Build(false, BuildTarget.iOS);
        Build(true, BuildTarget.Android);
        Build(false, BuildTarget.Android);
    }
    #endregion

    public static void Build(bool isDev, BuildTarget target)
    {
        string pathToAssets = Application.dataPath;
        string pathToProject = pathToAssets.Replace("/Assets", "");
        // string buildPath = pathToProject + "/Builds/EndlessRunneriOSDev";

        string buildPath = string.Format("{0}/Builds/{1}/{2}/EndlessRunner{3}", pathToProject, target, isDev ? "Dev" : "Release", "1");

        string.Format("{0}{1}{2}");

        Debug.Log(buildPath);

        BuildPlayerOptions options = new BuildPlayerOptions();
        options.locationPathName = buildPath;
        options.options = isDev ? BuildOptions.Development : BuildOptions.None; // in line conditional statements->    condition ? truth : nontruth
        options.target = target;
        //options.scenes = new string[] { "Assets/Platform/Scenes/SinglePlatform.unity" } // add all scenes and their paths to this string array
        options.scenes = scenes;

        Debug.Log("BuildingiOS Dev");
        BuildPipeline.BuildPlayer(options);
        Debug.Log("Build Complete");
    }

}