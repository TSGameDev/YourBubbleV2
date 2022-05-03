using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TSGameDev.Object
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Assets/New Object")]
    public class ObjectSO : ScriptableObject
    {
        [Header("ObjectData")]
        //Object componant data for manipulation, saving and loading
        public float spawnDisFromPlayer; 
        [Space(5)]
        public AudioClip soundClip;
        public AudioClip indoorVariant;
        //series of model data variables
        public List<GameObject> model;
        [Space(5)]
        public ParticleSystem effect;
        [Space(5)]
        public ObjectData objectData;
        [Space(10)]

        
        [Header("UI Element Data")]
        //Require elemts for UI and AssetMenu spawning
        public Sprite objectSprite;
        public string objectName;
        [Space(10)]

        [Header("Audio Elements")]
        //Require element to make the player setting effect the volume of sounds spawned into the world
        public AudioMixerGroup itemSoundsAudioGroup;
    }
}
