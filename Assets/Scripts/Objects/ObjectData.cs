using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSGameDev.Object
{
    public struct ObjectData
    {
        public int ID { private set; get; }

        #region Sound

        public AudioClip soundClip;
        public AudioType audioType;
        public float relativeVolume;
        public float uniformRadius;
        public List<AudioClip> indoorVariants;

        #endregion

        #region Model

        public bool changeWithEffects;

        #endregion

        #region Effect

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

        public void Serilisation()
        {

        }

        public void Deserilisation()
        {

        }
    }

    public enum AudioType
    {
        Uniform,
        Relative
    }

}
