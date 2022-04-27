using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using TSGameDev.Data;
using TSGameDev.Managers;

public static class SaveSystem
{
    static readonly string SaveFolder = Application.dataPath + "/Saves/";
    static readonly string PlayerDataSavePath = SaveFolder + "PlayerSettingsSave.txt";
    static readonly string PostProcessingSavePath = SaveFolder + "PostProcessingSave.txt";
    public static void SavePlayerSettingsData(PlayerSettingsData playerData)
    {
        if(!Directory.Exists(SaveFolder))
        {
            Directory.CreateDirectory(SaveFolder);
        }
        string JsonPlayerData = JsonUtility.ToJson(playerData);
        File.WriteAllText(PlayerDataSavePath, JsonPlayerData);
    }

    public static PlayerSettingsData LoadPlayerSettingsData(UIManager uiManager)
    {
        if (File.Exists(PlayerDataSavePath))
        {
            string JsonPlayerData = File.ReadAllText(PlayerDataSavePath);
            PlayerSettingsData newPlayerSettingsData = JsonUtility.FromJson<PlayerSettingsData>(JsonPlayerData);
            return newPlayerSettingsData;
        }
        else
        {
            return new PlayerSettingsData(uiManager.mainMenu, uiManager.assetMenu, uiManager.run, uiManager.quickExit, uiManager.interaction);
        }
    }
}
