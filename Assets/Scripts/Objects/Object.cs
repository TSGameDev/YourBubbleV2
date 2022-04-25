using UnityEngine;
using UnityEngine.Audio;
using TSGameDev.Managers;

namespace TSGameDev.Object
{
    public class Object : MonoBehaviour
    {
        #region Private Variables

        public ObjectSO objectItem;
        public ObjectData data;
        public AudioMixerGroup audioMixerGroup;

        UIManager uiManager;
        GameManager gameManager;
        AudioSource audioSource;
        ParticleSystem currentParticleSystem;
        BoxCollider boxCollider;

        #endregion 
       
        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
            gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            if (objectItem.soundClip != null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = objectItem.soundClip;
                audioSource.Play();
                audioSource.minDistance = data.minDistance;
                audioSource.maxDistance = data.maxDistance;
                audioSource.volume = data.volume;
                audioSource.outputAudioMixerGroup = audioMixerGroup;
            }

            if (objectItem.effect != null)
            {
                currentParticleSystem = Instantiate(objectItem.effect, gameObject.transform);
                
            }
            gameObject.layer = 6;
            boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(1, 1, 1);
        }

        /// <summary>
        /// Opens the Asset Settings Menu via the Game State Actions, to perform functions to change states, and UI Manager, to update UI elements to match Object data of selected object.
        /// </summary>
        public void OpenAssetSettingsMenu()
        {
            gameManager.gameStateActions.ChangeToState(GameState.AssetSettings);
            uiManager.UpdateAssetMenuSettings(objectItem, data, audioSource);
        }

        /// <summary>
        /// Closes the Asset Settings Menu via the Game State Acions.
        /// </summary>
        public void CloseAssetSettingsMenu()
        {
            gameManager.gameStateActions.ChangeToState(GameState.Application);
        }
    }
}
