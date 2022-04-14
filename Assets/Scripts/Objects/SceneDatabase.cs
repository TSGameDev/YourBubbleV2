using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        [System.Obsolete]
        private void Start()
        {
            foreach (ObjectSO sound in objectDatabase.soundDatabase)
            {
                GameObject asset = Instantiate(assetIconPrefab, assetMenuSoundSection.transform);
                asset.GetComponentInChildren<Image>().sprite = sound.objectSprite;
                asset.GetComponentInChildren<TextMeshProUGUI>().text = sound.objectName;
                asset.GetComponent<Button>().onClick.AddListener(() =>
                {
                    GameObject newAsset = null;

                    if(sound.objectData.model != null)
                    {
                        newAsset = Instantiate(sound.objectData.model, new Vector3(0, 0, 0), Quaternion.identity);
                        newAsset.AddComponent<Object>().data = sound.objectData;
                    }
                    else
                    {
                        newAsset = new GameObject($"{sound.objectName}", typeof(Object));
                        newAsset.GetComponent<Object>().data = sound.objectData;
                    }

                });
            }
        }
    }
}
