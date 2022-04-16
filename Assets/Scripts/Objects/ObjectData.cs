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
        #region General Settings

        [Header("User benefit settings")]
        public float spawnDisFromPlayer;
        [Space(10)]

        #endregion

        #region Sound
        //series of sound data variables
        [Header("Sound Data")]
        public AudioClip soundClip;
        public AudioType audioType;
        public float volume;
        public float minDistance;
        public float maxDistance;
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
        public ObjectData(AudioClip soundClip, List<AudioClip> indoorVariants, ParticleSystem effect, List<ParticleSystem> effectVariants)
        {
            spawnDisFromPlayer = 5f;

            this.soundClip = soundClip;
            audioType = AudioType.Mode2D;
            volume = 1f;
            minDistance = 1f;
            maxDistance = 10f;
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
        Mode2D,
        Mode3D
    }

}
