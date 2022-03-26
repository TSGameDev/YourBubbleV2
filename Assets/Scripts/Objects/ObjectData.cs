using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSGameDev.Object
{
    [Serializable]
    public struct ObjectData
    {
        public int ID { private set; get; }

        #region Sound
        [Header("Sound Data")]
        public AudioClip soundClip;
        public AudioType audioType;
        public float relativeVolume;
        public float uniformRadius;
        public List<AudioClip> indoorVariants;
        [Space(10)]

        #endregion

        #region Model
        [Header("Model Data")]
        public bool changeWithEffects;
        [Space(10)]

        #endregion

        #region Effect

        [Header("Effect Data")]
        public ParticleSystem effect;
        public List<ParticleSystem> effectVariants;
        public float speed;
        public Color colour;

        #endregion

        public ObjectData(AudioClip soundClip, List<AudioClip> indoorVariants, ParticleSystem effect, List<ParticleSystem> effectVariants)
        {
            ID = 1;

            this.soundClip = soundClip;
            audioType = AudioType.Uniform;
            relativeVolume = 1f;
            uniformRadius = 10f;
            this.indoorVariants = indoorVariants;

            changeWithEffects = false;

            this.effect = effect;
            this.effectVariants = effectVariants;
            speed = 1f;
            colour = Color.white;
        }

        public void Serialisation()
        {

        }

        public void Deserialisation()
        {

        }
    }

    public enum AudioType
    {
        Uniform,
        Relative
    }

}
