// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/UiInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @UiInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @UiInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UiInputs"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""124df18b-692c-4c06-b870-f5446f339ef5"",
            ""actions"": [
                {
                    ""name"": ""Navigate Up"",
                    ""type"": ""Button"",
                    ""id"": ""b01803d1-2803-4f00-8806-716b7b1097ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Down"",
                    ""type"": ""Value"",
                    ""id"": ""b2ad5209-830b-4cd2-a116-ccc179398789"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Left"",
                    ""type"": ""Button"",
                    ""id"": ""6f78ab02-cb9a-4c15-9275-92594b7b2ff1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Right"",
                    ""type"": ""Button"",
                    ""id"": ""a5cf7698-5fff-404f-a627-1aadc7abad7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""ef8dc68b-a1b2-46bb-a872-5cd2d51d1b7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0952572-4428-4417-b066-6e3ffd3a67ce"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5ea5cae-408e-4d3d-b1a7-80ab3144bbe6"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8139989f-56db-4e69-8d0e-bff8fd2ed4fd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a840bfdd-d832-4340-8e7d-e021bfef9be7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b333cc2-9f9d-4017-97bb-f20f3bcdc91e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6254862-9b7f-49a5-82a0-94aa1adb090b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59efc977-3391-4a2b-bea1-60ae4ac02335"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e152256-a614-423a-85e3-6859e1f66faa"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9afb7a0-858b-4f66-9816-bfd11d362685"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1dc22bff-9b6d-4fb9-9069-52f354809c57"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""4c8fb04c-c497-402c-a99a-61d16fe5c171"",
            ""actions"": [
                {
                    ""name"": ""Test"",
                    ""type"": ""Button"",
                    ""id"": ""6106d486-0aed-41c0-9081-23fc058bd13f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d77ac041-607f-4c82-be9c-59997460e56f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Test"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_NavigateUp = m_UI.FindAction("Navigate Up", throwIfNotFound: true);
        m_UI_NavigateDown = m_UI.FindAction("Navigate Down", throwIfNotFound: true);
        m_UI_NavigateLeft = m_UI.FindAction("Navigate Left", throwIfNotFound: true);
        m_UI_NavigateRight = m_UI.FindAction("Navigate Right", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Test = m_Player.FindAction("Test", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_NavigateUp;
    private readonly InputAction m_UI_NavigateDown;
    private readonly InputAction m_UI_NavigateLeft;
    private readonly InputAction m_UI_NavigateRight;
    private readonly InputAction m_UI_Click;
    public struct UIActions
    {
        private @UiInputs m_Wrapper;
        public UIActions(@UiInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavigateUp => m_Wrapper.m_UI_NavigateUp;
        public InputAction @NavigateDown => m_Wrapper.m_UI_NavigateDown;
        public InputAction @NavigateLeft => m_Wrapper.m_UI_NavigateLeft;
        public InputAction @NavigateRight => m_Wrapper.m_UI_NavigateRight;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @NavigateUp.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateUp;
                @NavigateUp.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateUp;
                @NavigateUp.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateUp;
                @NavigateDown.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateDown;
                @NavigateDown.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateDown;
                @NavigateDown.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateDown;
                @NavigateLeft.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateLeft;
                @NavigateLeft.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateLeft;
                @NavigateLeft.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateLeft;
                @NavigateRight.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateRight;
                @NavigateRight.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateRight;
                @NavigateRight.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateRight;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NavigateUp.started += instance.OnNavigateUp;
                @NavigateUp.performed += instance.OnNavigateUp;
                @NavigateUp.canceled += instance.OnNavigateUp;
                @NavigateDown.started += instance.OnNavigateDown;
                @NavigateDown.performed += instance.OnNavigateDown;
                @NavigateDown.canceled += instance.OnNavigateDown;
                @NavigateLeft.started += instance.OnNavigateLeft;
                @NavigateLeft.performed += instance.OnNavigateLeft;
                @NavigateLeft.canceled += instance.OnNavigateLeft;
                @NavigateRight.started += instance.OnNavigateRight;
                @NavigateRight.performed += instance.OnNavigateRight;
                @NavigateRight.canceled += instance.OnNavigateRight;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Test;
    public struct PlayerActions
    {
        private @UiInputs m_Wrapper;
        public PlayerActions(@UiInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Test => m_Wrapper.m_Player_Test;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Test.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTest;
                @Test.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTest;
                @Test.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTest;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Test.started += instance.OnTest;
                @Test.performed += instance.OnTest;
                @Test.canceled += instance.OnTest;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    public interface IUIActions
    {
        void OnNavigateUp(InputAction.CallbackContext context);
        void OnNavigateDown(InputAction.CallbackContext context);
        void OnNavigateLeft(InputAction.CallbackContext context);
        void OnNavigateRight(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnTest(InputAction.CallbackContext context);
    }
}
