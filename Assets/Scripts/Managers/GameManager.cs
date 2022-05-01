using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TSGameDev.Interactables;
using TSGameDev.Data;
using TSGameDev.Object;
using System.Collections.Generic;

namespace TSGameDev.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Getter-Setter
        public BubbleData worldData;
        public List<ObjectData> savedWorldObjects;

        [Header("Scene Creation")]
        [SerializeField] Material[] skyboxes;
        public Material[] Skyboxes
        {
            private set {}
            get { return skyboxes; }
        }
        public int posInSkyboxArray = 0;

        [SerializeField] Material[] terrainTextures;
        public Material[] TerrainTextures
        {
            private set {}
            get { return terrainTextures; }
        }
        public int posInTerrainArray = 0;
        public int terrainWidth;
        public int terrainLength;
        [Space(10)]

        [Header("Post Processing")]
        [SerializeField] VolumeProfile volumeProfile;
        public ScenePostProcessingData scenePostProcessingData;
        [Space(10)]
        #endregion

        #region Public Variables
        public GameStateAction gameStateActions;
        
        [Header("Game State Settings")]
        public GameState gameState;
        public Player player;
        public InputManager inputManager;

        public static GameManager instance;

        //reference to player data to set and record the different settings for easily manipulation and saving.
        public PlayerSettingsData playerSettingsData;
        #endregion

        UIManager uiManager;
        AudioManager audioManager;
        SceneDatabase sceneDatabase;
        public CreateBubble createBubble;

        //Awake called just before start and after variable inisilisation. Sets up the game manager as a singleton instance
        private void Awake()
        {
            if(instance == null)
                instance = this;
            else
                Destroy(this);

            DontDestroyOnLoad(instance);

            gameState = GameState.UI;
            gameStateActions = new MainMenuStateAction(this);
            uiManager = FindObjectOfType<UIManager>();
            audioManager = FindObjectOfType<AudioManager>();
            sceneDatabase = FindObjectOfType<SceneDatabase>();
        }

        private void Start()
        {
            playerSettingsData = SaveSystem.LoadPlayerSettingsData(uiManager);
            scenePostProcessingData = new ScenePostProcessingData(volumeProfile);
            worldData = SaveSystem.LoadWorldData(this);
            savedWorldObjects = SaveSystem.LoadWorldObjects();
        }

        /// <summary>
        /// Function to close the Asset menu
        /// </summary>
        public void CloseAssetMenu()
        {
            gameStateActions.ChangeToState(GameState.Application);
        }
    
        public void SavePlayerData()
        {
            SaveSystem.SavePlayerSettingsData(playerSettingsData);
        }
        
        public void LoadPlayerData()
        {
            audioManager.Init(playerSettingsData);
            uiManager.Init(playerSettingsData);
        }
    
        public void SaveWorldData()
        {
            if(player != null)
                worldData.playerPosition = player.transform.position;
            
            SaveSystem.SaveWorldData(worldData);
        }
       
        public void LoadWorldData()
        {
            LoadScene(worldData);
        }

        /// <summary>
        /// function to create the new scene of which the player can spawn different models, effects and sounds to build an environment
        /// </summary>
        public void CreateScene()
        {
            SceneManager.CreateScene("TestSceneCreation");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestSceneCreation"));
            RenderSettings.skybox = createBubble.currentSkybox;

            uiManager.OpenCloseBubbleSettingsMenu(false, false);

            TerrainData newTerrainData = new TerrainData();
            newTerrainData.size = new Vector3(createBubble.currentTerrainWidth, 0, createBubble.currentTerrainLength);
            Terrain newTerrain = Terrain.CreateTerrainGameObject(newTerrainData).GetComponent<Terrain>();
            newTerrain.materialTemplate = createBubble.currentTerrainTexture;
            newTerrain.terrainData = newTerrainData;

            if(worldData.playerPosition != new Vector3())
                Instantiate(createBubble.playerSetup, worldData.playerPosition, Quaternion.identity);
            else
                Instantiate(createBubble.playerSetup, new Vector3(createBubble.currentTerrainWidth / 2, 0, createBubble.currentTerrainLength / 2), Quaternion.identity);
            
            createBubble.sceneObjectDatabase.PopulateAssetMenu();
            SceneManager.MoveGameObjectToScene(createBubble.cameraa, SceneManager.GetSceneByName("TestSceneCreation"));

            gameState = GameState.Application;
            gameStateActions = new ApplicationStateAction(this);

            if(savedWorldObjects.Count > 0)
                sceneDatabase.SpawnSavedWorldObjects(savedWorldObjects);

            worldData.worldSkybox = posInSkyboxArray;
            worldData.worldTerrainTexture = posInTerrainArray;
            worldData.worldTerrainLength = createBubble.currentTerrainLength;
            worldData.worldTerrainWidth = createBubble.currentTerrainWidth;
        }

        void LoadScene(BubbleData bubbleData)
        {
            createBubble.currentSkybox = Skyboxes[bubbleData.worldSkybox];
            createBubble.currentTerrainTexture = TerrainTextures[bubbleData.worldTerrainTexture];
            createBubble.currentTerrainLength = bubbleData.worldTerrainLength;
            createBubble.currentTerrainWidth = bubbleData.worldTerrainWidth;

            uiManager.OpenCloseMainMenu(false);

            CreateScene();
        }

        public void SaveWorldObjectData()
        {
            List<ObjectData> allWorldObjectData = new List<ObjectData>();
            Object.Object[] allWorldObjects = FindObjectsOfType(typeof(Object.Object)) as Object.Object[];
            foreach (Object.Object obj in allWorldObjects)
            {
                allWorldObjectData.Add(obj.data);
            }
            SaveSystem.SaveWorldObjects(allWorldObjectData);
        }
    }
}
