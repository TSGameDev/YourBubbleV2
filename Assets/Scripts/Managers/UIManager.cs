using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.UI;

namespace TSGameDev.Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Private Variables

        [Header("Tween Objects")]
        [Space(10)]
        [SerializeField] UITween mainMenuBeginTween;
        [SerializeField] UITween mainMenuReturnTween;
        [SerializeField] UITween playerSettingsTween;
        [SerializeField] UITween quitPromptTween;
        [SerializeField] UITween bubbleSettingsTween;
        [SerializeField] UITween assetMenuTween;
        [SerializeField] UITween assetSettingsTween;

        UIState uiState = UIState.Mainmenu;
        #endregion

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

        public void OpenMainMenu()
        {
            mainMenuBeginTween.BeginTween();
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