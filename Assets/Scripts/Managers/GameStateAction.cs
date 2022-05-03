using TSGameDev.Managers;
using TSGameDev.Interactables;

//Base template for the game state machine
public abstract class GameStateAction
{
    #region Variables

    protected GameManager gameManager;
    protected Player player;
    protected InputManager inputManager;
    protected TweenHandler tweenHandler;

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
        tweenHandler = gameManager.TweenHandler;
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

    public override void ChangeToState(GameState state)
    {
        switch(state)
        {
            case GameState.Application:
                break;
        }
    }
}

//Application or main game stater for when the user is walking around placing objects.
public class ApplicationStateAction : GameStateAction
{
    public ApplicationStateAction(GameManager gameManager) : base(gameManager) { }

    /// <summary>
    /// Function to change from the application state to any linked/attached gamestates
    /// </summary>
    /// <param name="state">The state you wish to change to</param>
    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.UI:
                player.LockUnlockCursor(false);
                inputManager.ActiveUIInputs();
                player.LockUnlockCamera(true);
                tweenHandler.OpenCloseMainMenu(true);
                gameManager.gameState = GameState.UI;
                gameManager.gameStateActions = new UIStateAction(gameManager);
                break;
            case GameState.AssetMenu:
                player.LockUnlockCursor(false);
                inputManager.ActiveUIInputs();
                player.LockUnlockCamera(true);
                tweenHandler.OpenCloseAssetMenu(true);
                gameManager.gameState = GameState.AssetMenu;
                gameManager.gameStateActions = new AssetMenuStateAction(gameManager);
                break;
            case GameState.AssetSettings:
                player.LockUnlockCursor(false);
                inputManager.ActiveUIInputs();
                player.LockUnlockCamera(true);
                tweenHandler.OpenCloseAssetSettingsMenu(true);
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

    /// <summary>
    /// Function to change from the Asset Menu state to any linked/attached gamestates
    /// </summary>
    /// <param name="state">The state you wish to change to</param>
    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.Application:
                player.LockUnlockCursor(true);
                inputManager.ActiveGameInputs();
                player.LockUnlockCamera(false);
                tweenHandler.OpenCloseAssetMenu(false);
                gameManager.gameState = GameState.Application;
                gameManager.gameStateActions = new ApplicationStateAction(gameManager);
                break;
        }

    }
}

//Asset Settings State for when the user enters the asset setting ui.
public class AssetSettingsAction : GameStateAction
{
    public AssetSettingsAction(GameManager gameManager) : base(gameManager) { }

    /// <summary>
    /// Function to change from the Asset Settings state to any linked/attached gamestates
    /// </summary>
    /// <param name="state">The state you wish to change to</param>
    public override void ChangeToState(GameState state)
    {
        switch(state)
        {
            case GameState.Application:
                player.LockUnlockCursor(true);
                inputManager.ActiveGameInputs();
                player.LockUnlockCamera(false);
                tweenHandler.OpenCloseAssetSettingsMenu(false);
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

    /// <summary>
    /// Function to change from the UI state to any linked/attached gamestates
    /// </summary>
    /// <param name="state">The state you wish to change to</param>
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
                tweenHandler.OpenCloseMainMenu(false);
                break;
        }
    }
}

