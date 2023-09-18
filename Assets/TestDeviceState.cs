using UnityEngine;
using UnityEngine.XR;
 
public class TestDeviceState : MonoBehaviour
{
    void Start()
    {
        InputDevices.deviceConnected += DeviceConnected;
        InputDevices.deviceDisconnected += DeviceDisconnected;
        InputDevices.deviceConfigChanged += ConfigChanged;
    }
 
    private void ConfigChanged(InputDevice inputDevice)
    {
        if ((inputDevice.characteristics & InputDeviceCharacteristics.HeadMounted) == InputDeviceCharacteristics.HeadMounted)
        {
            Debug.Log($"HMD Changed!");
        }
        else if ((inputDevice.characteristics & InputDeviceCharacteristics.HeldInHand) == InputDeviceCharacteristics.HeldInHand)
        {
            Debug.Log($"Controller Changed: {inputDevice.name} || {inputDevice.characteristics}");
        }
    }
 
    private void DeviceConnected(InputDevice inputDevice)
    {
        if ((inputDevice.characteristics & InputDeviceCharacteristics.HeadMounted) == InputDeviceCharacteristics.HeadMounted)
        {
            Debug.Log($"HMD Connected!");
        }
        else if ((inputDevice.characteristics & InputDeviceCharacteristics.HeldInHand) == InputDeviceCharacteristics.HeldInHand)
        {
            Debug.Log($"Controller Disconnected: {inputDevice.name} || {inputDevice.characteristics}");
        }
    }
 
    private void DeviceDisconnected(InputDevice inputDevice)
    {
        if ((inputDevice.characteristics & InputDeviceCharacteristics.HeadMounted) == InputDeviceCharacteristics.HeadMounted)
        {
            Debug.LogWarning($"HMD Disconnected!");
        }
        else if ((inputDevice.characteristics & InputDeviceCharacteristics.HeldInHand) == InputDeviceCharacteristics.HeldInHand)
        {
            Debug.LogWarning($"Controller Disconnected: {inputDevice.name} || {inputDevice.characteristics}");
        }
 
    }
}