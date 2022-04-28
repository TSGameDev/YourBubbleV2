using System;
using TSGameDev.Managers;

[Serializable]
public struct BubbleData
{
    public int worldSkybox;
    public int worldTerrainTexture;
    public int worldTerrainWidth;
    public int worldTerrainLength;

    public BubbleData(GameManager gameManager)
    {
        worldSkybox = gameManager.posInSkyboxArray;
        worldTerrainTexture = gameManager.posInTerrainArray;
        worldTerrainWidth = gameManager.terrainWidth;
        worldTerrainLength = gameManager.terrainLength;
    }
}
