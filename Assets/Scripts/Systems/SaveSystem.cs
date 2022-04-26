using System.IO;
using UnityEngine;
using TSGameDev.Data;
using TSGameDev.Managers;

public static class SaveSystem
{
    static readonly string SaveFolder = Application.dataPath + "/Saves/";
    static readonly string PlayerDataSave = SaveFolder + "PlayerSettingsSave.txt";
    public static void SavePlayerSettingsData(PlayerSettingsData playerData)
    {
        if(!Directory.Exists(SaveFolder))
        {
            Directory.CreateDirectory(SaveFolder);
        }
        string JsonPlayerData = JsonUtility.ToJson(playerData);
        File.WriteAllText(PlayerDataSave, JsonPlayerData);
    }

    public static PlayerSettingsData LoadPlayerSettingsData(UIManager uiManager)
    {
        if (File.Exists(PlayerDataSave))
        {
            string JsonPlayerData = File.ReadAllText(PlayerDataSave);
            PlayerSettingsData newPlayerSettingsData = JsonUtility.FromJson<PlayerSettingsData>(JsonPlayerData);
            Debug.Log("loaded PlayerSettingsData"); 
            return newPlayerSettingsData;
        }
        else
        {
            return new PlayerSettingsData(uiManager.mainMenu, uiManager.assetMenu, uiManager.run, uiManager.quickExit, uiManager.interaction);
        }
    }
}
