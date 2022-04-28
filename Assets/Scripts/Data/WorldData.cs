using System;
using TSGameDev.Managers;

namespace TSGameDev.Data
{
    [Serializable]
    public struct WorldData
    {
        public int worldSkybox;
        public int worldTerrainTexture;
        public int worldTerrainWidth;
        public int worldTerrainLength;

        public WorldData(GameManager gameManager)
        {
            worldSkybox = gameManager.posInSkyboxArray;
            worldTerrainTexture = gameManager.posInTerrainArray;
            worldTerrainWidth = gameManager.terrainWidth;
            worldTerrainLength = gameManager.terrainLength;
        }
    }
}
