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
        [Header("Scene Creation")]
        [SerializeField] Material[] skyboxes;
        public Material[] Skyboxes
        {
            private set {}
            get { return skyboxes; }
        }

        [SerializeField] Material[] terrainTextures;
        public Material[] TerrainTextures
        {
            private set {}
            get { return terrainTextures; }
        }
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
            scenePostProcessingData = new ScenePostProcessingData(volumeProfile);
            uiManager = FindObjectOfType<UIManager>();
            audioManager = FindObjectOfType<AudioManager>();
        }

        private void Start()
        {
            playerSettingsData = SaveSystem.LoadPlayerSettingsData(uiManager);
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
    }
}
