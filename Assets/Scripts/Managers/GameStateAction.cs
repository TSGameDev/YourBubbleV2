using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.Managers;
using TSGameDev.Interactions;

public abstract class GameStateAction
{
    protected GameManager gameManager;
    protected Player player;
    protected UIManager uiManager;
    protected InputManager inputManager;
    
    public GameStateAction (GameManager gameManager)
    {
        this.gameManager = gameManager;
        player = gameManager.Player;
        uiManager = gameManager.UIManager;
        inputManager = gameManager.InputManager;
}

    public virtual void ChangeToState(GameState state) { }
}

public class ApplicationStateAction : GameStateAction
{
    public ApplicationStateAction(GameManager gameManager) : base(gameManager)
    {
    }

    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.UI:
                player.LockUnlockCursor(false);
                inputManager.ActiveUIInputs(true);
                player.LockUnlockCamera(true);
                gameManager.gameState = GameState.UI;
                gameManager.gameStateActions = new UIStateAction(gameManager);
                uiManager.OpenMainMenu();
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

public class UIStateAction : GameStateAction
{
    public UIStateAction(GameManager gameManager) : base(gameManager)
    {
    }

    public override void ChangeToState(GameState state)
    {
        switch (state)
        {
            case GameState.Application:
                player.LockUnlockCursor(true);
                inputManager.ActiveUIInputs(false);
                player.LockUnlockCamera(false);
                gameManager.gameState = GameState.Application;
                gameManager.gameStateActions = new ApplicationStateAction(gameManager);
                uiManager.CloseMainMenu();
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
    Application,
    UI,
    CameraRail,
    Terraform,
}

