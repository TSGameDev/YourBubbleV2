using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.Managers;
using TSGameDev.Interactables;
using UnityEngine.Rendering;

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

        [SerializeField] Player player;
        public Player Player
        {
            private set {}
            get { return player; }
        }

        [SerializeField] InputManager inputManager;
        public InputManager InputManager
        {
            private set {}
            get { return inputManager; }
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
        
        [SerializeField] VolumeProfile volumeProfile;
        public ScenePostProcessingData scenePostProcessingData;
        
        #endregion

        #region Public Variables
 
        public GameStateAction gameStateActions;
        public GameState gameState;

        public static GameManager instance;
        #endregion

        private void Awake()
        {
            if(instance == null)
                instance = this;
            else
                Destroy(this);

            DontDestroyOnLoad(instance);

            gameState = GameState.Application;
            gameStateActions = new ApplicationStateAction(this);
            scenePostProcessingData = new ScenePostProcessingData(volumeProfile);
        }
    
        public void CloseAssetMenu()
        {
            gameStateActions.ChangeToState(GameState.Application);
        }
    }
}
