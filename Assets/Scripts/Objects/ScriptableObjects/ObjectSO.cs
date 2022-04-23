using UnityEngine;
using UnityEngine.Audio;

namespace TSGameDev.Object
{
    [CreateAssetMenu(fileName = "New Object", menuName = "Assets/New Object")]
    public class ObjectSO : ScriptableObject
    {
        [Header("Saving Data")]
        //Object ID for databasing
        public string ID;
        [Space(10)]

        [Header("ObjectData")]
        //Object componant data for manipulation, saving and loading
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
