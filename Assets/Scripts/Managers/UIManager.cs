using TMPro;
using TSGameDev.Object;
using UnityEngine;
using UnityEngine.UI;

namespace TSGameDev.Managers
{
    //A singleton instance manager for all UI related tasks and calls throughout the project
    public class UIManager : MonoBehaviour
    {
        #region Asset Settings Menu Variables

        [Header("Sound Section Variables")]
        [SerializeField] TextMeshProUGUI soundTypeTxt;
        [SerializeField] Button soundTypeButtonLeft;
        [SerializeField] Button soundTypeButtonRight;

        [SerializeField] TextMeshProUGUI soundVolumeTxt;
        [SerializeField] Button soundVolumeRight;
        [SerializeField] Button soundVolumeLeft;

        [SerializeField] TextMeshProUGUI soundMinDisTxt;
        [SerializeField] Button soundMinDisButtonLeft;
        [SerializeField] Button soundMinDisButtonRight;

        [SerializeField] TextMeshProUGUI soundMaxDisTxt;
        [SerializeField] Button soundMaxDisButtonRight;
        [SerializeField] Button soundMaxDisButtonLeft;

        [SerializeField] TextMeshProUGUI soundIndoorTxt;
        [SerializeField] Button soundIndoorButtonRight;
        [SerializeField] Button soundIndoorButtonLeft;
        [Space(10)]

        #endregion

        #region OnClick Button References

        [Header("OnClickButton References")]
        [SerializeField] Button assetMenuCloseButton;
        [Space(10)]

        #endregion

        //The global cached UIState
        public UIState uiState = UIState.Mainmenu;
        private GameManager gameManager;

        //The singleton instance fo this script
        public static UIManager instance;

        private void Awake()
        {
            //singleton setup
            if (instance == null)
                instance = this;
            else
                Destroy(this);

            //singleton persist through scene loads
            DontDestroyOnLoad(this);

            gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            //Assigns some button onclick events that are not possible in inspector
            AssignButtonOnClickEvents();
        }

        /// <summary>
        /// Closes the application down.
        /// </summary>
        public void QuitApplication()
        {
            Application.Quit();
        }

        /// <summary>
        /// Updates the asset menu settings to the passed in objects data
        /// </summary>
        /// <param name="objectdata">The interacted with objects data to become the values for the asset settings menu</param>
        /// <param name="audioSource">The audio source attached to the object so OnClick methods will take effect on correct audio source</param>
        public void UpdateAssetMenuSettings(ObjectSO objectItem, ObjectData objectdata, AudioSource audioSource = null)
        {
            RemoveAllAssetSettingsListeners();
            Debug.Log("Removed Listeners");

            if (audioSource != null)
            {
                AssetSettingsUpdateSoundType(objectdata, audioSource);
                AssetSettingsUpdateSoundVolume(objectdata, audioSource);
                AssetSettingsUpdateSoundIndoorVariant(objectItem);
                AssetSettingsUpdateSoundMinDistance(objectdata, audioSource);
                AssetSettingsUpdateSoundMaxDistance(objectdata, audioSource);
            }
        }

        /// <summary>
        /// Removes all previous listeners to the asset settings buttons
        /// </summary>
        void RemoveAllAssetSettingsListeners()
        {
            soundTypeButtonLeft.onClick.RemoveAllListeners();
            soundTypeButtonRight.onClick.RemoveAllListeners();
            soundVolumeLeft.onClick.RemoveAllListeners();
            soundVolumeRight.onClick.RemoveAllListeners();
            soundIndoorButtonLeft.onClick.RemoveAllListeners();
            soundIndoorButtonRight.onClick.RemoveAllListeners();
        }
    
