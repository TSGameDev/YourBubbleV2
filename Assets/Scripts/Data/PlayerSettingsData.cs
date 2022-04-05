namespace TSGameDev.Data
{
    //A struct of player settings for the purpose of saving, loading and manipulating the data easily.
    public struct PlayerSettingsData
    {
        public float masterVol;
        public float environmentVol;
        public float weatherVol;
        public float effectVol;

        public bool masterMuted;
        public bool environmentMuted;
        public bool weatherMuted;
        public bool effectMuted;

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
    }
}
