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

        public ObjectData data
        {
            set;
            private get;
        }

        UIManager uiManager;
        Player player;
        AudioSource audioSource;
        ParticleSystem currentParticleSystem;

        #endregion 
       
        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
            player = FindObjectOfType<Player>();
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
        }

        //Function to Open and Close the asset settings UI menu
        public void OpenCloseAssetSettings(bool Open)
        {
            if(Open)
            {
                uiManager.OpenCloseAssetSettingsMenu(true);
                player.LockUnlockCamera(true);
                player.LockUnlockCursor(false);
            }
            else
            {
                uiManager.OpenCloseAssetSettingsMenu(false);
                player.LockUnlockCamera(false);
                player.LockUnlockCursor(true);
            }
        }
    }
}
