using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.Managers;
using TSGameDev.Interactables;

namespace TSGameDev.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Getter-Setter

        [SerializeField] UIManager uiManager;
        public UIManager UIManager
        {
            private set { value = uiManager;}
            get { return uiManager; }
        }

        [SerializeField] Player player;
        public Player Player
        {
            private set { value = player; }
            get { return player; }
        }

        [SerializeField] InputManager inputManager;
        public InputManager InputManager
        {
            private set { value = inputManager; }
            get { return inputManager; }
        }

        #endregion

        #region Public Variables

        public GameStateAction gameStateActions;
        
        public GameState gameState;

        #endregion

        public static GameManager instance;
        private void Awake()
        {
            if(instance == null)
                instance = this;
            else
                Destroy(this);

            DontDestroyOnLoad(instance);

            gameState = GameState.Application;
            gameStateActions = new ApplicationStateAction(this);
        }
    
        public void CloseAssetMenu()
        {
            gameStateActions.ChangeToState(GameState.Application);
        }
    }
}
