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

                    if(sound.objectData.model != null)
                    {
                        newAsset = Instantiate(sound.objectData.model[0], player.GetObjectSpawnPosition(sound.objectData.spawnDisFromPlayer), Quaternion.identity);
                        newAsset.AddComponent<Object>().data = sound.objectData;
                    }
                    else
                    {
                        newAsset = new GameObject($"{sound.objectName}", typeof(Object));
                        newAsset.transform.position = player.GetObjectSpawnPosition(sound.objectData.spawnDisFromPlayer);
                        newAsset.GetComponent<Object>().data = sound.objectData;
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

                    if (model.objectData.model != null)
                    {
                        newAsset = Instantiate(model.objectData.model[0], player.GetObjectSpawnPosition(model.objectData.spawnDisFromPlayer), Quaternion.identity);
                        newAsset.AddComponent<Object>().data = model.objectData;
                    }
                    else
                    {
                        newAsset = new GameObject($"{model.objectName}", typeof(Object));
                        newAsset.transform.position = player.GetObjectSpawnPosition(model.objectData.spawnDisFromPlayer);
                        newAsset.GetComponent<Object>().data = model.objectData;
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

                    if (effect.objectData.model != null)
                    {
                        newAsset = Instantiate(effect.objectData.model[0], player.GetObjectSpawnPosition(effect.objectData.spawnDisFromPlayer), Quaternion.identity);
                        newAsset.AddComponent<Object>().data = effect.objectData;
                    }
                    else
                    {
                        newAsset = new GameObject($"{effect.objectName}", typeof(Object));
                        newAsset.transform.position = player.GetObjectSpawnPosition(effect.objectData.spawnDisFromPlayer);
                        newAsset.GetComponent<Object>().data = effect.objectData;
                    }

                });
            }
        }
    }
}
