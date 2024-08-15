//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Prefabs/Characters/PlayerActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""CombatActions"",
            ""id"": ""be5ace49-3844-4d0d-89c6-577c31caa796"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""587e62f4-865b-4a58-8437-b83756202846"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""df9bd194-6741-493d-8d3f-e30dced794e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""5dbd06f5-5a5d-4741-b3d7-5f49e649da88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpecialAttack"",
                    ""type"": ""Button"",
                    ""id"": ""8f4eba37-0263-4e4b-9317-c2d6a209d51f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Parry"",
                    ""type"": ""Button"",
                    ""id"": ""f90d5f02-e17d-4c3e-96d0-218ae702994c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard arrows"",
                    ""id"": ""e9e6890f-6b4c-4875-aa05-74b49d105eea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c2af016e-670d-45c0-9844-7cafe5791171"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d8c0e0a2-2098-4d79-90be-675db0a8e1a5"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""02e3c01a-f784-46cd-940e-f7e19fb0ad81"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ca84a209-9b50-4ad5-b002-da8427408462"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""887b3671-9ea8-4548-9372-24d1e2b710c4"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1166c5a5-4dd4-4815-893d-020071353ec7"",
                    ""path"": ""<Keyboard>/#(C)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2a4de18-e835-4707-989d-7320816d5ef6"",
                    ""path"": ""<Keyboard>/#(X)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpecialAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c7d73a3-2abe-4024-a061-e8b879c28df8"",
                    ""path"": ""<Keyboard>/#(Z)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Parry"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CombatActions
        m_CombatActions = asset.FindActionMap("CombatActions", throwIfNotFound: true);
        m_CombatActions_Movement = m_CombatActions.FindAction("Movement", throwIfNotFound: true);
        m_CombatActions_Dash = m_CombatActions.FindAction("Dash", throwIfNotFound: true);
        m_CombatActions_Attack = m_CombatActions.FindAction("Attack", throwIfNotFound: true);
        m_CombatActions_SpecialAttack = m_CombatActions.FindAction("SpecialAttack", throwIfNotFound: true);
        m_CombatActions_Parry = m_CombatActions.FindAction("Parry", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // CombatActions
    private readonly InputActionMap m_CombatActions;
    private List<ICombatActionsActions> m_CombatActionsActionsCallbackInterfaces = new List<ICombatActionsActions>();
    private readonly InputAction m_CombatActions_Movement;
    private readonly InputAction m_CombatActions_Dash;
    private readonly InputAction m_CombatActions_Attack;
    private readonly InputAction m_CombatActions_SpecialAttack;
    private readonly InputAction m_CombatActions_Parry;
    public struct CombatActionsActions
    {
        private @PlayerControls m_Wrapper;
        public CombatActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CombatActions_Movement;
        public InputAction @Dash => m_Wrapper.m_CombatActions_Dash;
        public InputAction @Attack => m_Wrapper.m_CombatActions_Attack;
        public InputAction @SpecialAttack => m_Wrapper.m_CombatActions_SpecialAttack;
        public InputAction @Parry => m_Wrapper.m_CombatActions_Parry;
        public InputActionMap Get() { return m_Wrapper.m_CombatActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActionsActions set) { return set.Get(); }
        public void AddCallbacks(ICombatActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_CombatActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CombatActionsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @SpecialAttack.started += instance.OnSpecialAttack;
            @SpecialAttack.performed += instance.OnSpecialAttack;
            @SpecialAttack.canceled += instance.OnSpecialAttack;
            @Parry.started += instance.OnParry;
            @Parry.performed += instance.OnParry;
            @Parry.canceled += instance.OnParry;
        }

        private void UnregisterCallbacks(ICombatActionsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @SpecialAttack.started -= instance.OnSpecialAttack;
            @SpecialAttack.performed -= instance.OnSpecialAttack;
            @SpecialAttack.canceled -= instance.OnSpecialAttack;
            @Parry.started -= instance.OnParry;
            @Parry.performed -= instance.OnParry;
            @Parry.canceled -= instance.OnParry;
        }

        public void RemoveCallbacks(ICombatActionsActions instance)
        {
            if (m_Wrapper.m_CombatActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICombatActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_CombatActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CombatActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CombatActionsActions @CombatActions => new CombatActionsActions(this);
    public interface ICombatActionsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSpecialAttack(InputAction.CallbackContext context);
        void OnParry(InputAction.CallbackContext context);
    }
}
