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

        #endregion

        private void FixedUpdate()
        {
            RaycastHit hit;
            //If a ray hits something on the envionrment layer above the player, make sounds play their indoor variants via events
            if(Physics.Raycast(transform.position, Vector3.up, out hit, raycastDistance, environmentLayermask))
            {
                if (!onShelterEnterCalled) 
                { 
                    ShelterEnter(); 
                    onShelterEnterCalled = true; 
                    onShelterExitCalled = false; 
                }
            }
            //if not, make sounds play outside variant via events
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
    }
}
