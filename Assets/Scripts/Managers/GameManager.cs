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
        #region World Data
        [Header("World Data")]
        public GameState gameState;
        public BubbleData worldData;
        public List<ObjectData> savedWorldObjects;

        [SerializeField] Material[] skyboxes;
        public Material[] Skyboxes
        {
            private set { }
            get { return skyboxes; }
        }

        [SerializeField] Material[] terrainTextures;
        public Material[] TerrainTextures
        {
            private set { }
            get { return terrainTextures; }
        }

        public int posInSkyboxArray = 0;
        public int posInTerrainArray = 0;
        public int terrainWidth;
        public int terrainLength;

        [SerializeField] VolumeProfile volumeProfile;
        public ScenePostProcessingData scenePostProcessingData;

        public PlayerSettingsData playerSettingsData;
        [Space(10)]
        #endregion

        #region Dependancies

        public GameStateAction gameStateActions;
        public Player player;
        public InputManager inputManager;
        public CreateBubble createBubble;

        [SerializeField] RebindHandler rebindHandler;
        [SerializeField] TweenHandler tweenHandler;
        public TweenHandler TweenHandler
        {
            private set
            {
                tweenHandler = value;
            }
            get
            {
                return tweenHandler;
            }
        }

        AudioManager audioManager;
        SceneDatabase sceneDatabase;

        #endregion

        public static GameManager instance;
        private void Awake()
        {
            if(instance == null)
                instance = this;
            else
                Destroy(this);

            DontDestroyOnLoad(instance);

            gameState = GameState.UI;
            gameStateActions = new MainMenuStateAction(this);
            audioManager = FindObjectOfType<AudioManager>();
            sceneDatabase = FindObjectOfType<SceneDatabase>();
        }

        private void Start()
        {
            scenePostProcessingData = new ScenePostProcessingData(volumeProfile);

            playerSettingsData = SaveSystem.LoadPlayerSettingsData(rebindHandler);
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
        
        /// <summary>
        /// Function to save the player settings data via the SaveSystem static class
        /// </summary>
        public void SavePlayerData()
        {
            SaveSystem.SavePlayerSettingsData(playerSettingsData);
        }
        
        /// <summary>
        /// Function to perform the setting or variables and data when wanting to load the player data
        /// </summary>
        public void LoadPlayerData()
        {
            audioManager.Init(playerSettingsData);
            rebindHandler.Init(playerSettingsData);
        }
        
        /// <summary>
        /// Function to save the world data via the SaveSystem static class
        /// </summary>
        public void SaveWorldData()
        {
            if(player != null)
                worldData.playerPosition = player.transform.position;
            
            SaveSystem.SaveWorldData(worldData);
        }
       
        /// <summary>
        /// Function to class the load scene function to recreate the preivouse bubble
        /// </summary>
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

            tweenHandler.OpenCloseBubbleSettingsMenu(false, false);

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

        /// <summary>
        /// Function that recreates the previously active bubble from save data
        /// </summary>
        /// <param name="bubbleData"></param>
        void LoadScene(BubbleData bubbleData)
        {
            createBubble.currentSkybox = Skyboxes[bubbleData.worldSkybox];
            createBubble.currentTerrainTexture = TerrainTextures[bubbleData.worldTerrainTexture];
            createBubble.currentTerrainLength = bubbleData.worldTerrainLength;
            createBubble.currentTerrainWidth = bubbleData.worldTerrainWidth;

            tweenHandler.OpenCloseMainMenu(false);

            CreateScene();
        }

        /// <summary>
        /// Function that saves the objects in the preivously active bubble via the SaveSystem static class
        /// </summary>
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
