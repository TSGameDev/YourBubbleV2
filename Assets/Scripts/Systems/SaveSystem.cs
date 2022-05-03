using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine;
using TSGameDev.Data;
using TSGameDev.Managers;
using TSGameDev.Object;

public static class SaveSystem
{
    static readonly string SaveFolder = Application.dataPath + "/Saves/";
    static readonly string PlayerDataSavePath = SaveFolder + "PlayerSettingsSaveData.txt";
    static readonly string WorldDataSavePath = SaveFolder + "WorldSaveData.txt";
    static readonly string WorldObjectsSavePath = SaveFolder + "WorldObjectsSaveData.txt";
    public static void SavePlayerSettingsData(PlayerSettingsData playerData)
    {
        if(!Directory.Exists(SaveFolder))
        {
            Directory.CreateDirectory(SaveFolder);
        }

        string JsonPlayerData = JsonUtility.ToJson(playerData);
        File.WriteAllText(PlayerDataSavePath, JsonPlayerData);
    }

    public static PlayerSettingsData LoadPlayerSettingsData(RebindHandler rebindHandler)
    {
        if (File.Exists(PlayerDataSavePath))
        {
            string JsonPlayerData = File.ReadAllText(PlayerDataSavePath);
            PlayerSettingsData newPlayerSettingsData = JsonUtility.FromJson<PlayerSettingsData>(JsonPlayerData);
            return newPlayerSettingsData;
        }
        else
        {
            return new PlayerSettingsData(rebindHandler.mainMenu, rebindHandler.assetMenu, rebindHandler.run, rebindHandler.quickExit, rebindHandler.interaction);
        }
    }

    public static void SaveWorldData(BubbleData worldData)
    {
        if (!Directory.Exists(SaveFolder))
        {
            Directory.CreateDirectory(SaveFolder);
        }

        string JsonWorldData = JsonUtility.ToJson(worldData);
        File.WriteAllText(WorldDataSavePath, JsonWorldData);
    }

    public static BubbleData LoadWorldData(GameManager gameManager)
    {
        if(File.Exists(WorldDataSavePath))
        {
            string JsonWorldData = File.ReadAllText(WorldDataSavePath);
            BubbleData newWorldData = JsonUtility.FromJson<BubbleData>(JsonWorldData);
            return newWorldData;
        }
        else
        {
            return new BubbleData(gameManager);
        }
    }

    public static void SaveWorldObjects(List<ObjectData> allWorldObjectData)
    {
        if(!Directory.Exists(SaveFolder))
        {
            Directory.CreateDirectory(SaveFolder);
        }

        ObjectData[] allWorldObjectDataArray = allWorldObjectData.ToArray();
        string JsonAllWorldObjectData = JsonHelper.ToJson(allWorldObjectDataArray);
        File.WriteAllText(WorldObjectsSavePath, JsonAllWorldObjectData);
    }

    public static List<ObjectData> LoadWorldObjects()
    {
        if(File.Exists(WorldObjectsSavePath))
        {
            string JsonAllWorldObjectData = File.ReadAllText(WorldObjectsSavePath);
            ObjectData[] allWorldObjectDataArray = JsonHelper.FromJson<ObjectData>(JsonAllWorldObjectData);
            List<ObjectData> allWorldObjectData = new List<ObjectData>();
            allWorldObjectData.AddRange(allWorldObjectDataArray);
            return allWorldObjectData;
        }
        else
            return new List<ObjectData>();
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
