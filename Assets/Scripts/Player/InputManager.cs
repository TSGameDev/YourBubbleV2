using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.UI;
using TSGameDev.Managers;

namespace TSGameDev.Interactables
{
    public class InputManager : MonoBehaviour
    {
        PlayerActions playerInputs;
        Player player;
        GameManager gameManager;
        //ColourPicker colourPicker;
        UIManager uiManager;

        private void Awake()
        {
            playerInputs = new PlayerActions();
            player = GetComponent<Player>();
            gameManager = FindObjectOfType<GameManager>();
            //colourPicker = FindObjectOfType<ColourPicker>();
            uiManager = FindObjectOfType<UIManager>();

            gameManager.player = player;
            gameManager.inputManager = this;

            playerInputs.Game.WASD.performed += ctx => player.inputMovement = ctx.ReadValue<Vector2>();
            playerInputs.Game.Interaction.performed += ctx => player.Interaction();
            playerInputs.Game.MainMenu.performed += ctx => gameManager.gameStateActions.ChangeToState(GameState.UI);
            playerInputs.Game.AssetMenu.performed += ctx => gameManager.gameStateActions.ChangeToState(GameState.AssetMenu);
            playerInputs.Game.QuickExit.performed += ctx => uiManager.QuitApplication();

            player.running = playerInputs.Game.Running;

            //playerInputs.UI.MousePosition.performed += ctx => colourPicker.mousePos = ctx.ReadValue<Vector2>();
            //playerInputs.UI.MouseClick.performed += ctx => colourPicker.CallbackContext = ctx;
            playerInputs.UI.ExitMenu.performed += ctx => gameManager.gameStateActions.ChangeToState(GameState.Application);
        }

        private void OnEnable()
        {
            playerInputs.Enable();
            playerInputs.Game.Enable();
            playerInputs.UI.Disable();
        }

        private void OnDisable()
        {
            playerInputs.Disable();

            playerInputs.Game.WASD.performed -= ctx => player.inputMovement = ctx.ReadValue<Vector2>();
            playerInputs.Game.Interaction.performed -= ctx => player.Interaction();
            playerInputs.Game.MainMenu.performed -= ctx => gameManager.gameStateActions.ChangeToState(GameState.UI);
            playerInputs.Game.AssetMenu.performed -= ctx => gameManager.gameStateActions.ChangeToState(GameState.AssetMenu);
            playerInputs.Game.QuickExit.performed -= ctx => uiManager.QuitApplication();

            playerInputs.UI.ExitMenu.performed -= ctx => gameManager.gameStateActions.ChangeToState(GameState.Application);
        }

        public void ActiveUIInputs()
        {
            playerInputs.Game.Disable();
            playerInputs.UI.Enable();
        }

        public void ActiveGameInputs()
        {
            playerInputs.UI.Disable();
            playerInputs.Game.Enable();
        }
    }
}
