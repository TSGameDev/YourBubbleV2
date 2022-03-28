using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.Managers;
using TSGameDev.Interactables;

namespace TSGameDev.Object
{
    public class Object : MonoBehaviour
    {
        [SerializeField] ObjectData data = new ObjectData();

        UIManager uiManager;
        Player player;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
            player = FindObjectOfType<Player>();
        }

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
