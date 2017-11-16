using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using GameData;

namespace GameData
{
    public static class Downloader
    {
        //Get these from your own URL
        const string SPREADSHEET_ID = "1Jke5vas0ojMb3pb9dUudc2Bp4Pxy0wfaAIMe3VMmCCU"; //after the d/
        const string CONSTANTS_TAB_ID = "0";
        const string LOCALIZATION_TAB_ID = "1639697435"; //gid
        const string URL_FORMAT = "https://docs.google.com/spreadsheets/d/{0}/export?format=csv&id={0}&gid={1}";

        //Get url by using File->Download As->CSV
        //Then open download history in chrome/firefox and copy url
        //Make sure accessiblity is set to Anyone with link can view

        public static void Init()
        {
            //Debug.Log(Application.dataPath);
            DownloadCSV(LOCALIZATION_TAB_ID, Localization.FilePath);
            DownloadCSV(CONSTANTS_TAB_ID, Constants.FilePath);
        }

        private static void DownloadCSV(string tabID, string filePath)
        {

            Debug.Log(filePath);

            //Get the formatted URL
            string downloadUrl = string.Format(URL_FORMAT, SPREADSHEET_ID, tabID);

            Debug.LogFormat("Downloading {0}", tabID);

            //Download the data
            WWW website = new WWW(downloadUrl);

            //Wait for data to download
            while (!website.isDone) {
            }

            if (string.IsNullOrEmpty(website.text))
            {
                Debug.LogError("NO DATA WAS RECEIVED");
                //Load the last cached values
                Constants.Initialize();
                Localization.Initialize();
            }
            else
            {
                Debug.Log(website.text);
                //Successfully got the data, process it
                Constants.Initialize();
                Localization.Initialize();
                //Save to disk
                File.WriteAllText(filePath, website.text);
            }
        }
    }

}
