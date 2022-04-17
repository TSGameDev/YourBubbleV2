using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.Managers;
using TSGameDev.Interactables;

namespace TSGameDev.Object
{
    public class Object : MonoBehaviour
    {
        #region Private Variables

        public ObjectData data;

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
            if (data.soundClip != null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = data.soundClip;
                audioSource.Play();
            }

            if (data.effect != null)
            {
                currentParticleSystem = Instantiate(data.effect, gameObject.transform);
                
            }
            gameObject.layer = 6;
            boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(1, 1, 1);
        }

        public void OpenAssetSettingsMenu()
        {
            gameManager.gameStateActions.ChangeToState(GameState.AssetSettings);
            uiManager.UpdateAssetMenuSettings(data, audioSource);
        }

        public void CloseAssetSettingsMenu()
        {
            gameManager.gameStateActions.ChangeToState(GameState.Application);
        }
    }
}
