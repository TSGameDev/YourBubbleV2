using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSGameDev.Object
{
    [CreateAssetMenu(fileName = "New Item Database", menuName = "Scriptable Objects/Assets/New Object Database")]
    public class ObjectDatabaseSO : ScriptableObject
    {
        //list of all objects to be displayed within the sound section of the asset menu
        public List<ObjectSO> soundDatabase;
        //list of all objects to be displayed within the model section of the asset menu
        public List<ObjectSO> modelDatabase;
        //list of all objects to be displayed within the effect section of the asset menu
        public List<ObjectSO> effectDatabase;

        public ObjectSO FindSoundByID(string ID)
        {
            foreach(ObjectSO obj in soundDatabase)
            {
                if (obj.objectData.ID == ID)
                    return obj;
            }
            return null;
        }

        public ObjectSO FindModelByID(string ID)
        {
            foreach (ObjectSO obj in modelDatabase)
            {
                if (obj.objectData.ID == ID)
                    return obj;
            }
            return null;
        }

        public ObjectSO FindEffectByID(string ID)
        {
            foreach (ObjectSO obj in effectDatabase)
            {
                if (obj.objectData.ID == ID)
                    return obj;
            }
            return null;
        }
    }
}
