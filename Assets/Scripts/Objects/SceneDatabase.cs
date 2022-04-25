using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TSGameDev.Interactables;

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
                    Debug.Log("On Click Event Called");
                    GameObject newAsset = null;

                    if(sound.model != null)
                    {
                        newAsset = Instantiate(sound.model[0], player.GetObjectSpawnPosition(sound.spawnDisFromPlayer), Quaternion.identity);
                        newAsset.AddComponent<Object>().data = sound.objectData;
                        Object obj = newAsset.GetComponent<Object>();
                        obj.audioMixerGroup = sound.itemSoundsAudioGroup;
                        obj.objectItem = sound;
                    }
                    else
                    {
                        newAsset = new GameObject($"{sound.objectName}", typeof(Object));
                        newAsset.transform.position = player.GetObjectSpawnPosition(sound.spawnDisFromPlayer);
                        newAsset.GetComponent<Object>().data = sound.objectData;
                        Object obj = newAsset.GetComponent<Object>();
                        obj.audioMixerGroup = sound.itemSoundsAudioGroup;
                        obj.objectItem = sound;
                    }

                });
            }

            foreach(ObjectSO model in objectDatabase.modelDatabase)
            {
                GameObject asset = Instantiate(assetIconPrefab, assetMenuModelSection.transform);
                asset.GetComponentInChildren<Image>().sprite = model.objectSprite;
                asset.GetComponentInChildren<TextMeshProUGUI>().text = model.objectName;
                asset.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Debug.Log("On Click Event Called");
                    GameObject newAsset = null;

                    if (model.model != null)
                    {
                        newAsset = Instantiate(model.model[0], player.GetObjectSpawnPosition(model.spawnDisFromPlayer), Quaternion.identity);
                        newAsset.AddComponent<Object>().data = model.objectData;
                        Object obj = newAsset.GetComponent<Object>();
                        obj.audioMixerGroup = model.itemSoundsAudioGroup;
                        obj.objectItem = model;
                    }
                    else
                    {
                        newAsset = new GameObject($"{model.objectName}", typeof(Object));
                        newAsset.transform.position = player.GetObjectSpawnPosition(model.spawnDisFromPlayer);
                        newAsset.GetComponent<Object>().data = model.objectData;
                        Object obj = newAsset.GetComponent<Object>();
                        obj.audioMixerGroup = model.itemSoundsAudioGroup;
                        obj.objectItem = model;
                    }

                });
            }

            foreach(ObjectSO effect in objectDatabase.effectDatabase)
            {
                GameObject asset = Instantiate(assetIconPrefab, assetMenuEffectSection.transform);
                asset.GetComponentInChildren<Image>().sprite = effect.objectSprite;
                asset.GetComponentInChildren<TextMeshProUGUI>().text = effect.objectName;
                asset.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Debug.Log("On Click Event Called");
                    GameObject newAsset = null;

                    if (effect.model != null)
                    {
                        newAsset = Instantiate(effect.model[0], player.GetObjectSpawnPosition(effect.spawnDisFromPlayer), Quaternion.identity);
                        newAsset.AddComponent<Object>().data = effect.objectData;
                        Object obj = newAsset.GetComponent<Object>();
                        obj.audioMixerGroup = effect.itemSoundsAudioGroup;
                        obj.objectItem = effect;
                    }
                    else
                    {
                        newAsset = new GameObject($"{effect.objectName}", typeof(Object));
                        newAsset.transform.position = player.GetObjectSpawnPosition(effect.spawnDisFromPlayer);
                        newAsset.GetComponent<Object>().data = effect.objectData;
                        Object obj = newAsset.GetComponent<Object>();
                        obj.audioMixerGroup = effect.itemSoundsAudioGroup;
                        obj.objectItem = effect;
                    }

                });
            }
        }
    }
}
