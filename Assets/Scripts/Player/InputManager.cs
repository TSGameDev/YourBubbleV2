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
        ColourPicker colourPicker;
        Player player;

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
            colourPicker = FindObjectOfType<ColourPicker>();

            playerInputs.Game.WASD.performed += ctx => player.inputMovement = ctx.ReadValue<Vector2>();
            playerInputs.Game.Interaction.performed += ctx => player.Interaction();
            playerInputs.Game.MainMenu.performed += ctx => GameManager.Instance.gameManager.ChangeToState(GameState.UI);
    
            player.running = playerInputs.Game.Running;

            playerInputs.UI.MousePosition.performed += ctx => colourPicker.mousePos = ctx.ReadValue<Vector2>();
            playerInputs.UI.MouseClick.performed += ctx => colourPicker.CallbackContext = ctx;
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
