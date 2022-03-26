using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSGameDev.Managers;

namespace TSGameDev.Object
{
    public class Object : MonoBehaviour
    {
        [SerializeField] ObjectData data = new ObjectData();

        GameManager gameManager;
        UIManager uiManager;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
            uiManager = FindObjectOfType<UIManager>();
        }

        public void OpenAssetSettings()
        {

        }

        public void CloseAssetSettings()
        {

        }
    }
}
