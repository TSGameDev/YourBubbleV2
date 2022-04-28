using System.IO;
using UnityEngine;
using TSGameDev.Data;
using TSGameDev.Managers;

public static class SaveSystem
{
    static readonly string SaveFolder = Application.dataPath + "/Saves/";
    static readonly string PlayerDataSavePath = SaveFolder + "PlayerSettingsSave.txt";
    static readonly string WorldDataSavePath = SaveFolder + "WorldSaveData.txt";
    public static void SavePlayerSettingsData(PlayerSettingsData playerData)
    {
        if(!Directory.Exists(SaveFolder))
            Directory.CreateDirectory(SaveFolder);

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

    public static void SaveWorldData(WorldData worldData)
    {
        if(!Directory.Exists(SaveFolder))
            Directory.CreateDirectory(SaveFolder);

        string JsonWorldData = JsonUtility.ToJson(worldData);
        File.WriteAllText(WorldDataSavePath, JsonWorldData);
    }

    public static WorldData LoadWorldData(GameManager gameManager)
    {
        if(File.Exists(WorldDataSavePath))
        {
            string JsonWorldData = File.ReadAllText(WorldDataSavePath);
            WorldData newWorldData = JsonUtility.FromJson<WorldData>(JsonWorldData);
            return newWorldData;
        }
        else
        {
            return new WorldData(gameManager);
        }
    }
}
