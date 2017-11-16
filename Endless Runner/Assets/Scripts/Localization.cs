using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace GameData
{
    public static class Localization
    {
        private static Dictionary<string, string> localizationDictionary = new Dictionary<string, string>();

        public static void Initialize()
        {
            TextAsset localizationCSV;

            string[] lines;

            if (File.Exists(FilePath))
            {
                StreamReader sr = File.OpenText(FilePath);
                lines = sr.ReadToEnd().Split('\n');
            }
            else
            {
                Debug.LogFormat("{0} does not exist", FilePath);
                localizationCSV = Resources.Load<TextAsset>("Localization");
                lines = localizationCSV.text.Split('\n');
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                if (data.Length == 6)
                {
                    string key = data[0];
                    string type = data[1];
                    string englishValue = data[2];
                    string frenchValue = data[3];
                    string germanValue = data[4];
                    string spanishValue = data[5];

                    if (type == "STRING")
                    {
                        switch (Application.systemLanguage.ToString())
                        {
                            case "English":
                                localizationDictionary.Add(key, englishValue);
                                break;
                            case "French":
                                localizationDictionary.Add(key, frenchValue);
                                break;
                            case "German":
                                localizationDictionary.Add(key, germanValue);
                                break;
                            case "Spanish":
                                localizationDictionary.Add(key, spanishValue);
                                break;
                            default:
                                Debug.LogError("Language Not Found, Defaulting to English");
                                localizationDictionary.Add(key, englishValue);
                                break;

                        }
                    }
                }
            }
        }

        public static string GetString(string key)
        {
            return localizationDictionary[key];
        }
    }
}

