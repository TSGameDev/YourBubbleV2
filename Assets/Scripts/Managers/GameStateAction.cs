using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.Managers;
using TSGameDev.Interactables;

public abstract class GameStateAction
{
    protected GameManager gameManager;
    protected Player player;
    protected UIManager uiManager;
    protected InputManager inputManager;

    public GameStateAction (GameManager gameManager)
    {
        this.gameManager = gameManager;

        player = gameManager.player;
        uiManager = gameManager.UIManager;
        inputManager = gameManager.inputManager;
    }

    public virtual void ChangeToState(GameState state) { }
}

public class MainMenuStateAction : GameStateAction
{
    public MainMenuStateAction(GameManager gameManager) : base(gameManager) {}

}

public class ApplicationStateAction : GameStateAction
{

    public ApplicationStateAction(GameManager gameManager) : base(gameManager) { }

    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.UI:
                player.LockUnlockCursor(false);
                inputManager.ActiveUIInputs();
                player.LockUnlockCamera(true);
                uiManager.OpenCloseMainMenu(true);
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
                uiManager.OpenCloseAssetMenu(true);
                gameManager.gameState = GameState.AssetMenu;
                gameManager.gameStateActions = new AssetMenuStateAction(gameManager);
                break;
            case GameState.AssetSettings:

                break;
        }
    }
}

public class AssetMenuStateAction : GameStateAction
{
    public AssetMenuStateAction(GameManager gameManager) : base(gameManager) { }

    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.Application:
                player.LockUnlockCursor(true);
                inputManager.ActiveGameInputs();
                player.LockUnlockCamera(false);
                uiManager.OpenCloseAssetMenu(false);
                gameManager.gameState = GameState.Application;
                gameManager.gameStateActions = new ApplicationStateAction(gameManager);
                break;
            default:

                break;
        }

    }
}

public class UIStateAction : GameStateAction
{
    
    public UIStateAction(GameManager gameManager) : base(gameManager) { }

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
                uiManager.OpenCloseMainMenu(false);
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

public class CameraRailStateAction : GameStateAction
{
    public CameraRailStateAction(GameManager gameManager) : base(gameManager)
    {
    }

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

public class TerraformStateAction : GameStateAction
{
    public TerraformStateAction(GameManager gameManager) : base(gameManager)
    {
    }

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

