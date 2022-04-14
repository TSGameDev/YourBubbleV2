using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSGameDev.Object
{
    [CreateAssetMenu(fileName = "New Object Database", menuName = "Assets/New Object Database")]
    public class ObjectDatabaseSO : ScriptableObject
    {
        public List<ObjectSO> soundDatabase;
        public List<ObjectSO> modelDatabase;
        public List<ObjectSO> effectDatabase;
    }
}
