using System;
using UnityEngine;

namespace TSGameDev.systems
{
    public class IndoorDetection : MonoBehaviour
    {
        #region Event Handles

        public event Action onShelterEnter;
        public void ShelterEnter() { if (onShelterEnter != null) onShelterEnter(); }

        public event Action onShelterExit;
        public void ShelterExit() { if (onShelterExit != null) onShelterExit(); }

        #endregion

        #region Raycast Handle

        [SerializeField] float raycastDistance = 5f;

        int environmentLayermask = 1 << 7;
        bool onShelterEnterCalled;
        bool onShelterExitCalled;

        private void FixedUpdate()
        {
            RaycastHit hit;
            
            if(Physics.Raycast(transform.position, Vector3.up, out hit, raycastDistance, environmentLayermask))
            {
                if (!onShelterEnterCalled) 
                { 
                    ShelterEnter(); 
                    onShelterEnterCalled = true; 
                    onShelterExitCalled = false; 
                }
            }
            else
            {
                if (!onShelterExitCalled) 
                { 
                    ShelterExit(); 
                    onShelterExitCalled = true; 
                    onShelterEnterCalled = false; 
                }
            }
        }


        #endregion
    }
}
