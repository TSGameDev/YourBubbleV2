// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input Actions/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""00b1bfb7-59a2-4350-af99-f021616f4215"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""PassThrough"",
                    ""id"": ""43543020-e83e-4ff4-8181-480a50cac5b5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""6a0aef7e-a0b5-401c-bc3d-4e84c636aeba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Main Menu"",
                    ""type"": ""Button"",
                    ""id"": ""2d707b51-24f3-4e37-b41c-5fe0476be283"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Asset Menu"",
                    ""type"": ""Button"",
                    ""id"": ""397c37fc-6fec-4936-adef-346d7e769365"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b9c66f07-411c-4f30-942d-03751ba412da"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""73e3c1a8-a22d-4542-861b-f2d750327d97"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""366ab831-6dd8-4ea9-8bb2-2eeaf4e8cff1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c948723b-5b0c-47b0-9c67-1ea3d0219362"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3e8bea61-e31a-443b-abdf-69a14177deea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""21569a2c-871b-469f-a4d9-f4e144f4561c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bec90d9c-91f9-4867-bc6e-b8fa1e5759bd"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d2ca117-a029-4a61-90e8-2d05c22bf20c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Main Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""011de5c2-5a8a-4162-b71d-5ed0eb2a6691"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Asset Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12539b3e-564d-4823-aa19-438baa654d4b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""0c27e13e-e6ef-45a2-a5e0-eef5939edc6e"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""ab2029f8-98fb-4da0-8fe7-f153f4c4f3e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ea579572-1fb2-4bb4-9c79-75fd55af5ada"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_WASD = m_Game.FindAction("WASD", throwIfNotFound: true);
        m_Game_Interaction = m_Game.FindAction("Interaction", throwIfNotFound: true);
        m_Game_MainMenu = m_Game.FindAction("Main Menu", throwIfNotFound: true);
        m_Game_AssetMenu = m_Game.FindAction("Asset Menu", throwIfNotFound: true);
        m_Game_MouseDelta = m_Game.FindAction("MouseDelta", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Newaction = m_UI.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_WASD;
    private readonly InputAction m_Game_Interaction;
    private readonly InputAction m_Game_MainMenu;
    private readonly InputAction m_Game_AssetMenu;
    private readonly InputAction m_Game_MouseDelta;
    public struct GameActions
    {
        private @PlayerActions m_Wrapper;
        public GameActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_Game_WASD;
        public InputAction @Interaction => m_Wrapper.m_Game_Interaction;
        public InputAction @MainMenu => m_Wrapper.m_Game_MainMenu;
        public InputAction @AssetMenu => m_Wrapper.m_Game_AssetMenu;
        public InputAction @MouseDelta => m_Wrapper.m_Game_MouseDelta;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @WASD.started -= m_Wrapper.m_GameActionsCallbackInterface.OnWASD;
                @WASD.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnWASD;
                @WASD.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnWASD;
                @Interaction.started -= m_Wrapper.m_GameActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnInteraction;
                @MainMenu.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMainMenu;
                @MainMenu.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMainMenu;
                @MainMenu.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMainMenu;
                @AssetMenu.started -= m_Wrapper.m_GameActionsCallbackInterface.OnAssetMenu;
                @AssetMenu.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnAssetMenu;
                @AssetMenu.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnAssetMenu;
                @MouseDelta.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseDelta;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WASD.started += instance.OnWASD;
                @WASD.performed += instance.OnWASD;
                @WASD.canceled += instance.OnWASD;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @MainMenu.started += instance.OnMainMenu;
                @MainMenu.performed += instance.OnMainMenu;
                @MainMenu.canceled += instance.OnMainMenu;
                @AssetMenu.started += instance.OnAssetMenu;
                @AssetMenu.performed += instance.OnAssetMenu;
                @AssetMenu.canceled += instance.OnAssetMenu;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
            }
        }
    }
    public GameActions @Game => new GameActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private @PlayerActions m_Wrapper;
        public UIActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGameActions
    {
        void OnWASD(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnMainMenu(InputAction.CallbackContext context);
        void OnAssetMenu(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
