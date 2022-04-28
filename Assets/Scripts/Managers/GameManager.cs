using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TSGameDev.Interactables;
using TSGameDev.Data;

namespace TSGameDev.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Getter-Setter
        public WorldData worldData
        {
            private set;
            get;
        }

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
        }

        private void Start()
        {
            playerSettingsData = SaveSystem.LoadPlayerSettingsData(uiManager);
            scenePostProcessingData = new ScenePostProcessingData();
            worldData = SaveSystem.LoadWorldData(this);
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
            SaveSystem.SaveWorldData(worldData);
        }

        public void LoadWorldData()
        {

        }

    }
}
