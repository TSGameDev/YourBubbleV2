using UnityEngine.SceneManagement;
using TSGameDev.Managers;
using TSGameDev.Interactables;

//Base template for the game state machine
public abstract class GameStateAction
{
    #region Variables

    protected GameManager gameManager;
    protected Player player;
    protected InputManager inputManager;

    #endregion

    /// <summary>
    /// Constructor for the creation of a game state. Takes in the global game manager
    /// </summary>
    /// <param name="gameManager">Reference to the global game manager</param>
    public GameStateAction (GameManager gameManager)
    {
        this.gameManager = gameManager;

        player = gameManager.player;
        inputManager = gameManager.inputManager;
    }

    /// <summary>
    /// Overrideable function for all game states used to change from current state to others.
    /// </summary>
    /// <param name="state">The Game State to change to.</param>
    public virtual void ChangeToState(GameState state) { }
}

//Main menu game state. State to create bubbles and other game actions done within UI/Main Menu
public class MainMenuStateAction : GameStateAction
{
    public MainMenuStateAction(GameManager gameManager) : base(gameManager) {}

}

//Application or main game stater for when the user is walking around placing objects.
public class ApplicationStateAction : GameStateAction
{
    public ApplicationStateAction(GameManager gameManager) : base(gameManager) { }

    //Function containing all transitions from the application
    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.UI:
                player.LockUnlockCursor(false);
                inputManager.ActiveUIInputs();
                player.LockUnlockCamera(true);
                UIManager.instance.OpenCloseMainMenu(true);
                gameManager.gameState = GameState.UI;
                gameManager.gameStateActions = new UIStateAction(gameManager);
                break;
            case GameState.Terraform:
                gameManager.gameState = GameState.Terraform;
                gameManager.gameStateActions = new TerraformStateAction(gameManager);
                break;
            case GameState.CameraRail:
                gameManager.gameState = GameState.CameraRail;
                gameManager.gameStateActions = new CameraRailStateAction(gameManager);
                break;
            case GameState.AssetMenu:
                player.LockUnlockCursor(false);
                inputManager.ActiveUIInputs();
                player.LockUnlockCamera(true);
                UIManager.instance.OpenCloseAssetMenu(true);
                gameManager.gameState = GameState.AssetMenu;
                gameManager.gameStateActions = new AssetMenuStateAction(gameManager);
                break;
            case GameState.AssetSettings:
                player.LockUnlockCursor(false);
                inputManager.ActiveUIInputs();
                player.LockUnlockCamera(true);
                UIManager.instance.OpenCloseAssetSettingsMenu(true);
                gameManager.gameState = GameState.AssetSettings;
                gameManager.gameStateActions = new AssetSettingsAction(gameManager);
                break;
        }
    }
}

//Asset Menu state for when the user enters the asset menu.
public class AssetMenuStateAction : GameStateAction
{
    public AssetMenuStateAction(GameManager gameManager) : base(gameManager) { }

    //function containing all transitions from the Asset menu
    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.Application:
                player.LockUnlockCursor(true);
                inputManager.ActiveGameInputs();
                player.LockUnlockCamera(false);
                UIManager.instance.OpenCloseAssetMenu(false);
                gameManager.gameState = GameState.Application;
                gameManager.gameStateActions = new ApplicationStateAction(gameManager);
                break;
            default:
                break;
        }

    }
}

public class AssetSettingsAction : GameStateAction
{
    public AssetSettingsAction(GameManager gameManager) : base(gameManager) { }

    public override void ChangeToState(GameState state)
    {
        switch(state)
        {
            case GameState.Application:
                player.LockUnlockCursor(true);
                inputManager.ActiveGameInputs();
                player.LockUnlockCamera(false);
                UIManager.instance.OpenCloseAssetSettingsMenu(false);
                gameManager.gameState = GameState.Application;
                gameManager.gameStateActions = new ApplicationStateAction(gameManager);
                break;
        }
    }
}

//Ui state for when the user is in the Main menu or other ui menus
public class UIStateAction : GameStateAction
{
    public UIStateAction(GameManager gameManager) : base(gameManager) { }

    //function containing all transitions from the UI main menu
    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.Application:
                player.LockUnlockCursor(true);
                inputManager.ActiveGameInputs();
                player.LockUnlockCamera(false);
                gameManager.gameState = GameState.Application;
                gameManager.gameStateActions = new ApplicationStateAction(gameManager);
                UIManager.instance.OpenCloseMainMenu(false);
                break;
            case GameState.Terraform:
                gameManager.gameState = GameState.Terraform;
                gameManager.gameStateActions = new TerraformStateAction(gameManager);
                break;
            case GameState.CameraRail:
                gameManager.gameState = GameState.CameraRail;
                gameManager.gameStateActions = new CameraRailStateAction(gameManager);
                break;
        }
    }
}

//camera rail state for when the user is creating a camera rail within the bubble
public class CameraRailStateAction : GameStateAction
{
    public CameraRailStateAction(GameManager gameManager) : base(gameManager)
    {
    }

    //Function containing all transitions from the camera rail state
    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.Application:
                gameManager.gameState = GameState.Application;
                gameManager.gameStateActions = new ApplicationStateAction(gameManager);
                break;
            case GameState.Terraform:
                gameManager.gameState = GameState.Terraform;
                gameManager.gameStateActions = new TerraformStateAction(gameManager);
                break;
            case GameState.UI:
                gameManager.gameState = GameState.UI;
                gameManager.gameStateActions = new UIStateAction(gameManager);
                break;
        }
    }
}

//terraforming state for when the user is altering the terrain
public class TerraformStateAction : GameStateAction
{
    public TerraformStateAction(GameManager gameManager) : base(gameManager)
    {
    }

    //function containing all transitions from the terraforming state
    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.Application:
                gameManager.gameState = GameState.Application;
                gameManager.gameStateActions = new ApplicationStateAction(gameManager);
                break;
            case GameState.CameraRail:
                gameManager.gameState = GameState.CameraRail;
                gameManager.gameStateActions = new CameraRailStateAction(gameManager);
                break;
            case GameState.UI:
                gameManager.gameState = GameState.UI;
                gameManager.gameStateActions = new UIStateAction(gameManager);
                break;
        }
    }
}

//gamestate enum making it easier for manipulation of states
public enum GameState
{
    Mainmenu,
    Application,
    AssetMenu,
    AssetSettings,
    UI,
    CameraRail,
    Terraform,

}

