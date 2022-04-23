using TMPro;
using TSGameDev.Object;
using TSGameDev.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TSGameDev.Managers
{
    //A singleton instance manager for all UI related tasks and calls throughout the project
    public class UIManager : MonoBehaviour
    {
        #region Tween Objects

        //References to all the different UI tween scripts to impliment slightly more complex tweening E.G. the main menu transitions to multiple different menus
        [Header("Tween Objects")]
        [SerializeField] UITween mainMenuBeginTween;
        [SerializeField] UITween mainMenuReturnTween;
        [SerializeField] UITween playerSettingsTween;
        [SerializeField] UITween quitPromptTween;
        [SerializeField] UITween bubbleSettingsTween;
        [SerializeField] UITween assetMenuTween;
        [SerializeField] UITween assetSettingsTween;
        [Space(10)]

        #endregion

        #region Rebinding Variables

        #region Input Action References

        //Reference to all the Input Actions for the purpose of rebinding controls
        [Header("Input Action References")]
        [SerializeField] InputActionReference mainMenu;
        [SerializeField] InputActionReference assetMenu;
        [SerializeField] InputActionReference run;
        [SerializeField] InputActionReference quickExit;
        [SerializeField] InputActionReference terraforming;
        [SerializeField] InputActionReference interaction;
        [SerializeField] InputActionReference cameraRail;
        [Space(10)]

        #endregion

        #region Input Action Binding Texts

        //Reference to the Text elements of each UI control binding to update when the control has been changed.
        [Header("Input Action Binding Texts")]
        [SerializeField] TextMeshProUGUI mainMenuBindingTxt;
        [SerializeField] TextMeshProUGUI assetMenuBindingTxt;
        [SerializeField] TextMeshProUGUI runBindingTxt;
        [SerializeField] TextMeshProUGUI quickExitBindingTxt;
        [SerializeField] TextMeshProUGUI terraformingBindingTxt;
        [SerializeField] TextMeshProUGUI interactionBindingTxt;
        [SerializeField] TextMeshProUGUI cameraRailBindingTxt;
        [Space(5)]

        //Reference to a text elements gameobject for the purpose of displaying "Waiting for Binding" when the rebinding process as begin and then player needs to input a control
        [SerializeField] GameObject waitingForBindTxt;
        [SerializeField] TextMeshProUGUI interactionTxt;
        public TextMeshProUGUI InteractionTxt
        {
            private set { interactionTxt = value; }
            get { return interactionTxt; }
        }

        #endregion

        #region Input Action String Constants

        //Constant string references to the bindings so there is no worry of accidently misspelling a string reference.
        const string mainMenuBindingKey = "Main Menu";
        const string assetMenuBindingKey = "Asset Menu";
        const string runBindingKey = "Run";
        const string quickExitBindingKey = "Quick Exit";
        const string terraformingBindingKey = "Terraforming";
        const string interactionBindingKey = "Interaction";
        const string cameraRailBindingKey = "Camera Rail";

        #endregion

        //A cache of the rebinding controler operation to discard the memory used to prevent memory leakage
        InputActionRebindingExtensions.RebindingOperation rebindingOperation;

        #endregion

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
            //Tweens the main menu in to begin the application
            OpenCloseMainMenu(true);
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
        /// Changes the UI State to the passed in state name.
        /// </summary>
        /// <param name="state"></param>
        public void ChangeUIState(string state)
        {
            switch (state)
            {
                case "Main Menu":
                    uiState = UIState.Mainmenu;
                    break;

                case "Player Settings":
                    uiState = UIState.PlayerSettings;
                    break;

                case "Bubble Settings":
                    uiState = UIState.BubbleSettings;
                    break;

                case "Asset Menu":
                    uiState = UIState.AssetMenu;
                    break;

                case "Asset Settings":
                    uiState = UIState.AssetSettings;
                    break;

                case "Quit":
                    uiState = UIState.Quit;
                    break;
            }
        }

        /// <summary>
        /// The user selects a UI state from the main menu buttons, this function is then called when the Main Menu is tweened out, tweening in the correct UI menu using the change UI state with correct tweening times.
        /// </summary>
        public void MainMenuChange()
        {
            switch (uiState)
            {
                case UIState.PlayerSettings:
                    playerSettingsTween.BeginTween();
                    break;
                case UIState.BubbleSettings:
                    bubbleSettingsTween.BeginTween();
                    break;
                case UIState.Quit:
                    quitPromptTween.BeginTween();
                    break;
            }
        }

        /// <summary>
        /// Function called when the user opens the main menu during play.
        /// </summary>
        /// <param name="Open">Should the menu open. True means yes, False means no.</param>
        public void OpenCloseMainMenu(bool Open)
        {
            if (Open)
                mainMenuBeginTween.BeginTween();
            else
                mainMenuReturnTween.ReturnTween();

            uiState = UIState.Mainmenu;

        }

        /// <summary>
        /// Function called when the user opens the asset menu during play.
        /// </summary>
        /// <param name="Open">Should the menu open. True means yes, False means no.</param>
        public void OpenCloseAssetMenu(bool Open)
        {
            if (Open)
                assetMenuTween.BeginTween();
            else
                assetMenuTween.ReturnTween();
        }

        /// <summary>
        /// Function called when the user opens the asset settings menu during play
        /// </summary>
        /// <param name="Open">Should the menu open. True means yes, False means no.</param>
        public void OpenCloseAssetSettingsMenu(bool Open)
        {
            if (Open)
                assetSettingsTween.BeginTween();
            else
                assetSettingsTween.ReturnTween();
        }

        /// <summary>
        /// Function called when the user opens the bubble settings menu during play
        /// </summary>
        /// <param name="Open">Should the menu open. True means yes, False means no.</param>
        public void OpenCloseBubbleSettingsMenu(bool Open, bool InvokeReturns = true)
        {
            if (Open)
                bubbleSettingsTween.BeginTween();
            else if (!InvokeReturns)
                bubbleSettingsTween.ReturnTween(false);
            else
                bubbleSettingsTween.ReturnTween();
        }

        /// <summary>
        /// Function called when the player clicks on a control button, decides on what action is to be rebinded using the passed in name
        /// </summary>
        /// <param name="actionToRebind">Name of the control to rebind</param>
        public void StartRebinding(string actionToRebind)
        {
            //actives a "Waiting for Binding" text to show the user to input a binding.
            waitingForBindTxt.SetActive(true);
            switch (actionToRebind)
            {
                case mainMenuBindingKey:
                    Rebinding(mainMenu, mainMenuBindingTxt);
                    break;
                case assetMenuBindingKey:
                    Rebinding(assetMenu, assetMenuBindingTxt);
                    break;
                case runBindingKey:
                    Rebinding(run, runBindingTxt);
                    break;
                case quickExitBindingKey:
                    Rebinding(quickExit, quickExitBindingTxt);
                    break;
                case terraformingBindingKey:
                    Rebinding(terraforming, terraformingBindingTxt);
                    break;
                case interactionBindingKey:
                    Rebinding(interaction, interactionBindingTxt);
                    break;
                case cameraRailBindingKey:
                    Rebinding(cameraRail, cameraRailBindingTxt);
                    break;
            }
        }

        /// <summary>
        /// The function called to start the rebinding process with the correct action to change. Excludes all mouse controls for the binding.
        /// </summary>
        /// <param name="actionToRebind">The Action Reference within the Input Map to rebind</param>
        /// <param name="actionRebindingTxt">The text element within the player control settings corisponding to the control that is being rebinded</param>
        void Rebinding(InputActionReference actionToRebind, TextMeshProUGUI actionRebindingTxt)
        {
            //caches the operation Unity Input System uses to change a binding. Added the options to exclude mouse controls, call a function on completion and wait 0.1 second before completing the operation of the press of a valid control.
            rebindingOperation = actionToRebind.action.PerformInteractiveRebinding()
                .WithControlsExcluding("Mouse")
                .OnMatchWaitForAnother(0.1f)
                .OnComplete(operation => EndRebinding(actionToRebind, actionRebindingTxt))
                .Start();
        }

        /// <summary>
        /// The process to be carried out when the rebind is complete, Includes disposing of the task to regain memory and setting text elements.
        /// </summary>
        /// <param name="actionToRebind">The Action Reference within the Input Map to rebind</param>
        /// <param name="actionRebindingTxt">The text element within the player control settings corisponding to the control taht is being rebinded</param>
        void EndRebinding(InputActionReference actionToRebind, TextMeshProUGUI actionRebindingTxt)
        {
            //removes task from memory and waiting for bind text
            waitingForBindTxt.SetActive(false);
            rebindingOperation.Dispose();

            //set the relivant text element to the new control
            actionRebindingTxt.text = InputControlPath.ToHumanReadableString(actionToRebind.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        }

        /// <summary>
        /// Updates the asset menu settings to the passed in objects data
        /// </summary>
        /// <param name="objectdata">The interacted with objects data to become the values for the asset settings menu</param>
        /// <param name="audioSource">The audio source attached to the object so OnClick methods will take effect on correct audio source</param>
        public void UpdateAssetMenuSettings(ObjectData objectdata, AudioSource audioSource = null)
        {
            RemoveAllAssetSettingsListeners();
            Debug.Log("Removed Listeners");

            if (audioSource != null)
            {
                AssetSettingsUpdateSoundType(objectdata, audioSource);
                AssetSettingsUpdateSoundVolume(objectdata, audioSource);
                AssetSettingsUpdateSoundIndoorVariant(objectdata);
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
        void AssetSettingsUpdateSoundIndoorVariant(ObjectData objectdata)
        {
            soundIndoorTxt.text = objectdata.indoorVariant.ToString();
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

    //An enum containing all the possible UI states to make the code more readable when changing and using states.
    public enum UIState
    {
        Mainmenu,
        PlayerSettings,
        BubbleSettings,
        AssetMenu,
        AssetSettings,
        Quit,
    }
}