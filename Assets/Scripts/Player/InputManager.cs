using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.UI;
using TSGameDev.Managers;

namespace TSGameDev.Interactions
{
    public class InputManager : MonoBehaviour
    {
        PlayerActions playerInputs;
        Player player;
        GameManager gameManager;
        ColourPicker colourPicker;

        private void OnEnable()
        {
            playerInputs.Enable();
            playerInputs.Game.Enable();
            playerInputs.UI.Disable();
        }

        private void Awake()
        {
            playerInputs = new PlayerActions();
            player = GetComponent<Player>();
            gameManager = FindObjectOfType<GameManager>();
            colourPicker = FindObjectOfType<ColourPicker>();

            playerInputs.Game.WASD.performed += ctx => player.inputMovement = ctx.ReadValue<Vector2>();
            playerInputs.Game.Interaction.performed += ctx => player.Interaction();
            playerInputs.Game.MainMenu.performed += ctx => gameManager.gameStateActions.ChangeToState(GameState.UI);

    
            player.running = playerInputs.Game.Running;

            playerInputs.UI.MousePosition.performed += ctx => colourPicker.mousePos = ctx.ReadValue<Vector2>();
            playerInputs.UI.MouseClick.performed += ctx => colourPicker.CallbackContext = ctx;
            playerInputs.UI.ExitMenu.performed += ctx => gameManager.gameStateActions.ChangeToState(GameState.Application);
        }

        private void OnDisable()
        {
            playerInputs.Disable();
        }

        public void ActiveUIInputs(bool activateUI = false)
        {
            if(activateUI)
            {
                playerInputs.Game.Disable();
                playerInputs.UI.Enable();
            }
            else
            {
                playerInputs.Game.Enable();
                playerInputs.UI.Disable();
            }
        }
    }
}
