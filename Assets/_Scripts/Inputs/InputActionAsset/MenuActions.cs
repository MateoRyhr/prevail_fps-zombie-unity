//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/_Scripts/Inputs/InputActionAsset/MenuActions.inputactions
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

public partial class @MenuActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuActions"",
    ""maps"": [
        {
            ""name"": ""MenuActionMap"",
            ""id"": ""1c144686-7ada-4a47-ac48-9499ba4f7bae"",
            ""actions"": [
                {
                    ""name"": ""PauseOrResume"",
                    ""type"": ""Button"",
                    ""id"": ""93108d34-b1f4-4610-aecf-d03a2d00af2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa3c991f-b4eb-409d-a984-583162a501d6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseOrResume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MenuActionMap
        m_MenuActionMap = asset.FindActionMap("MenuActionMap", throwIfNotFound: true);
        m_MenuActionMap_PauseOrResume = m_MenuActionMap.FindAction("PauseOrResume", throwIfNotFound: true);
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

    // MenuActionMap
    private readonly InputActionMap m_MenuActionMap;
    private List<IMenuActionMapActions> m_MenuActionMapActionsCallbackInterfaces = new List<IMenuActionMapActions>();
    private readonly InputAction m_MenuActionMap_PauseOrResume;
    public struct MenuActionMapActions
    {
        private @MenuActions m_Wrapper;
        public MenuActionMapActions(@MenuActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseOrResume => m_Wrapper.m_MenuActionMap_PauseOrResume;
        public InputActionMap Get() { return m_Wrapper.m_MenuActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IMenuActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuActionMapActionsCallbackInterfaces.Add(instance);
            @PauseOrResume.started += instance.OnPauseOrResume;
            @PauseOrResume.performed += instance.OnPauseOrResume;
            @PauseOrResume.canceled += instance.OnPauseOrResume;
        }

        private void UnregisterCallbacks(IMenuActionMapActions instance)
        {
            @PauseOrResume.started -= instance.OnPauseOrResume;
            @PauseOrResume.performed -= instance.OnPauseOrResume;
            @PauseOrResume.canceled -= instance.OnPauseOrResume;
        }

        public void RemoveCallbacks(IMenuActionMapActions instance)
        {
            if (m_Wrapper.m_MenuActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuActionMapActions @MenuActionMap => new MenuActionMapActions(this);
    public interface IMenuActionMapActions
    {
        void OnPauseOrResume(InputAction.CallbackContext context);
    }
}
