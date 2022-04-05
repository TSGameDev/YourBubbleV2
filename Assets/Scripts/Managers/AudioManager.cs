using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TSGameDev.Data;

namespace TSGameDev.Managers
{
    //A singleton instance manager for all audio related calls and functionality within the program.
    public class AudioManager : MonoBehaviour
    {
        #region Audio Call Variables

        //Variables relating to playing audio clips
        [Header("Audio Call Settings")]
        [SerializeField] float volumeMin = 0.8f;
        [SerializeField] float volumeMax = 1f;
        [SerializeField] float pitchMin = 0.8f;
        [SerializeField] float pitchMax = 1f;
        [Space(10)]

        #endregion

        #region Audio Mix Group Variables

        //variables ralating to the maipulation of audio mixer groups volume
        [Header("Audio Group Settings")]
        [SerializeField] AudioMixer audioMixer;
        [SerializeField] string masterAudioGroundRef;
        [SerializeField] string environmentAudioGroundRef;
        [SerializeField] string weatherAudioGroundRef;
        [SerializeField] string effectAudioGroundRef;
        [Space(10)]

        //references to the player setting volume sliders for audio mixer groups volume controls
        [Header("Audio Sliders")]
        [SerializeField] Slider masterAudioSlider;
        [SerializeField] Slider environmentAudioSlider;
        [SerializeField] Slider weatherAudioSlider;
        [SerializeField] Slider effectAudioSlider;

        //reference to player data to set and record the different settings for easily manipulation and saving.
        public PlayerSettingsData playerSettingsData;

        #endregion

        // Singleton instance of this call
        public static AudioManager instance;

        private void Awake()
        {
            //singlton setup
            if (instance == null)
                instance = this;
            else
                Destroy(this);

            //makes singleton instance persist through scene changes
            DontDestroyOnLoad(this);

            playerSettingsData = new PlayerSettingsData();
        }

        /// <summary>
        /// Play a passed in AudioClip from the passed in AudioSource a single time.
        /// </summary>
        /// <param name="source">The source you wish to play the clip from.</param>
        /// <param name="clip">The clip you wish to be played.</param>
        public void PlayOneShot(AudioSource source, AudioClip clip)
        {
            source.PlayOneShot(clip);
        }

        /// <summary>
        /// Play a pass in AudioClip from the passed in AudioSource a single time with pitch and volume variation.
        /// </summary>
        /// <param name="source">The source you wish to play the clip from.</param>
        /// <param name="clip">The clip you wish to be played</param>
        public void PlayOneShotVariation(AudioSource source, AudioClip clip)
        {
            //Randomise Volume and Pitch between min and max variables
            float volume = Random.Range(volumeMin, volumeMax);
            float pitch = Random.Range(pitchMin, pitchMax);

            //set the new randomised pitch and volume in the source
            source.pitch = pitch;
            source.volume = volume;

            //play the clip a single time.
            source.PlayOneShot(clip);
        }

        /// <summary>
        /// Play a random clip from the array of passed in AudioClips from the passed in AudioSource, adding on variation is required.
        /// </summary>
        /// <param name="source">The source you wish the clip to play from.</param>
        /// <param name="clips">The array of clips to chose from.</param>
        /// <param name="withVariation">If you would like Pitch and Volume variation from the selected clip. True means yes and will add variation, false means no and the clip will be played with the sources Volume and Pitch settings</param>
        public void PlayerOneShotRandom(AudioSource source, AudioClip[] clips, bool withVariation = false)
        {
            //Gets a random clips from array of clips
            int ranNum = Random.Range(0, clips.Length);
            AudioClip clip = clips[ranNum];

            //plays the selected clips with or without variation using above functions depending on bool value
            if(withVariation)
                PlayOneShotVariation(source, clip);
            else
                PlayOneShot(source, clip);
        }
        
        /// <summary>
        /// Changes the volume of passed in Audio Mixer Group to match the value of the corrisponding slider and update the Player Settings Data value for the same Audio Mixer Group.
        /// </summary>
        /// <param name="audioGroup">The name of the Audio Mixer Group you wish to update.</param>
        public void PlayerVolumeChange(string audioGroup)
        {
            //if the passed in audioGroup matches any of the cases, the corisponding volume and player settings data is updated to match the slider for the audio mixer group
            switch (audioGroup)
            {
                case "Master":
                    audioMixer.SetFloat(masterAudioGroundRef, masterAudioSlider.value);
                    playerSettingsData.masterVol = masterAudioSlider.value;
                    break;
                case "Environment":
                    audioMixer.SetFloat(environmentAudioGroundRef, environmentAudioSlider.value);
                    playerSettingsData.environmentVol = environmentAudioSlider.value;
                    break;
                case "Weather":
                    audioMixer.SetFloat(weatherAudioGroundRef, weatherAudioSlider.value);
                    playerSettingsData.weatherVol = weatherAudioSlider.value;
                    break;
                case "Effect":
                    audioMixer.SetFloat(effectAudioGroundRef, effectAudioSlider.value);
                    playerSettingsData.effectVol = effectAudioSlider.value;
                    break;
            }
        }

        /// <summary>
        /// Mutes the passed in Audio Mixer Group and updates the slider and player settings data to match.
        /// </summary>
        /// <param name="audioGroup">The name of the Audio Mixer Group you wish to mute</param>
        public void PlayerMuteAudioGroup(string audioGroup)
        {
            float volumeValue;
            //if the passed in name matches any of the cases, mutes the corisponding Audio Mixer Group by setting volume to -80db and updates the slider and player settings data
            switch (audioGroup)
            {
                case "Master":
                    audioMixer.SetFloat(masterAudioGroundRef, -80f);
                    audioMixer.GetFloat(masterAudioGroundRef, out volumeValue);
                    masterAudioSlider.value = volumeValue;
                    break;
                case "Environment":
                    audioMixer.SetFloat(environmentAudioGroundRef, -80f);
                    audioMixer.GetFloat(environmentAudioGroundRef, out volumeValue);
                    environmentAudioSlider.value = volumeValue;
                    break;
                case "Weather":
                    audioMixer.SetFloat(weatherAudioGroundRef, -80f);
                    audioMixer.GetFloat(weatherAudioGroundRef, out volumeValue);
                    weatherAudioSlider.value = volumeValue;
                    break;
                case "Effect":
                    audioMixer.SetFloat(effectAudioGroundRef, -80f);
                    audioMixer.GetFloat(effectAudioGroundRef, out volumeValue);
                    effectAudioSlider.value = volumeValue;
                    break;
            }
        }
    }
}
