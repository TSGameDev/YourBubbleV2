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
        
        //[SerializeField] ObjectData data = new ObjectData();

        UIManager uiManager;
        Player player;

        #endregion 
       
        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
            player = FindObjectOfType<Player>();
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
