// GENERATED AUTOMATICALLY FROM 'Assets/Settings/GyroControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GyroControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GyroControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GyroControls"",
    ""maps"": [
        {
            ""name"": ""Gyro"",
            ""id"": ""644fb5d3-4d72-4993-9a8b-28d3898bc6dc"",
            ""actions"": [
                {
                    ""name"": ""Attitude"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bdebccd9-dec9-45a0-bcd9-463648852558"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b249b34-e4f7-48dc-9864-8e47e574a766"",
                    ""path"": ""<AttitudeSensor>/attitude"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gyro
        m_Gyro = asset.FindActionMap("Gyro", throwIfNotFound: true);
        m_Gyro_Attitude = m_Gyro.FindAction("Attitude", throwIfNotFound: true);
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

    // Gyro
    private readonly InputActionMap m_Gyro;
    private IGyroActions m_GyroActionsCallbackInterface;
    private readonly InputAction m_Gyro_Attitude;
    public struct GyroActions
    {
        private @GyroControls m_Wrapper;
        public GyroActions(@GyroControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attitude => m_Wrapper.m_Gyro_Attitude;
        public InputActionMap Get() { return m_Wrapper.m_Gyro; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GyroActions set) { return set.Get(); }
        public void SetCallbacks(IGyroActions instance)
        {
            if (m_Wrapper.m_GyroActionsCallbackInterface != null)
            {
                @Attitude.started -= m_Wrapper.m_GyroActionsCallbackInterface.OnAttitude;
                @Attitude.performed -= m_Wrapper.m_GyroActionsCallbackInterface.OnAttitude;
                @Attitude.canceled -= m_Wrapper.m_GyroActionsCallbackInterface.OnAttitude;
            }
            m_Wrapper.m_GyroActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attitude.started += instance.OnAttitude;
                @Attitude.performed += instance.OnAttitude;
                @Attitude.canceled += instance.OnAttitude;
            }
        }
    }
    public GyroActions @Gyro => new GyroActions(this);
    public interface IGyroActions
    {
        void OnAttitude(InputAction.CallbackContext context);
    }
}
