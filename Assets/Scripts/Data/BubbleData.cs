using System;
using UnityEngine;
using TSGameDev.Managers;

[Serializable]
public struct BubbleData
{
    public int worldSkybox;
    public int worldTerrainTexture;
    public int worldTerrainWidth;
    public int worldTerrainLength;

    public Vector3 playerPosition;

    public BubbleData(GameManager gameManager)
    {
        worldSkybox = gameManager.posInSkyboxArray;
        worldTerrainTexture = gameManager.posInTerrainArray;
        worldTerrainWidth = gameManager.terrainWidth;
        worldTerrainLength = gameManager.terrainLength;

        playerPosition = new Vector3();
    }
}
