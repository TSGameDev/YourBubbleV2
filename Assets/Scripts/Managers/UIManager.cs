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

        #region Action References



        #endregion

        public static UIManager instance;
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
            if(Open)
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