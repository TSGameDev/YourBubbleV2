using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TSGameDev.Managers;
using Cinemachine;

namespace TSGameDev.Interactables
{
    public class Player : MonoBehaviour
    {
        #region Public Variables

        public delegate void PlayerInteraction();
        public PlayerInteraction Interaction;

        #endregion

        #region Private Variables

        [SerializeField] Camera cameraa;
        [SerializeField] CinemachineVirtualCamera virtualcam;
        [SerializeField] float speed = 10f;

        CharacterController characterController;
        AudioManager audioManager;
        AudioSource audioSource;

        #endregion

        #region Get-Set

        public Vector2 inputMovement { set; private get; }
        public InputAction running { set; private get; }

        #endregion

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            audioManager = GetComponent<AudioManager>();
            audioSource = GetComponent<AudioSource>();

            LockUnlockCursor();
        }

        private void Update()
        {
            Movement();
        }

        private void FixedUpdate()
        {
            Gravity();
        }

        void Movement()
        {
            float x = inputMovement.x;
            float z = inputMovement.y;

            Vector3 movement = cameraa.transform.right * x + cameraa.transform.forward * z;

            if (movement.magnitude >= Mathf.Epsilon && running.ReadValue<float>() >= Mathf.Epsilon)
                characterController.Move(movement * (speed * 2) * Time.deltaTime);
            else if (movement.magnitude >= Mathf.Epsilon)
                characterController.Move(movement * speed * Time.deltaTime);
        }

        void Gravity()
        {
            if (!characterController.isGrounded)
            {
                characterController.Move(Physics.gravity * Time.deltaTime);
            }
        }

        public void LockUnlockCursor(bool isLocked = true)
        {
            if (isLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }

        public void LockUnlockCamera(bool isLocked)
        {
            virtualcam.enabled = !isLocked;
        }
    

    }

}
