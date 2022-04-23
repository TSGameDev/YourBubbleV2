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
        [Header("Managers")]
        [SerializeField] UIManager uiManager;
        public UIManager UIManager
        {
            private set {}
            get { return uiManager; }
        }
        [Space(10)]

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
        #endregion

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
        }
    
        /// <summary>
        /// Function to close the Asset menu
        /// </summary>
        public void CloseAssetMenu()
        {
            gameStateActions.ChangeToState(GameState.Application);
        }
    }
}
