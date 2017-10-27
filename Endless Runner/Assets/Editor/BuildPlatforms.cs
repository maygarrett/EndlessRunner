using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildPlatforms {
	private static string[] scenes = new string[] {
		"Assets/Scenes/MyMainMenu",
		"Assets/Scenes/MyGame"
	};

	#region MENU_ITEMS
	[MenuItem("Build/PC/Dev")]
	public static void BuildPCDev() {
		Build(true,BuildTarget.StandaloneWindows);
	}

	public static void BuildPCRelease() {
		Build(false,BuildTarget.StandaloneWindows);
	}

	public static void BuildPCAll() {
		BuildPCDev();
		BuildPCRelease();
	}
	#endregion

	public static string GetProjectPath() {
		string pathToProject = Application.dataPath;
		pathToProject = pathToProject.Replace("/Assets","");

		return pathToProject;
	}

	public static void Build(bool isDev, BuildTarget target) {
		BuildPlayerOptions options = new BuildPlayerOptions();
		string extension = string.Empty;

		switch(target) {
			case BuildTarget.StandaloneWindows:
				extension = ".exe";
				break;
			case BuildTarget.Android:
				extension = ".apk";
				break;
		}

		options.locationPathName = string.Format("{0}/Build/{1}_{2}/MyGame{3}", GetProjectPath(),target,isDev ? "Dev" : "", extension);
		options.scenes = scenes;
		options.target = target;
		options.options = isDev ? BuildOptions.Development : BuildOptions.None;

		Debug.LogFormat("Building {0} to {1}\nDev: {2}",options.target,options.locationPathName,isDev);	
		BuildPipeline.BuildPlayer(options);
	}

}
