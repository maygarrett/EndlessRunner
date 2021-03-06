﻿// Endless Runner Constants Script

using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace GameData
{
    public static class Constants
    {
        private static Dictionary<string, int> intConstants = new Dictionary<string, int>();
        private static Dictionary<string, float> floatConstants = new Dictionary<string, float>();
        private static Dictionary<string, string> stringConstants = new Dictionary<string, string>();

        public static string FilePath
        {
            get
            {
                string persistentPath = Application.persistentDataPath;
                string savePath = string.Format("{0}/ConstantsDownload.csv", persistentPath);
                return savePath;
            }
        }

        public static void Initialize()
        {
            TextAsset constantsCSV;
            string[] lines;

            if (File.Exists(FilePath))
            {
                StreamReader sr = File.OpenText(FilePath);
                lines = sr.ReadToEnd().Split('\n');
                sr.Close();
            }
            else
            {
                Debug.LogFormat("{0} does not exist", FilePath);
                constantsCSV = Resources.Load<TextAsset>("Constants");
                lines = constantsCSV.text.Split('\n');
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                if (data.Length == 3)
                {
                    string key = data[0];
                    string type = data[1];
                    string value = data[2];


                    if (type == "INT")
                    {
                        int v;

                        if (int.TryParse(value, out v))
                        {
                            intConstants.Add(key, v);
                        }
                        else
                        {
                            Debug.LogError("Tried to add something that wasn't an INT into the INT constants array");
                        }
                    }

                    if (type == "FLOAT")
                    {
                        float v;
                        if (float.TryParse(value, out v))
                        {
                            floatConstants.Add(key, v);
                        }
                        else
                        {
                            Debug.LogError("Tried to add something that wasn't a FLOAT into the FLOAT constants array");
                        }
                    }

                    if (type == "STRING")
                    {
                        stringConstants.Add(key, value);
                    }
                }
            }
        }

        public static int GetInt(string key)
        {
            return intConstants[key];
        }

        public static float GetFloat(string key)
        {
            return floatConstants[key];
        }

        public static string GetString(string key)
        {
            return stringConstants[key];
        }
    }
}