        /// <summary>
        /// Updates the sound type field of the asset settings
        /// </summary>
        /// <param name="objectdata">The object data of the interacted with object</param>
        /// <param name="audioSource">The audio souce of the interacted with object</param>
        void AssetSettingsUpdateSoundType(ObjectData objectdata, AudioSource audioSource)
        {
            soundTypeTxt.text = objectdata.audioType.ToString();
            soundTypeButtonLeft.onClick.AddListener(() =>
            {
                objectdata.audioType--;
                audioSource.spatialBlend--;
                soundTypeTxt.text = objectdata.audioType.ToString();
            });
            soundTypeButtonRight.onClick.AddListener(() =>
            {
                objectdata.audioType++;
                audioSource.spatialBlend++;
                soundTypeTxt.text = objectdata.audioType.ToString();
            });
        }

        /// <summary>
        /// Updates the sound volume field of the asset settings
        /// </summary>
        /// <param name="objectdata">The object data of the interacted with object</param>
        /// <param name="audioSource">The audio source of the interacted with object</param>
        void AssetSettingsUpdateSoundVolume(ObjectData objectdata, AudioSource audioSource)
        {
            soundVolumeTxt.text = objectdata.volume.ToString();
            soundVolumeLeft.onClick.AddListener(() =>
            {
                objectdata.volume -= 0.1f;
                audioSource.volume -= 0.1f;
                soundVolumeTxt.text = objectdata.volume.ToString();
            });
            soundVolumeRight.onClick.AddListener(() =>
            {
                objectdata.volume += 0.1f;
                audioSource.volume += 0.1f;
                soundVolumeTxt.text = objectdata.volume.ToString();
            });
        }
        
        /// <summary>
        /// Updates the sound indoor variant field of the asset settings
        /// </summary>
        /// <param name="objectdata">The object data of the interacted with object</param>
        void AssetSettingsUpdateSoundIndoorVariant(ObjectSO objectItem)
        {
            soundIndoorTxt.text = objectItem.indoorVariant.ToString();
        }
        
        /// <summary>
        /// Updates the sound min distance field of the asset settings
        /// </summary>
        /// <param name="objectdata">Object data of the object interacted with</param>
        /// <param name="audioSource">Audio source of the object interacted with</param>
        void AssetSettingsUpdateSoundMinDistance(ObjectData objectdata, AudioSource audioSource)
        {
            soundMinDisTxt.text = objectdata.minDistance.ToString();
            soundMinDisButtonLeft.onClick.AddListener(() =>
            {
                objectdata.minDistance--;
                audioSource.minDistance--;
                soundMinDisTxt.text = objectdata.minDistance.ToString();
            });
            soundMinDisButtonRight.onClick.AddListener(() =>
            {
                objectdata.minDistance++;
                audioSource.minDistance++;
                soundMinDisTxt.text = objectdata.minDistance.ToString();
            });
        }

        /// <summary>
        /// Updates the sound max distance field of the asset settings
        /// </summary>
        /// <param name="objectdata">Obejct data of the object interacted with</param>
        /// <param name="audioSource">Audio source of the object interacted with</param>
        void AssetSettingsUpdateSoundMaxDistance(ObjectData objectdata, AudioSource audioSource)
        {
            soundMaxDisTxt.text = objectdata.minDistance.ToString();
            soundMaxDisButtonLeft.onClick.AddListener(() =>
            {
                objectdata.maxDistance--;
                audioSource.maxDistance--;
                soundMaxDisTxt.text = objectdata.maxDistance.ToString();
            });
            soundMaxDisButtonRight.onClick.AddListener(() =>
            {
                objectdata.maxDistance++;
                audioSource.maxDistance++;
                soundMaxDisTxt.text = objectdata.maxDistance.ToString();
            });
        }
    
        /// <summary>
        /// A function used on the start up of the UI manager used to assign buttons on click events that are not possible within the inspector
        /// </summary>
        void AssignButtonOnClickEvents()
        {
            assetMenuCloseButton.onClick.AddListener(() =>
            {
                gameManager.gameStateActions.ChangeToState(GameState.Application);
            });
        }
    }
}