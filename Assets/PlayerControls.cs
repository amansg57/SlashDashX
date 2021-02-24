// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""c07752a0-e9ce-4f7e-9689-1e22e4f7ca24"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""f2c37104-bffd-44d8-8f42-a8b5f3d63c09"",
                    ""expectedControlType"": ""Digital"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""LAtk"",
                    ""type"": ""Value"",
                    ""id"": ""98f2888b-1e3f-47d6-b652-1819e2612d05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MAtk"",
                    ""type"": ""Value"",
                    ""id"": ""c0f5d8f0-1bd0-495a-a972-995368350e98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""HAtk"",
                    ""type"": ""Value"",
                    ""id"": ""4a8503ea-be4e-4c7b-a40b-152cef2b8c92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Value"",
                    ""id"": ""741da803-4433-4e57-8a93-e1007be76332"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Value"",
                    ""id"": ""911f62cc-9c1e-48b4-b40b-22151cc7e0d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ac289173-c934-44ab-8cf0-ea4acee85dd3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Value"",
                    ""id"": ""1115538c-25f3-47f8-b0cf-9420f5574585"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6ad62d9c-5e25-4d3f-8dd4-49f7284bd31a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71f546d9-d8a9-448e-a242-8571102f8fdf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9212d09-1d0d-4e69-9853-65c034ed5050"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""LAtk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adc40954-50af-43a5-99fd-95dc709d8184"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""LAtk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb542df3-a185-4a5c-9003-20ceaffb71c9"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""MAtk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7484ef5-a259-4df1-bd77-deeedab31677"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""MAtk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c7d32f8-fa88-4fb8-a437-b8e387feb350"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""HAtk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4eba17b4-8370-4cf3-850c-0c1fb9f3e881"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""HAtk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea867680-6ecd-44e5-a55e-7a53a42ed417"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af84e96c-41f3-4386-a1de-2f6895cfa8ce"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ae77784-ade5-4040-b5ec-3f66003564b1"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b0eb3e1-a5a2-48fe-8160-92a196168593"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""91cdcff1-574a-4f6b-9acf-ca3b21e37e79"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f043b329-a42d-457f-82d1-539fb88525e3"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""93e51218-ce16-473e-ab06-53aa0e0bc2a6"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2d9accba-1e8a-4369-92de-681d821b6c7c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8c2808dc-e4e0-4aff-a09b-5c14c81b2e67"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4461634e-61d9-4dae-8b8c-3ebc70de5c0c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""86b3e5a1-7b89-488c-ae66-23b7ff27f7cc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ffc5dcd-e179-4081-93d6-09cf2f155b6c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""basedOn"": """",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""basedOn"": """",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // Character
        m_Character = asset.GetActionMap("Character");
        m_Character_Jump = m_Character.GetAction("Jump");
        m_Character_LAtk = m_Character.GetAction("LAtk");
        m_Character_MAtk = m_Character.GetAction("MAtk");
        m_Character_HAtk = m_Character.GetAction("HAtk");
        m_Character_Block = m_Character.GetAction("Block");
        m_Character_Dodge = m_Character.GetAction("Dodge");
        m_Character_Move = m_Character.GetAction("Move");
        m_Character_Dash = m_Character.GetAction("Dash");
    }

    ~PlayerControls()
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

    // Character
    private readonly InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private readonly InputAction m_Character_Jump;
    private readonly InputAction m_Character_LAtk;
    private readonly InputAction m_Character_MAtk;
    private readonly InputAction m_Character_HAtk;
    private readonly InputAction m_Character_Block;
    private readonly InputAction m_Character_Dodge;
    private readonly InputAction m_Character_Move;
    private readonly InputAction m_Character_Dash;
    public struct CharacterActions
    {
        private PlayerControls m_Wrapper;
        public CharacterActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Character_Jump;
        public InputAction @LAtk => m_Wrapper.m_Character_LAtk;
        public InputAction @MAtk => m_Wrapper.m_Character_MAtk;
        public InputAction @HAtk => m_Wrapper.m_Character_HAtk;
        public InputAction @Block => m_Wrapper.m_Character_Block;
        public InputAction @Dodge => m_Wrapper.m_Character_Dodge;
        public InputAction @Move => m_Wrapper.m_Character_Move;
        public InputAction @Dash => m_Wrapper.m_Character_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                LAtk.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLAtk;
                LAtk.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLAtk;
                LAtk.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLAtk;
                MAtk.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMAtk;
                MAtk.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMAtk;
                MAtk.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMAtk;
                HAtk.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnHAtk;
                HAtk.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnHAtk;
                HAtk.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnHAtk;
                Block.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBlock;
                Block.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBlock;
                Block.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBlock;
                Dodge.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDodge;
                Dodge.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDodge;
                Dodge.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDodge;
                Move.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                Dash.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDash;
                Dash.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDash;
                Dash.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                LAtk.started += instance.OnLAtk;
                LAtk.performed += instance.OnLAtk;
                LAtk.canceled += instance.OnLAtk;
                MAtk.started += instance.OnMAtk;
                MAtk.performed += instance.OnMAtk;
                MAtk.canceled += instance.OnMAtk;
                HAtk.started += instance.OnHAtk;
                HAtk.performed += instance.OnHAtk;
                HAtk.canceled += instance.OnHAtk;
                Block.started += instance.OnBlock;
                Block.performed += instance.OnBlock;
                Block.canceled += instance.OnBlock;
                Dodge.started += instance.OnDodge;
                Dodge.performed += instance.OnDodge;
                Dodge.canceled += instance.OnDodge;
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Dash.started += instance.OnDash;
                Dash.performed += instance.OnDash;
                Dash.canceled += instance.OnDash;
            }
        }
    }
    public CharacterActions @Character => new CharacterActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.GetControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.GetControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ICharacterActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnLAtk(InputAction.CallbackContext context);
        void OnMAtk(InputAction.CallbackContext context);
        void OnHAtk(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
