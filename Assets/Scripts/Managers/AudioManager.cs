using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace TSGameDev.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Call Settings")]
        [SerializeField] float volumeMin = 0.8f;
        [SerializeField] float volumeMax = 1f;
        [SerializeField] float pitchMin = 0.8f;
        [SerializeField] float pitchMax = 1f;
        [Space(10)]

        [Header("Audio Group Settings")]
        [SerializeField] AudioMixer audioMixer;
        [SerializeField] string masterAudioGroundRef;
        [SerializeField] string environmentAudioGroundRef;
        [SerializeField] string weatherAudioGroundRef;
        [SerializeField] string effectAudioGroundRef;
        [Space(10)]

        [Header("Audio Sliders")]
        [SerializeField] Slider masterAudioSlider;
        [SerializeField] Slider environmentAudioSlider;
        [SerializeField] Slider weatherAudioSlider;
        [SerializeField] Slider effectAudioSlider;

        public PlayerSettingsData playerSettingsData;

        public static AudioManager instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);

            DontDestroyOnLoad(this);

            playerSettingsData = new PlayerSettingsData();
        }

        public void PlayOneShot(AudioSource source, AudioClip clip)
        {
            source.PlayOneShot(clip);
        }

        public void PlayOneShotVariation(AudioSource source, AudioClip clip)
        {
            float volume = Random.Range(volumeMin, volumeMax);
            float pitch = Random.Range(pitchMin, pitchMax);

            source.pitch = pitch;
            source.volume = volume;

            source.PlayOneShot(clip);
        }

        public void PlayerOneShotRandom(AudioSource source, AudioClip[] clips, bool withVariation = false)
        {
            int ranNum = Random.Range(0, clips.Length);
            AudioClip clip = clips[ranNum];

            if(withVariation)
                PlayOneShotVariation(source, clip);
            else
                PlayOneShot(source, clip);
        }
    
        public void PlayerVolumeChange(string audioGroup)
        {
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

        public void PlayerMuteAudioGroup(string audioGroup)
        {
            float volumeValue;
            switch (audioGroup)
            {
                case "Master":
                    audioMixer.SetFloat(masterAudioGroundRef, 0f);
                    audioMixer.GetFloat(masterAudioGroundRef, out volumeValue);
                    masterAudioSlider.value = volumeValue;
                    break;
                case "Environment":
                    audioMixer.SetFloat(environmentAudioGroundRef, 0f);
                    audioMixer.GetFloat(environmentAudioGroundRef, out volumeValue);
                    environmentAudioSlider.value = volumeValue;
                    break;
                case "Weather":
                    audioMixer.SetFloat(weatherAudioGroundRef, 0f);
                    audioMixer.GetFloat(weatherAudioGroundRef, out volumeValue);
                    weatherAudioSlider.value = volumeValue;
                    break;
                case "Effect":
                    audioMixer.SetFloat(effectAudioGroundRef, 0f);
                    audioMixer.GetFloat(effectAudioGroundRef, out volumeValue);
                    effectAudioSlider.value = volumeValue;
                    break;
            }
        }
    }
}
