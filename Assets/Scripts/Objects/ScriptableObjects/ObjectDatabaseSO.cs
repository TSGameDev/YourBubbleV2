using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSGameDev.Object
{
    [CreateAssetMenu(fileName = "New Object Database", menuName = "Assets/New Object Database")]
    public class ObjectDatabaseSO : ScriptableObject
    {
        //list of all objects to be displayed within the sound section of the asset menu
        public List<ObjectSO> soundDatabase;
        //list of all objects to be displayed within the model section of the asset menu
        public List<ObjectSO> modelDatabase;
        //list of all objects to be displayed within the effect section of the asset menu
        public List<ObjectSO> effectDatabase;
    }
}
