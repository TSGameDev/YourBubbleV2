using UnityEngine;
using UnityEngine.InputSystem;
using TSGameDev.Data;
using TMPro;

public class RebindHandler : MonoBehaviour
{
    #region Input Action References

    //Reference to all the Input Actions for the purpose of rebinding controls
    [Header("Input Action References")]
    public InputActionReference mainMenu;
    public InputActionReference assetMenu;
    public InputActionReference run;
    public InputActionReference quickExit;
    public InputActionReference interaction;
    [Space(10)]

    #endregion

    #region Input Action Binding Texts

    //Reference to the Text elements of each UI control binding to update when the control has been changed.
    [Header("Input Action Binding Texts")]
    [SerializeField] TextMeshProUGUI mainMenuBindingTxt;
    [SerializeField] TextMeshProUGUI assetMenuBindingTxt;
    [SerializeField] TextMeshProUGUI runBindingTxt;
    [SerializeField] TextMeshProUGUI quickExitBindingTxt;
    [SerializeField] TextMeshProUGUI interactionBindingTxt;
    [Space(5)]

    //Reference to a text elements gameobject for the purpose of displaying "Waiting for Binding" when the rebinding process as begin and then player needs to input a control
    [SerializeField] TextMeshProUGUI waitingForBindTxt;
    
    //Player Raycast interaction text
    [SerializeField] TextMeshProUGUI playerRaycastTxt;
    public TextMeshProUGUI PlayerRaycastText
    {
        private set { playerRaycastTxt = value; }
        get { return playerRaycastTxt; }
    }

    #endregion

    #region Input Action String Constants

    //Constant string references to the bindings so there is no worry of accidently misspelling a string reference.
    const string mainMenuBindingKey = "Main Menu";
    const string assetMenuBindingKey = "Asset Menu";
    const string runBindingKey = "Run";
    const string quickExitBindingKey = "Quick Exit";
    const string interactionBindingKey = "Interaction";
    const string waitingForBindString = "Waiting For Bind";

    #endregion

    //A cache of the rebinding controler operation to discard the memory used to prevent memory leakage
    InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    public void Init(PlayerSettingsData playerData)
    {
        mainMenu.action.ApplyBindingOverride(playerData.mainMenuBindingPath);
        assetMenu.action.ApplyBindingOverride(playerData.assetMenuBindingPath);
        run.action.ApplyBindingOverride(playerData.runBindingPath);
        quickExit.action.ApplyBindingOverride(playerData.quickExitBindingPath);
        interaction.action.ApplyBindingOverride(playerData.interactionBindingPath);

        mainMenuBindingTxt.text = InputControlPath.ToHumanReadableString(mainMenu.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        assetMenuBindingTxt.text = InputControlPath.ToHumanReadableString(assetMenu.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        runBindingTxt.text = InputControlPath.ToHumanReadableString(run.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        quickExitBindingTxt.text = InputControlPath.ToHumanReadableString(quickExit.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        interactionBindingTxt.text = InputControlPath.ToHumanReadableString(interaction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    /// <summary>
    /// Function called when the player clicks on a control button, decides on what action is to be rebinded using the passed in name
    /// </summary>
    /// <param name="BindingKey">Name of the control to rebind</param>
    public void StartRebinding(string BindingKey, PlayerSettingsData playerData)
    {
        //actives a "Waiting for Binding" text to show the user to input a binding.
        waitingForBindTxt.text = waitingForBindString;
        switch (BindingKey)
        {
            case mainMenuBindingKey:
                Rebinding(mainMenu, mainMenuBindingTxt, BindingKey, playerData);
                break;
            case assetMenuBindingKey:
                Rebinding(assetMenu, assetMenuBindingTxt, BindingKey, playerData);
                break;
            case runBindingKey:
                Rebinding(run, runBindingTxt, BindingKey, playerData);
                break;
            case quickExitBindingKey:
                Rebinding(quickExit, quickExitBindingTxt, BindingKey, playerData);
                break;
            case interactionBindingKey:
                Rebinding(interaction, interactionBindingTxt, BindingKey, playerData);
                break;
        }
    }

    /// <summary>
    /// The function called to start the rebinding process with the correct action to change. Excludes all mouse controls for the binding.
    /// </summary>
    /// <param name="actionToRebind">The Action Reference within the Input Map to rebind</param>
    /// <param name="actionRebindingTxt">The text element within the player control settings corisponding to the control that is being rebinded</param>
    void Rebinding(InputActionReference actionToRebind, TextMeshProUGUI actionRebindingTxt, string BindingKey, PlayerSettingsData playerData)
    {
        //caches the operation Unity Input System uses to change a binding. Added the options to exclude mouse controls, call a function on completion and wait 0.1 second before completing the operation of the press of a valid control.
        rebindingOperation = actionToRebind.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => EndRebinding(actionToRebind, actionRebindingTxt, BindingKey, playerData))
            .Start();
    }

    /// <summary>
    /// The process to be carried out when the rebind is complete, Includes disposing of the task to regain memory and setting text elements.
    /// </summary>
    /// <param name="actionToRebind">The Action Reference within the Input Map to rebind</param>
    /// <param name="actionRebindingTxt">The text element within the player control settings corisponding to the control taht is being rebinded</param>
    void EndRebinding(InputActionReference actionToRebind, TextMeshProUGUI actionRebindingTxt, string BindingKey, PlayerSettingsData playerData)
    {
        //removes task from memory and waiting for bind text
        waitingForBindTxt.text = "";
        rebindingOperation.Dispose();

        //set the relivant text element to the new control
        actionRebindingTxt.text = InputControlPath.ToHumanReadableString(actionToRebind.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        switch (BindingKey)
        {
            case mainMenuBindingKey:
                playerData.mainMenuBindingPath = actionToRebind.action.bindings[0].overridePath;
                break;
            case assetMenuBindingKey:
                playerData.assetMenuBindingPath = actionToRebind.action.bindings[0].overridePath;
                break;
            case runBindingKey:
                playerData.runBindingPath = actionToRebind.action.bindings[0].overridePath;
                break;
            case quickExitBindingKey:
                playerData.quickExitBindingPath = actionToRebind.action.bindings[0].overridePath;
                break;
            case interactionBindingKey:
                playerData.interactionBindingPath = actionToRebind.action.bindings[0].overridePath;
                break;
        }
    }

}
