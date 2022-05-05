// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/Settings/Input Actions/PlayerActions.inputactions'

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
                    ""name"": ""Running "",
                    ""type"": ""Button"",
                    ""id"": ""7883cd3c-376b-42f3-bb9e-3cc11bcac978"",
                    ""expectedControlType"": ""Button"",
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
                    ""name"": ""Quick Exit"",
                    ""type"": ""Button"",
                    ""id"": ""29cf1f39-b952-4a6b-8533-8aca44111286"",
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
                },
                {
                    ""name"": ""MouseLeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""d33cd2ba-9d7d-437f-acb1-65359ec00e3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseRightClick"",
                    ""type"": ""Button"",
                    ""id"": ""920c5ddd-0df8-4966-b28d-c2d86b959e1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ObjectRotationLeft"",
                    ""type"": ""Button"",
                    ""id"": ""66b4e6e0-170f-468c-8a9e-35bbd0747e7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ObjectRotationRight"",
                    ""type"": ""Button"",
                    ""id"": ""7fb0b46e-7226-4f20-8a56-05f776c6011d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleItemModelLeft"",
                    ""type"": ""Button"",
                    ""id"": ""32bb9272-04be-4cf7-8a05-f2c859be863b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleItemModelRight"",
                    ""type"": ""Button"",
                    ""id"": ""7ec35f14-17e9-417c-8638-cf0d147759d8"",
                    ""expectedControlType"": ""Button"",
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
                    ""path"": ""<Keyboard>/f"",
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
                    ""id"": ""c381e1b9-85a6-4b0d-8ee1-b4208b7039ed"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13458963-ba43-4776-8ae4-2b42572b9af8"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quick Exit"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""eb230f1c-60fa-413a-8cbb-3320173904a6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""631b3fe5-2f6a-45ff-81cf-af761872f0a1"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ObjectRotationLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a305a8f2-77bd-4632-a541-6fa7a43cb1f8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ObjectRotationRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9ad1288-b19a-4467-8c82-e4473e35022d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e35b340d-888a-4f8c-b6b5-462aa35ddc3f"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleItemModelLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39f46060-10c6-42cf-8b5a-e4d14597ba93"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleItemModelRight"",
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
                    ""name"": ""Mouse Position"",
                    ""type"": ""Value"",
                    ""id"": ""ab2029f8-98fb-4da0-8fe7-f153f4c4f3e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Click"",
                    ""type"": ""Button"",
                    ""id"": ""2735ea6d-8a61-43eb-b4e3-c29ea271ba2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExitMenu"",
                    ""type"": ""Button"",
                    ""id"": ""e50369a6-6e0b-4ac4-b310-b3f0209c7c65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ea579572-1fb2-4bb4-9c79-75fd55af5ada"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd3ee16f-d954-4f91-be8a-16c625917919"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60102bf3-c16b-4b16-a1e0-708a660fd57c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitMenu"",
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
        m_Game_Running = m_Game.FindAction("Running ", throwIfNotFound: true);
        m_Game_Interaction = m_Game.FindAction("Interaction", throwIfNotFound: true);
        m_Game_MainMenu = m_Game.FindAction("Main Menu", throwIfNotFound: true);
        m_Game_QuickExit = m_Game.FindAction("Quick Exit", throwIfNotFound: true);
        m_Game_AssetMenu = m_Game.FindAction("Asset Menu", throwIfNotFound: true);
        m_Game_MouseDelta = m_Game.FindAction("MouseDelta", throwIfNotFound: true);
        m_Game_MouseLeftClick = m_Game.FindAction("MouseLeftClick", throwIfNotFound: true);
        m_Game_MouseRightClick = m_Game.FindAction("MouseRightClick", throwIfNotFound: true);
        m_Game_ObjectRotationLeft = m_Game.FindAction("ObjectRotationLeft", throwIfNotFound: true);
        m_Game_ObjectRotationRight = m_Game.FindAction("ObjectRotationRight", throwIfNotFound: true);
        m_Game_CycleItemModelLeft = m_Game.FindAction("CycleItemModelLeft", throwIfNotFound: true);
        m_Game_CycleItemModelRight = m_Game.FindAction("CycleItemModelRight", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_MousePosition = m_UI.FindAction("Mouse Position", throwIfNotFound: true);
        m_UI_MouseClick = m_UI.FindAction("Mouse Click", throwIfNotFound: true);
        m_UI_ExitMenu = m_UI.FindAction("ExitMenu", throwIfNotFound: true);
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
    private readonly InputAction m_Game_Running;
    private readonly InputAction m_Game_Interaction;
    private readonly InputAction m_Game_MainMenu;
    private readonly InputAction m_Game_QuickExit;
    private readonly InputAction m_Game_AssetMenu;
    private readonly InputAction m_Game_MouseDelta;
    private readonly InputAction m_Game_MouseLeftClick;
    private readonly InputAction m_Game_MouseRightClick;
    private readonly InputAction m_Game_ObjectRotationLeft;
    private readonly InputAction m_Game_ObjectRotationRight;
    private readonly InputAction m_Game_CycleItemModelLeft;
    private readonly InputAction m_Game_CycleItemModelRight;
    public struct GameActions
    {
        private @PlayerActions m_Wrapper;
        public GameActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_Game_WASD;
        public InputAction @Running => m_Wrapper.m_Game_Running;
        public InputAction @Interaction => m_Wrapper.m_Game_Interaction;
        public InputAction @MainMenu => m_Wrapper.m_Game_MainMenu;
        public InputAction @QuickExit => m_Wrapper.m_Game_QuickExit;
        public InputAction @AssetMenu => m_Wrapper.m_Game_AssetMenu;
        public InputAction @MouseDelta => m_Wrapper.m_Game_MouseDelta;
        public InputAction @MouseLeftClick => m_Wrapper.m_Game_MouseLeftClick;
        public InputAction @MouseRightClick => m_Wrapper.m_Game_MouseRightClick;
        public InputAction @ObjectRotationLeft => m_Wrapper.m_Game_ObjectRotationLeft;
        public InputAction @ObjectRotationRight => m_Wrapper.m_Game_ObjectRotationRight;
        public InputAction @CycleItemModelLeft => m_Wrapper.m_Game_CycleItemModelLeft;
        public InputAction @CycleItemModelRight => m_Wrapper.m_Game_CycleItemModelRight;
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
                @Running.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRunning;
                @Running.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRunning;
                @Running.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRunning;
                @Interaction.started -= m_Wrapper.m_GameActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnInteraction;
                @MainMenu.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMainMenu;
                @MainMenu.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMainMenu;
                @MainMenu.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMainMenu;
                @QuickExit.started -= m_Wrapper.m_GameActionsCallbackInterface.OnQuickExit;
                @QuickExit.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnQuickExit;
                @QuickExit.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnQuickExit;
                @AssetMenu.started -= m_Wrapper.m_GameActionsCallbackInterface.OnAssetMenu;
                @AssetMenu.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnAssetMenu;
                @AssetMenu.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnAssetMenu;
                @MouseDelta.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseDelta;
                @MouseLeftClick.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseLeftClick;
                @MouseRightClick.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseRightClick;
                @ObjectRotationLeft.started -= m_Wrapper.m_GameActionsCallbackInterface.OnObjectRotationLeft;
                @ObjectRotationLeft.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnObjectRotationLeft;
                @ObjectRotationLeft.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnObjectRotationLeft;
                @ObjectRotationRight.started -= m_Wrapper.m_GameActionsCallbackInterface.OnObjectRotationRight;
                @ObjectRotationRight.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnObjectRotationRight;
                @ObjectRotationRight.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnObjectRotationRight;
                @CycleItemModelLeft.started -= m_Wrapper.m_GameActionsCallbackInterface.OnCycleItemModelLeft;
                @CycleItemModelLeft.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnCycleItemModelLeft;
                @CycleItemModelLeft.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnCycleItemModelLeft;
                @CycleItemModelRight.started -= m_Wrapper.m_GameActionsCallbackInterface.OnCycleItemModelRight;
                @CycleItemModelRight.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnCycleItemModelRight;
                @CycleItemModelRight.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnCycleItemModelRight;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WASD.started += instance.OnWASD;
                @WASD.performed += instance.OnWASD;
                @WASD.canceled += instance.OnWASD;
                @Running.started += instance.OnRunning;
                @Running.performed += instance.OnRunning;
                @Running.canceled += instance.OnRunning;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @MainMenu.started += instance.OnMainMenu;
                @MainMenu.performed += instance.OnMainMenu;
                @MainMenu.canceled += instance.OnMainMenu;
                @QuickExit.started += instance.OnQuickExit;
                @QuickExit.performed += instance.OnQuickExit;
                @QuickExit.canceled += instance.OnQuickExit;
                @AssetMenu.started += instance.OnAssetMenu;
                @AssetMenu.performed += instance.OnAssetMenu;
                @AssetMenu.canceled += instance.OnAssetMenu;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @MouseLeftClick.started += instance.OnMouseLeftClick;
                @MouseLeftClick.performed += instance.OnMouseLeftClick;
                @MouseLeftClick.canceled += instance.OnMouseLeftClick;
                @MouseRightClick.started += instance.OnMouseRightClick;
                @MouseRightClick.performed += instance.OnMouseRightClick;
                @MouseRightClick.canceled += instance.OnMouseRightClick;
                @ObjectRotationLeft.started += instance.OnObjectRotationLeft;
                @ObjectRotationLeft.performed += instance.OnObjectRotationLeft;
                @ObjectRotationLeft.canceled += instance.OnObjectRotationLeft;
                @ObjectRotationRight.started += instance.OnObjectRotationRight;
                @ObjectRotationRight.performed += instance.OnObjectRotationRight;
                @ObjectRotationRight.canceled += instance.OnObjectRotationRight;
                @CycleItemModelLeft.started += instance.OnCycleItemModelLeft;
                @CycleItemModelLeft.performed += instance.OnCycleItemModelLeft;
                @CycleItemModelLeft.canceled += instance.OnCycleItemModelLeft;
                @CycleItemModelRight.started += instance.OnCycleItemModelRight;
                @CycleItemModelRight.performed += instance.OnCycleItemModelRight;
                @CycleItemModelRight.canceled += instance.OnCycleItemModelRight;
            }
        }
    }
    public GameActions @Game => new GameActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_MousePosition;
    private readonly InputAction m_UI_MouseClick;
    private readonly InputAction m_UI_ExitMenu;
    public struct UIActions
    {
        private @PlayerActions m_Wrapper;
        public UIActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_UI_MousePosition;
        public InputAction @MouseClick => m_Wrapper.m_UI_MouseClick;
        public InputAction @ExitMenu => m_Wrapper.m_UI_ExitMenu;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePosition;
                @MouseClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMouseClick;
                @ExitMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnExitMenu;
                @ExitMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnExitMenu;
                @ExitMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnExitMenu;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
                @ExitMenu.started += instance.OnExitMenu;
                @ExitMenu.performed += instance.OnExitMenu;
                @ExitMenu.canceled += instance.OnExitMenu;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGameActions
    {
        void OnWASD(InputAction.CallbackContext context);
        void OnRunning(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnMainMenu(InputAction.CallbackContext context);
        void OnQuickExit(InputAction.CallbackContext context);
        void OnAssetMenu(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnMouseLeftClick(InputAction.CallbackContext context);
        void OnMouseRightClick(InputAction.CallbackContext context);
        void OnObjectRotationLeft(InputAction.CallbackContext context);
        void OnObjectRotationRight(InputAction.CallbackContext context);
        void OnCycleItemModelLeft(InputAction.CallbackContext context);
        void OnCycleItemModelRight(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
        void OnExitMenu(InputAction.CallbackContext context);
    }
}
