using UnityEngine;
using TSGameDev.Managers;

namespace TSGameDev.Interactables
{
    public class InputManager : MonoBehaviour
    {
        #region Private Variables

        PlayerActions playerInputs;
        Player player;
        GameManager gameManager;
        //ColourPicker colourPicker;
        UIManager uiManager;

        #endregion

        //Awake function called after variable inisalisation but before start.
        private void Awake()
        {
            //Assigns variables
            playerInputs = new PlayerActions();
            player = GetComponent<Player>();
            gameManager = FindObjectOfType<GameManager>();
            //colourPicker = FindObjectOfType<ColourPicker>();
            uiManager = FindObjectOfType<UIManager>();

            //dependancy injection into the game manager
            gameManager.player = player;
            gameManager.inputManager = this;
        }

        //Function called when the script is enabled
        private void OnEnable()
        {
            //enables the complete control scheme
            playerInputs.Enable();
            //enables game action maps while disabling the UI action map
            playerInputs.Game.Enable();
            playerInputs.UI.Disable();

            //assignes the controls of the player to the game action map
            playerInputs.Game.WASD.performed += ctx => player.inputMovement = ctx.ReadValue<Vector2>();
            playerInputs.Game.Interaction.performed += ctx => player.Interaction();
            playerInputs.Game.MainMenu.performed += ctx => gameManager.gameStateActions.ChangeToState(GameState.UI);
            playerInputs.Game.AssetMenu.performed += ctx => gameManager.gameStateActions.ChangeToState(GameState.AssetMenu);
            playerInputs.Game.QuickExit.performed += ctx => uiManager.QuitApplication();
            playerInputs.Game.MouseLeftClick.performed += ctx => player.callBackDelegate(ctx);
            playerInputs.Game.ObjectRotationLeft.performed += ctx => player.callBackDelegate(ctx);
            playerInputs.Game.ObjectRotationRight.performed += ctx => player.callBackDelegate(ctx);
            player.running = playerInputs.Game.Running;

            //assgins player controls for the UI action map
            //playerInputs.UI.MousePosition.performed += ctx => colourPicker.mousePos = ctx.ReadValue<Vector2>();
            //playerInputs.UI.MouseClick.performed += ctx => colourPicker.CallbackContext = ctx;
            playerInputs.UI.ExitMenu.performed += ctx => gameManager.gameStateActions.ChangeToState(GameState.Application);
        }

        //function called when the script is disabled
        private void OnDisable()
        {
            //disables the control scheme
            playerInputs.Disable();


            //unassigns all the controls to retrive memory
            playerInputs.Game.WASD.performed -= ctx => player.inputMovement = ctx.ReadValue<Vector2>();
            playerInputs.Game.Interaction.performed -= ctx => player.Interaction();
            playerInputs.Game.MainMenu.performed -= ctx => gameManager.gameStateActions.ChangeToState(GameState.UI);
            playerInputs.Game.AssetMenu.performed -= ctx => gameManager.gameStateActions.ChangeToState(GameState.AssetMenu);
            playerInputs.Game.QuickExit.performed -= ctx => uiManager.QuitApplication();

            playerInputs.UI.ExitMenu.performed -= ctx => gameManager.gameStateActions.ChangeToState(GameState.Application);
        }

        //function to active the UI action map
        public void ActiveUIInputs()
        {
            playerInputs.Game.Disable();
            playerInputs.UI.Enable();
        }

        //function to active the game action map
        public void ActiveGameInputs()
        {
            playerInputs.UI.Disable();
            playerInputs.Game.Enable();
        }
    }
}
