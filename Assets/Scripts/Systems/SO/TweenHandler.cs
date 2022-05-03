using TSGameDev.UI;
using UnityEngine;

public class TweenHandler : MonoBehaviour
{
    #region Tween Objects

    //References to all the different UI tween scripts to impliment slightly more complex tweening E.G. the main menu transitions to multiple different menus
    [Header("Tween Objects")]
    [SerializeField] UITween mainMenuBeginTween;
    [SerializeField] UITween mainMenuReturnTween;
    [SerializeField] UITween playerSettingsTween;
    [SerializeField] UITween quitPromptTween;
    [SerializeField] UITween bubbleSettingsTween;
    [SerializeField] UITween assetMenuTween;
    [SerializeField] UITween assetSettingsTween;

    #endregion

    /// <summary>
    /// The user selects a UI state from the main menu buttons, this function is then called when the Main Menu is tweened out, tweening in the correct UI menu using the change UI state with correct tweening times.
    /// </summary>
    public void MainMenuChange(string StateToChange)
    {
        switch (StateToChange)
        {
            case "Player Settings":
                playerSettingsTween.BeginTween();
                break;
            case "Bubble Settings":
                bubbleSettingsTween.BeginTween();
                break;
            case "Quit":
                quitPromptTween.BeginTween();
                break;
        }
    }

    /// <summary>
    /// Function called when the user opens the main menu during play.
    /// </summary>
    /// <param name="Open">Should the menu open. True means yes, False means no.</param>
    public void OpenCloseMainMenu(bool Open)
    {
        if (Open)
            mainMenuBeginTween.BeginTween();
        else
            mainMenuReturnTween.ReturnTween();
    }

    /// <summary>
    /// Function called when the user opens the asset menu during play.
    /// </summary>
    /// <param name="Open">Should the menu open. True means yes, False means no.</param>
    public void OpenCloseAssetMenu(bool Open)
    {
        if (Open)
            assetMenuTween.BeginTween();
        else
            assetMenuTween.ReturnTween();
    }

    /// <summary>
    /// Function called when the user opens the asset settings menu during play
    /// </summary>
    /// <param name="Open">Should the menu open. True means yes, False means no.</param>
    public void OpenCloseAssetSettingsMenu(bool Open)
    {
        if (Open)
            assetSettingsTween.BeginTween();
        else
            assetSettingsTween.ReturnTween();
    }

    /// <summary>
    /// Function called when the user opens the bubble settings menu during play
    /// </summary>
    /// <param name="Open">Should the menu open. True means yes, False means no.</param>
    public void OpenCloseBubbleSettingsMenu(bool Open, bool InvokeReturns = true)
    {
        if (Open)
            bubbleSettingsTween.BeginTween();
        else if (!InvokeReturns)
            bubbleSettingsTween.ReturnTween(false);
        else
            bubbleSettingsTween.ReturnTween();
    }

}
