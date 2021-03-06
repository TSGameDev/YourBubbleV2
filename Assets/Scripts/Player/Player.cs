using UnityEngine;
using UnityEngine.InputSystem;
using TSGameDev.Managers;
using TSGameDev.Object;
using Cinemachine;
using TMPro;

namespace TSGameDev.Interactables
{
    public class Player : MonoBehaviour
    {
        #region Interaction Variables

        public delegate void PlayerInteraction();
        public PlayerInteraction Interaction;

        public delegate void CallBackDelegate(InputAction.CallbackContext context = new InputAction.CallbackContext());
        public CallBackDelegate callBackDelegate;

        [Header("Interaction Settings")]
        [SerializeField] float raycastMaxDis = 10;

        [SerializeField] const string rightMouseClickRef = "MouseRightClick";
        [SerializeField] const string leftMouseClickRef = "MouseLeftClick";
        [SerializeField] const string rotateObjectLeftRef = "ObjectRotationLeft";
        [SerializeField] const string rotateObjectRightRef = "ObjectRotationRight";
        [SerializeField] const string cycleItemModelLeft = "CycleItemModelLeft";
        [SerializeField] const string cycleItemModelRight = "CycleItemModelRight";
        [Space(10)]

        int objectBitMask = 1 << 6;
        int environemtBitMask = 1 << 7;
        TextMeshProUGUI interactionTxt;
        RebindHandler rebindHandler;
        SceneDatabase sceneDatabase;
        public GameObject connectedObject
        {
            get; set; 
        }
        

        #endregion

        #region Movement Variables

        private bool movementValid = true;
        public bool MovementValid
        {
            set
            {
                movementValid = value;
            }
            private get
            {
                return movementValid;
            }
        }

        [Header("Movement Settings")]
        [SerializeField] Camera cameraa;
        [SerializeField] CinemachineVirtualCamera virtualcam;
        [SerializeField] float speed = 10f;
        [SerializeField] float stepInterval;
        [Space(10)]

        #endregion

        #region Footstep Sound Effect Variables

        AudioManager audioManager;
        AudioSource audioSource;
        float stepTime;
        
        #endregion

        #region Character Variables

        public Vector2 inputMovement { set; private get; }
        public InputAction running { set; private get; }

        CharacterController characterController;
        UIManager uiManager;

        #endregion

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            audioManager = GetComponent<AudioManager>();
            audioSource = GetComponent<AudioSource>();
            cameraa = FindObjectOfType<Camera>();
            uiManager = FindObjectOfType<UIManager>();
            rebindHandler = FindObjectOfType<RebindHandler>();
            sceneDatabase = FindObjectOfType<SceneDatabase>();
            interactionTxt = rebindHandler.PlayerRaycastText;
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
            if (connectedObject != null)
            {
                ObjectRepositionRaycast();
                callBackDelegate = ObjectRepositionInteraction;
            }
            else ObjectSettingsRaycast();
        }

        /// <summary>
        /// Function controlling the movement of the player
        /// </summary>
        void Movement()
        {
            float x = inputMovement.x;
            float z = inputMovement.y;

            Vector3 movement = cameraa.transform.right * x + cameraa.transform.forward * z;
            if(MovementValid)
            {
                if (movement.magnitude >= Mathf.Epsilon && running.ReadValue<float>() >= Mathf.Epsilon) { characterController.Move(movement * (speed * 2) * Time.deltaTime); }
                else if (movement.magnitude >= Mathf.Epsilon) { characterController.Move(movement * speed * Time.deltaTime); }
            }
        }

        /// <summary>
        /// Function implimenting gravity to the player as the character controller component isn't effected by natural gravity
        /// </summary>
        void Gravity()
        {
            if (!characterController.isGrounded)
            {
                characterController.Move(Physics.gravity * Time.deltaTime);
            }
        }

