using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TSGameDev.Interactables;
using TSGameDev.Managers;

namespace TSGameDev.Object
{
    public class SceneDatabase : MonoBehaviour
    {
        [Header("Object Data References")]
        [SerializeField] ObjectDatabaseSO objectDatabase;
        [SerializeField] GameObject assetIconPrefab;
        [Space(10)]

        [Header("UI Asset Menu Sections")]
        [SerializeField] GameObject assetMenuSoundSection;
        [SerializeField] GameObject assetMenuModelSection;
        [SerializeField] GameObject assetMenuEffectSection;

        private Player player;
        [SerializeField] GameManager gameManager;

        /// <summary>
        /// Function to popular the asset menu with all items stored in the respective databases
        /// </summary>
        public void PopulateAssetMenu()
        {
            player = FindObjectOfType<Player>();
            if (player == null) return;


            foreach (ObjectSO sound in objectDatabase.soundDatabase)
            {
                GameObject asset = Instantiate(assetIconPrefab, assetMenuSoundSection.transform);
                asset.GetComponentInChildren<Image>().sprite = sound.objectSprite;
                asset.GetComponentInChildren<TextMeshProUGUI>().text = sound.objectName;
                asset.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if(sound.model != null)
                        SpawnItemWithModel(sound);

                });
            }

            foreach(ObjectSO model in objectDatabase.modelDatabase)
            {
                GameObject asset = Instantiate(assetIconPrefab, assetMenuModelSection.transform);
                asset.GetComponentInChildren<Image>().sprite = model.objectSprite;
                asset.GetComponentInChildren<TextMeshProUGUI>().text = model.objectName;
                asset.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (model.model != null)
                        SpawnItemWithModel(model);

                });
            }

            foreach(ObjectSO effect in objectDatabase.effectDatabase)
            {
                GameObject asset = Instantiate(assetIconPrefab, assetMenuEffectSection.transform);
                asset.GetComponentInChildren<Image>().sprite = effect.objectSprite;
                asset.GetComponentInChildren<TextMeshProUGUI>().text = effect.objectName;
                asset.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (effect.model != null)
                        SpawnItemWithModel(effect);
                    else
                        SpawnItemWithoutModel(effect);

                });
            }
        }

        public void SpawnSavedWorldObjects(List<ObjectData> savedWorldObjects)
        {
            foreach (ObjectData objectdata in savedWorldObjects)
            {
                string currentObjectID = objectdata.ID;
                ObjectType currentObjectType = objectdata.objectType;
                ObjectSO currentItem;
                
                switch (currentObjectType)
                {
                    case ObjectType.Sound:
                        currentItem = objectDatabase.FindSoundByID(currentObjectID);
                        SpawnItemWithModeFromSave(currentItem, objectdata);
                        break;
                    case ObjectType.Model:
                        currentItem = objectDatabase.FindModelByID(currentObjectID);
                        SpawnItemWithModeFromSave(currentItem, objectdata);
                        break;
                    case ObjectType.Effect:
                        currentItem = objectDatabase.FindEffectByID(currentObjectID);
                        
                        if (currentItem.model != null)
                            SpawnItemWithModeFromSave(currentItem, objectdata);
                        else
                            SpawnItemWithoutModelFromSave(currentItem, objectdata);
                        
                        break;
                }
            }
        }

        private void SpawnItemWithModel(ObjectSO Item)
        {
            GameObject newAsset = null;
            newAsset = Instantiate(Item.model[0], player.GetObjectSpawnPosition(Item.spawnDisFromPlayer), Quaternion.identity);
            newAsset.AddComponent<Object>().data = Item.objectData;
            Object obj = newAsset.GetComponent<Object>();
            obj.audioMixerGroup = Item.itemSoundsAudioGroup;
            obj.objectItem = Item;
            player.connectedObject = newAsset;
            gameManager.gameStateActions.ChangeToState(GameState.Application);
        }

        private void SpawnItemWithoutModel(ObjectSO Item)
        {
            GameObject newAsset = null;
            newAsset = new GameObject($"{Item.objectName}", typeof(Object));
            newAsset.transform.position = player.GetObjectSpawnPosition(Item.spawnDisFromPlayer);
            newAsset.GetComponent<Object>().data = Item.objectData;
            Object obj = newAsset.GetComponent<Object>();
            obj.audioMixerGroup = Item.itemSoundsAudioGroup;
            obj.objectItem = Item;
        }

        private void SpawnItemWithModeFromSave(ObjectSO Item, ObjectData objData)
        {
            GameObject newAsset = null;
            newAsset = Instantiate(Item.model[0], objData.objectPosition, objData.objectRotation);
            Debug.Log(objData.objectPosition);
            Object obj = newAsset.AddComponent<Object>();
            obj.data = objData;
            obj.audioMixerGroup = Item.itemSoundsAudioGroup;
            obj.objectItem = Item;
        }

        private void SpawnItemWithoutModelFromSave(ObjectSO Item,ObjectData objData)
        {
            GameObject newAsset = null;
            
            newAsset = new GameObject($"{Item.objectName}", typeof(Object));
            newAsset.transform.position = objData.objectPosition;
            newAsset.transform.rotation = objData.objectRotation;

            Object obj = newAsset.GetComponent<Object>();
            obj.data = objData;
            obj.audioMixerGroup = Item.itemSoundsAudioGroup;
            obj.objectItem = Item;
        }
    }
}
