using UnityEngine;
using TSGameDev.Interactables;
using UnityEngine.Rendering;
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

        public Player player;

        public InputManager inputManager;
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

            gameState = GameState.UI;
            gameStateActions = new MainMenuStateAction(this);
            scenePostProcessingData = new ScenePostProcessingData(volumeProfile);
        }
    
        public void CloseAssetMenu()
        {
            gameStateActions.ChangeToState(GameState.Application);
        }
    }
}
