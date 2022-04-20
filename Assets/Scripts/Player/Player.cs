using UnityEngine;
using UnityEngine.InputSystem;
using TSGameDev.Managers;
using Cinemachine;
using TMPro;

namespace TSGameDev.Interactables
{
    public class Player : MonoBehaviour
    {
        #region Public Variables

        public delegate void PlayerInteraction();
        public PlayerInteraction Interaction;

        public delegate void CallBackDelegate(InputAction.CallbackContext context = new InputAction.CallbackContext());
        public CallBackDelegate callBackDelegate;

        #endregion

        #region Private Variables

        [Header("Movement Settings")]
        [SerializeField] Camera cameraa;
        [SerializeField] CinemachineVirtualCamera virtualcam;
        [SerializeField] float speed = 10f;
        [SerializeField] float stepInterval;
        [Space(10)]

        [Header("Raycast Settings")]
        [SerializeField] TextMeshProUGUI interactionTxt;
        [SerializeField] float raycastMaxDis = 10;

        [Header("Object Reposition Settings")]
        [SerializeField] float objectPositionLerpTime = 0.5f;
        [Space(10)]

        [Header("Object Reposition String Consts")]
        [SerializeField] const string leftMouseClickRef = "MouseLeftClick";
        [SerializeField] const string rotateObjectLeftRef = "ObjectRotationLeft";
        [SerializeField] const string rotateObjectRightRef = "ObjectRotationRight";
        
        
        int objectBitMask = 1 << 6;
        int environemtBitMask = 1 << 7;
        
        float stepTime;

        GameObject connectedObject = null;
        bool objectConnected = false;

        CharacterController characterController;
        AudioManager audioManager;
        AudioSource audioSource;
        UIManager uiManager;

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
            cameraa = FindObjectOfType<Camera>();
            uiManager = FindObjectOfType<UIManager>();
            interactionTxt = uiManager.InteractionTxt;
        }

        private void Start()
        {
            LockUnlockCursor();
            Interaction = AvoidNullInteractionFunction;
            callBackDelegate = ObjectSettingsRaycast;
            interactionTxt.gameObject.SetActive(false);
        }

        private void Update()
        {
            Movement();
        }

        private void FixedUpdate()
        {
            Gravity();
            if (objectConnected) ObjectRepositionRaycast();
            else ObjectSettingsRaycast();
        }

        //function controling playing movement using the unity componants character controller and the composite vector2 from Input Actions
        void Movement()
        {
            float x = inputMovement.x;
            float z = inputMovement.y;

            Vector3 movement = cameraa.transform.right * x + cameraa.transform.forward * z;

            if (movement.magnitude >= Mathf.Epsilon && running.ReadValue<float>() >= Mathf.Epsilon)
            {
                characterController.Move(movement * (speed * 2) * Time.deltaTime);
            }
            else if (movement.magnitude >= Mathf.Epsilon)
            {
                characterController.Move(movement * speed * Time.deltaTime);
            }
        }

        //Function that impliments Gravity to the character controller as the componant doesn't get effected by it naturally.
        void Gravity()
        {
            if (!characterController.isGrounded)
            {
                characterController.Move(Physics.gravity * Time.deltaTime);
            }
        }

        public void ObjectSettingsRaycast(InputAction.CallbackContext context = new InputAction.CallbackContext())
        {
            RaycastHit hit;
            if(Physics.Raycast(cameraa.transform.position, cameraa.transform.forward, out hit, raycastMaxDis, objectBitMask))
            {
                interactionTxt.gameObject.SetActive(true);
                Interaction = hit.collider.GetComponent<Object.Object>().OpenAssetSettingsMenu;
                if(context.performed)
                {
                    objectConnected = true;
                    connectedObject = hit.collider.gameObject;
                    callBackDelegate = ObjectRepositionRaycast;
                }
            }
            else
            {
                interactionTxt.gameObject.SetActive(false);
                Interaction = AvoidNullInteractionFunction;
            }
        }

        public void ObjectRepositionRaycast(InputAction.CallbackContext context = new InputAction.CallbackContext())
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraa.transform.position, cameraa.transform.forward, out hit, raycastMaxDis, environemtBitMask))
                connectedObject.transform.position = Vector3.LerpUnclamped(connectedObject.transform.position, hit.point, objectPositionLerpTime);
            else
                connectedObject.transform.position = GetObjectSpawnPosition(raycastMaxDis);

            if (context.performed)
            {
                switch (context.action.name)
                {
                    case leftMouseClickRef:
                        objectConnected = false;
                        callBackDelegate = ObjectSettingsRaycast;
                        break;
                    case rotateObjectLeftRef:
                        connectedObject.transform.eulerAngles += new Vector3(0, 15, 0);
                        break;
                    case rotateObjectRightRef:
                        connectedObject.transform.eulerAngles -= new Vector3(0, 15, 0);
                        break;
                    default:
                        Debug.Log(context.action.name);
                        break;
                }
            }
        }

        //function to lock and unlock the cursor I.E. making the cursor visible and unlocked from centre of teh screen
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

        //function to lock and unlock the camera I.E. stop the camera from responding to mouse movements
        public void LockUnlockCamera(bool isLocked)
        {
            virtualcam.enabled = !isLocked;
        }
    
        public Vector3 GetObjectSpawnPosition(float spawnDisFromPlayer)
        {
            Vector3 spawnPos = cameraa.gameObject.transform.position + (cameraa.gameObject.transform.forward * spawnDisFromPlayer);
            spawnPos.y = 0;
            return spawnPos;
        }

        //function that is assigned to the interaction delegate at the beginning to avoid a null interaction delegate reference
        void AvoidNullInteractionFunction()
        {
            Debug.Log("Avoid Null Interaction Function");
        }
    
    }

}
