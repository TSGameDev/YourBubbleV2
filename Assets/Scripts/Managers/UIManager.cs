using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TSGameDev.UI;
using TMPro;

namespace TSGameDev.Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Tween Objects

        [Header("Tween Objects")]
        [SerializeField] UITween mainMenuBeginTween;
        [SerializeField] UITween mainMenuReturnTween;
        [SerializeField] UITween playerSettingsTween;
        [SerializeField] UITween quitPromptTween;
        [SerializeField] UITween bubbleSettingsTween;
        [SerializeField] UITween assetMenuTween;
        [SerializeField] UITween assetSettingsTween;
        [Space(10)]

        #endregion

        #region Input Action References

        [Header("Input Action References")]
        [SerializeField] InputActionReference mainMenu;
        [SerializeField] InputActionReference assetMenu;
        [SerializeField] InputActionReference run;
        [SerializeField] InputActionReference quickExit;
        [SerializeField] InputActionReference terraforming;
        [SerializeField] InputActionReference interaction;
        [SerializeField] InputActionReference cameraRail;
        [Space(10)]

        #endregion

        #region Input Action Binding Texts

        [Header("Input Action Binding Texts")]
        [SerializeField] TextMeshProUGUI mainMenuBindingTxt;
        [SerializeField] TextMeshProUGUI assetMenuBindingTxt;
        [SerializeField] TextMeshProUGUI runBindingTxt;
        [SerializeField] TextMeshProUGUI quickExitBindingTxt;
        [SerializeField] TextMeshProUGUI terraformingBindingTxt;
        [SerializeField] TextMeshProUGUI interactionBindingTxt;
        [SerializeField] TextMeshProUGUI cameraRailBindingTxt;
        [Space(5)]

        [SerializeField] GameObject waitingForBindTxt;

        #endregion

        #region Input Action String Constants

        const string mainMenuBindingKey = "Main Menu";
        const string assetMenuBindingKey = "Asset Menu";
        const string runBindingKey = "Run";
        const string quickExitBindingKey = "Quick Exit";
        const string terraformingBindingKey = "Terraforming";
        const string interactionBindingKey = "Interaction";
        const string cameraRailBindingKey = "Camera Rail";

        #endregion 

        public static UIManager instance;

        InputActionRebindingExtensions.RebindingOperation rebindingOperation;
        UIState uiState = UIState.Mainmenu;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);

            DontDestroyOnLoad(this);

            mainMenuBeginTween.BeginTween();
        }

        public void QuitApplication()
        {
            Application.Quit();
        }

        public void ChangeState(string state)
        {
            Debug.Log(state);
            switch (state)
            {
                case "Main Menu":
                    uiState = UIState.Mainmenu;
                    break;

                case "Player Settings":
                    uiState = UIState.PlayerSettings;
                    break;

                case "Bubble Settings":
                    uiState = UIState.BubbleSettings;
                    break;

                case "Asset Menu":
                    uiState = UIState.AssetMenu;
                    break;

                case "Asset Settings":
                    uiState = UIState.AssetSettings;
                    break;

                case "Quit":
                    uiState = UIState.Quit;
                    break;

            }
        }

        public void MainMenuChange()
        {
            Debug.Log(uiState);
            switch (uiState)
            {
                case UIState.PlayerSettings:
                    playerSettingsTween.BeginTween();
                    break;
                case UIState.BubbleSettings:
                    bubbleSettingsTween.BeginTween();
                    break;
                case UIState.Quit:
                    quitPromptTween.BeginTween();
                    break;
            }
        }

        public void OpenCloseMainMenu(bool Open)
        {
            if (Open)
                mainMenuBeginTween.BeginTween();
            else
            {
                uiState = UIState.Mainmenu;
                mainMenuReturnTween.ReturnTween();
            }

        }

        public void OpenCloseAssetMenu(bool Open)
        {
            if (Open)
                assetMenuTween.BeginTween();
            else
                assetMenuTween.ReturnTween();
        }

        public void OpenCloseAssetSettingsMenu(bool Open)
        {
            if (Open)
                assetSettingsTween.BeginTween();
            else
                assetSettingsTween.ReturnTween();
        }

        public void StartRebinding(string actionToRebind)
        {
            waitingForBindTxt.SetActive(true);
            switch (actionToRebind)
            {
                case mainMenuBindingKey:
                    Rebinding(mainMenu, mainMenuBindingTxt);
                    break;
                case assetMenuBindingKey:
                    Rebinding(assetMenu, assetMenuBindingTxt);
                    break;
                case runBindingKey:
                    Rebinding(run, runBindingTxt);
                    break;
                case quickExitBindingKey:
                    Rebinding(quickExit, quickExitBindingTxt);
                    break;
                case terraformingBindingKey:
                    Rebinding(terraforming, terraformingBindingTxt);
                    break;
                case interactionBindingKey:
                    Rebinding(interaction, interactionBindingTxt);
                    break;
                case cameraRailBindingKey:
                    Rebinding(cameraRail, cameraRailBindingTxt);
                    break;
            }
        }

        void Rebinding(InputActionReference actionToRebind, TextMeshProUGUI actionRebindingTxt)
        {
            rebindingOperation = actionToRebind.action.PerformInteractiveRebinding()
                .WithControlsExcluding("Mouse")
                .OnMatchWaitForAnother(0.1f)
                .OnComplete(operation => EndRebinding(actionToRebind, actionRebindingTxt))
                .Start();
        }

        void EndRebinding(InputActionReference actionToRebind, TextMeshProUGUI actionRebindingTxt)
        {
            waitingForBindTxt.SetActive(false);
            rebindingOperation.Dispose();

            actionRebindingTxt.text = InputControlPath.ToHumanReadableString(actionToRebind.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        }
    }

    public enum UIState
    {
        Mainmenu,
        PlayerSettings,
        BubbleSettings,
        AssetMenu,
        AssetSettings,
        Quit,
    }
}