        /// <summary>
        /// Function to control the interaction with an object spawned into the world and calls the object settings functions. Is called in FixedUpdate as raycasts are use.
        /// </summary>
        /// <param name="context">The action context from the performed action that called this function in the input manager</param>
        public void ObjectSettingsRaycast(InputAction.CallbackContext context = new InputAction.CallbackContext())
        {
            RaycastHit hit;
            if(Physics.Raycast(cameraa.transform.position, cameraa.transform.forward, out hit, raycastMaxDis, objectBitMask))
            {
                interactionTxt.gameObject.SetActive(true);
                Interaction = hit.collider.GetComponent<Object.Object>().OpenAssetSettingsMenu;
                if(context.performed && context.action.name == leftMouseClickRef)
                {
                    connectedObject = hit.collider.gameObject;
                    callBackDelegate = ObjectRepositionInteraction;
                }
            }
            else
            {
                interactionTxt.gameObject.SetActive(false);
                Interaction = AvoidNullInteractionFunction;
            }
        }

        /// <summary>
        /// The function controlling the reposition of a selected object spawned into the world
        /// </summary>
        public void ObjectRepositionRaycast()
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastMaxDis, environemtBitMask))
                connectedObject.transform.position = hit.point;
            else
                connectedObject.transform.position = GetObjectSpawnPosition(raycastMaxDis);

            Object.Object ConnectedObjectScript = connectedObject.GetComponent<Object.Object>();
            ConnectedObjectScript.data.objectPosition = connectedObject.transform.position;
            ConnectedObjectScript.data.objectRotation = connectedObject.transform.rotation;
        }
        
        /// <summary>
        /// Function Handleing the inputs when repositioning an object
        /// </summary>
        /// <param name="context">The performed inputs context</param>
        void ObjectRepositionInteraction(InputAction.CallbackContext context = new InputAction.CallbackContext())
        {
            if (context.performed)
            {
                switch (context.action.name)
                {
                    case leftMouseClickRef:
                        Instantiate(connectedObject, connectedObject.transform.position, connectedObject.transform.rotation);
                        break;
                    case rightMouseClickRef:
                        Destroy(connectedObject);
                        connectedObject = null;
                        callBackDelegate = ObjectSettingsRaycast;
                        break;
                    case rotateObjectLeftRef:
                        connectedObject.transform.eulerAngles += new Vector3(0, 15, 0);
                        break;
                    case rotateObjectRightRef:
                        connectedObject.transform.eulerAngles -= new Vector3(0, 15, 0);
                        break;
                    case cycleItemModelLeft:
                        sceneDatabase.CycleItemModelLeft(connectedObject);
                        break;
                    case cycleItemModelRight:
                        sceneDatabase.CycleItemModelRight(connectedObject);
                        break;
                    default:
                        Debug.Log(context.action.name);
                        break;
                }
            }
        }

        /// <summary>
        /// Function locks and unlocks the cursor based on the passed bool
        /// </summary>
        /// <param name="isLocked">Bool that locks or unlocks the cursor. To lock cursor this needs to be True</param>
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

        /// <summary>
        /// Function locks and unlocked the camera by turning the cinemachine componants on and off.
        /// </summary>
        /// <param name="isLocked">Bool that lock and unlocks the camera. To lock camera this need to be True</param>
        public void LockUnlockCamera(bool isLocked)
        {
            virtualcam.enabled = !isLocked;
        }
        
        /// <summary>
        /// Function to get a position away form the players front.
        /// </summary>
        /// <param name="spawnDisFromPlayer">The float value away from the player in the forward direction</param>
        /// <returns></returns>
        public Vector3 GetObjectSpawnPosition(float spawnDisFromPlayer)
        {
            Vector3 spawnPos = cameraa.gameObject.transform.position + (cameraa.gameObject.transform.forward * spawnDisFromPlayer);
            spawnPos.y = 0;
            return spawnPos;
        }

        /// <summary>
        /// Function to assign to delegate to avoid them being null at the start of in some situations when they are unassigned.
        /// </summary>
        void AvoidNullInteractionFunction()
        {
            Debug.Log("Avoid Null Interaction Function");
        }
    
    }

}
