using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSGameDev.Object
{
    //Struct that contains the data for each object a player can place. Also contains functions to serialsie and deserialise the struct for saving purposes
    [Serializable]
    public struct ObjectData
    {

        #region Sound
        //series of sound data variables
        [Header("Sound Data")]
        public AudioClip soundClip;
        public List<AudioClip> soundVariants;
        public AudioType audioType;
        public float relativeVolume;
        public float uniformRadius;
        public List<AudioClip> indoorVariants;
        [Space(10)]

        #endregion

        #region Model
        //series of model data variables
        [Header("Model Data")]
        public GameObject model;
        [Space(10)]

        #endregion

        #region Effect
        //series of effect data variables
        [Header("Effect Data")]
        public ParticleSystem effect;
        public List<ParticleSystem> effectVariants;
        public float speed;
        public Color colour;

        #endregion

        //contructor for the struct
        public ObjectData(AudioClip soundClip, List<AudioClip> soundVariants, List<AudioClip> indoorVariants, ParticleSystem effect, List<ParticleSystem> effectVariants)
        {

            this.soundClip = soundClip;
            this.soundVariants = soundVariants;
            audioType = AudioType.Uniform;
            relativeVolume = 1f;
            uniformRadius = 10f;
            this.indoorVariants = indoorVariants;

            model = null;

            this.effect = effect;
            this.effectVariants = effectVariants;
            speed = 1f;
            colour = Color.white;
        }

    }

    //enum contining auido style types to better tracking of audio style
    public enum AudioType
    {
        Uniform,
        Relative
    }

}
