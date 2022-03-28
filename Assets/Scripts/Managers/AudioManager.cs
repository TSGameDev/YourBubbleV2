using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSGameDev.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] float volumeMin = 0.8f;
        [SerializeField] float volumeMax = 1f;
        [SerializeField] float pitchMin = 0.8f;
        [SerializeField] float pitchMax = 1f;

        public static AudioManager instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);

            DontDestroyOnLoad(this);
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
    }
}
