using System;
using UnityEngine;
using TSGameDev.Managers;

[Serializable]
public struct BubbleData
{
    #region TerrainData
    public int worldSkybox;
    public int worldTerrainTexture;
    public int worldTerrainWidth;
    public int worldTerrainLength;
    #endregion

    #region PlayerData
    public Vector3 playerPosition;
    #endregion

    /// <summary>
    /// Constructor to crate a new BubbleData
    /// </summary>
    /// <param name="gameManager">Global Gamemanager Reference</param>
    public BubbleData(GameManager gameManager)
    {
        worldSkybox = gameManager.posInSkyboxArray;
        worldTerrainTexture = gameManager.posInTerrainArray;
        worldTerrainWidth = gameManager.terrainWidth;
        worldTerrainLength = gameManager.terrainLength;

        playerPosition = new Vector3();
    }
}
