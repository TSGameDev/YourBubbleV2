using System;
using UnityEngine;

namespace TSGameDev.Object
{
    //Struct that contains the data for each object a player can place.
    [Serializable]
    public struct ObjectData
    {
        #region Save Variables
        
        [Header("Save Data")]
        public string ID;
        public Vector3 objectPosition;
        public Quaternion objectRotation;
        public ObjectType objectType;
        public int currentActiveModel;
        [Space(10)]
        
        #endregion

        #region Sound Variables
        //series of sound data variables
        [Header("Sound Data")]
        public AudioType audioType;
        public float volume;
        public float minDistance;
        public float maxDistance;
        [Space(10)]

        #endregion

        #region Effect Variables
        //series of effect data variables
        [Header("Effect Data")]
        public Color colour;

        #endregion

        /// <summary>
        /// Constructor for ObjectData
        /// </summary>
        /// <param name="soundClip">The Sound for sound base items</param>
        /// <param name="indoorVariants">A sound clip as an indoor version of the primary sound</param>
        /// <param name="effect">The Effect for effect base items</param>
        public ObjectData(Color colour, AudioType audioType = AudioType.Mode2D, float volume = 1f, float minDistance = 1f, float maxDistance = 10f)
        {
            ID = "Input Object ID";
            objectPosition = new Vector3();
            objectRotation = new Quaternion();
            objectType = ObjectType.Sound;
            currentActiveModel = 0;

            this.audioType = audioType;
            this.volume = volume;
            this.minDistance = minDistance;
            this.maxDistance = maxDistance;
            if (colour == null) this.colour = Color.white;
            else this.colour = colour;
        }

    }
}
