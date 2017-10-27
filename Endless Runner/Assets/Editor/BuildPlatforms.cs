// folder named editor, goes anywhere
// script buildPlatforms
using System.Text;
using System.IO;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class BuildPlatforms
{
   /* private static string[] scenes = new string[] {
        "Assets/Scenes/EndlessSideScroll"
    }; */


    #region MenuItems
    [MenuItem("Build/iOS/Dev")]
    public static void BuildiOSDev()
    {
        UpdateBuildNumber();
        Build(true, BuildTarget.iOS);
    }

    [MenuItem("Build/iOS/Rel")]
    public static void BuildiOSRel()
    {
        UpdateBuildNumber();
        Build(false, BuildTarget.iOS);
    }

    [MenuItem("Build/Android/Dev")]
    public static void BuildAndroidDev()
    {
        UpdateBuildNumber();
        Build(true, BuildTarget.Android);
    }

    [MenuItem("Build/Android/Rel")]
    public static void BuildAndroidRel()
    {
        UpdateBuildNumber();
        Build(false, BuildTarget.Android);
    }

    [MenuItem("Build/iOS/All")]
    public static void BuildiOSAll()
    {
        UpdateBuildNumber();
        Build(true, BuildTarget.iOS);
        Build(false, BuildTarget.iOS);
    }

    [MenuItem("Build/Android/All")]
    public static void BuildAndroidAll()
    {
        UpdateBuildNumber();
        Build(true, BuildTarget.Android);
        Build(false, BuildTarget.Android);
    }

    [MenuItem("Build/PC/Dev")]
    public static void BuildPCDev()
    {
        UpdateBuildNumber();
        Build(true, BuildTarget.StandaloneWindows);
    }

    [MenuItem("Build/PC/Rel")]
    public static void BuildPCRel()
    {
        UpdateBuildNumber();
        Build(false, BuildTarget.StandaloneWindows);
    }

    [MenuItem("Build/PC/All")]
    public static void BuildPCAll()
    {
        UpdateBuildNumber();
        Build(true, BuildTarget.StandaloneWindows);
        Build(false, BuildTarget.StandaloneWindows);
    }

    [MenuItem("Build/All")]
    public static void BuildAll()
    {
        UpdateBuildNumber();
        Build(true, BuildTarget.iOS);
        Build(false, BuildTarget.iOS);
        Build(true, BuildTarget.Android);
        Build(false, BuildTarget.Android);
        Build(true, BuildTarget.StandaloneWindows);
        Build(false, BuildTarget.StandaloneWindows);
    }
    #endregion

    public static void Build(bool isDev, BuildTarget target)
    {
        string pathToAssets = Application.dataPath;
        string pathToProject = pathToAssets.Replace("/Assets", "");
        // string buildPath = pathToProject + "/Builds/EndlessRunneriOSDev";
        string extension = string.Empty;

        switch (target)
        {
            case BuildTarget.StandaloneWindows:
                extension = ".exe";
                break;
            case BuildTarget.Android:
                extension = ".apk";
                break;
            case BuildTarget.iOS:
                extension = ".api";
                break;
        }

        string buildPath = string.Format("{0}/Builds/{1}/{2}/EndlessRunner{3}{4}", pathToProject, target, isDev ? "Dev" : "Release", buildNumber, extension);

        //string.Format("{0}{1}{2}");

        Debug.Log(buildPath);

        BuildPlayerOptions options = new BuildPlayerOptions();
        options.locationPathName = buildPath;
        options.options = isDev ? BuildOptions.Development : BuildOptions.None; // in line conditional statements->    condition ? truth : nontruth
        options.target = target;
        //options.scenes = new string[] { "Assets/Platform/Scenes/SinglePlatform.unity" }; // add all scenes and their paths to this string array
        //options.scenes = scenes;

        Debug.Log("Building" + string.Format( "{0} {1}", target, isDev ? "Dev" : "Release"));
        BuildPipeline.BuildPlayer(options);
        Debug.Log("Build Complete");
    }


    public static void UpdateBuildNumber()
    {
        // updating build number

        string path = "Assets/Resources/BuildNumber.txt";
        //Read the text from directly from the build number file and turn it into an int.
        StreamReader reader = new StreamReader(path);
        string buildString = reader.ReadToEnd();
        int buildNumber = int.Parse(buildString);
        reader.Close();
        File.Delete(path);
        //increase build number
        buildNumber++;
        File.WriteAllText("Assets/Resources/BuildNumber.txt", "");
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(buildNumber);
        writer.Close();
    }
}

