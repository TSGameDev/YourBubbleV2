using UnityEngine.InputSystem;

namespace TSGameDev.Data
{
    //A struct of player settings for the purpose of saving, loading and manipulating the data easily.
    public struct PlayerSettingsData
    {
        #region Volume Floats

        public float masterVol;
        public float environmentVol;
        public float weatherVol;
        public float effectVol;

        #endregion

        #region Volume Mute Bools

        public bool masterMuted;
        public bool environmentMuted;
        public bool weatherMuted;
        public bool effectMuted;

        #endregion

        #region Control Binding Paths

        public string mainMenuBindingPath;
        public string assetMenuBindingPath;
        public string runBindingPath;
        public string quickExitBindingPath;
        public string interactionBindingPath;

        #endregion

        /// <summary>
        /// record which audio mixer group is muted to save and load correct player volume settings
        /// </summary>
        /// <param name="audioGroup">the audio mixer group to mute/unmute</param>
        /// <param name="toggleValue">the bool value to change to. True means muted, False means unmuted</param>
        public void SetMuted(string audioGroup, bool toggleValue)
        {
            switch (audioGroup)
            {
                case "Master":
                    masterMuted = toggleValue;
                    break;
                case "Environment":
                    environmentMuted = toggleValue;
                    break;
                case "Weather":
                    weatherMuted = toggleValue;
                    break;
                case "Effect":
                    effectMuted = toggleValue;
                    break;
            }
        }

        /// <summary>
        /// Constructor to create a new playersettingsdata
        /// </summary>
        /// <param name="mainMenu">Main Menu Action Reference</param>
        /// <param name="assetMenu">Asset Menu Action Reference</param>
        /// <param name="run">Run Action Reference</param>
        /// <param name="quickExit">Quick Exit Action Reference</param>
        /// <param name="interaction">Interaction Action Reference</param>
        public PlayerSettingsData(InputActionReference mainMenu, InputActionReference assetMenu, InputActionReference run, InputActionReference quickExit, InputActionReference interaction)
        {
            masterVol = 1f;
            environmentVol = 1f;
            weatherVol = 1f;
            effectVol = 1f;

            masterMuted = false;
            environmentMuted = false;
            weatherMuted = false;
            effectMuted = false;

            mainMenuBindingPath = mainMenu.action.bindings[0].path;
            assetMenuBindingPath = assetMenu.action.bindings[0].path;
            runBindingPath = run.action.bindings[0].path;
            quickExitBindingPath = quickExit.action.bindings[0].path;
            interactionBindingPath = interaction.action.bindings[0].path;
        }
    }
}
