using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSGameDev.Object
{
    [CreateAssetMenu(fileName = "New Object", menuName = "Assets/New Object")]
    public class ObjectSO : ScriptableObject
    {
        //Object ID for databasing
        public string ID;

        //Object componant data for manipulation, saving and loading
        public ObjectData objectData;

        //Require elemts for UI and AssetMenu spawning
        public Sprite objectSprite;
        public string objectName;
    }
}
