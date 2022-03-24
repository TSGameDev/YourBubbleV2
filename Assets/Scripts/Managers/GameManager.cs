using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.Interactions;
using TSGameDev.UI;

namespace TSGameDev.Managers
{
    public class GameManager
    {
        public GameState gameState = GameState.Game;
        public GameManager gameManager = gameStateActions;
        public static GameStateActions gameStateActions = new GameStateActions();
        public static UIStateActions uiStateActions = new UIStateActions();
        public static TerraformStateActions terraformStateActions = new TerraformStateActions();
        public static CameraRailStateActions cameraRailStateActions = new CameraRailStateActions();

        static GameManager instance;
        public static GameManager Instance 
        { 
            get 
            {
                if(instance == null)
                    instance = new GameManager();

                return instance;
            }
        }

        virtual public void ChangeToState(GameState state) { }
    }

    public class GameStateActions : GameManager
    {
        UIManager uiManager;
        Player player;
        InputManager inputManager;

        private void Awake()
        {
            //player = FindObjectOfType<Player>();
            //uiManager = FindObjectOfType<UIManager>();
            //inputManager = player.gameObject.GetComponent<InputManager>();
        }

        public override void ChangeToState(GameState state)
        {
            switch (state)
            {
                case GameState.UI:
                    player.LockUnlockCursor(false);
                    inputManager.ActiveUIInputs(true);
                    player.LockUnlockCamera(true);
                    gameState = GameState.UI;
                    gameManager = uiStateActions;
                    uiManager.OpenMainMenu();
                    break;
                case GameState.Terraforming:
                    gameState = GameState.Terraforming;
                    break;
                case GameState.CameraRail:
                    gameState = GameState.CameraRail;
                    break;
            }
        }
    }

    public class UIStateActions : GameManager
    {
        public override void ChangeToState(GameState state)
        {
            base.ChangeToState(state);
        }
    }

    public class TerraformStateActions : GameManager
    {
        public override void ChangeToState(GameState state)
        {
            switch (state)
            {
                case GameState.UI:
                    gameState = GameState.UI;
                    break;
                case GameState.Game:
                    gameState = GameState.Game;
                    break;
                case GameState.CameraRail:
                    gameState = GameState.CameraRail;
                    break;
            }
        }
    }

    public class CameraRailStateActions : GameManager
    {
        public override void ChangeToState(GameState state)
        {
            switch (state)
            {
                case GameState.UI:
                    gameState = GameState.UI;
                    break;
                case GameState.Terraforming:
                    gameState = GameState.Terraforming;
                    break;
                case GameState.Game:
                    gameState = GameState.Game;
                    break;
            }
        }
    }

    public enum GameState
    {
        Game,
        UI,
        Terraforming,
        CameraRail
    }
}
