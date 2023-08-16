using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

// https://www.youtube.com/watch?v=wGvh7Suo1h4

public class TeleportController : MonoBehaviour
{
    public GameObject baseControllerGameObject;
    public GameObject teleportationGameObject;

    public InputActionReference teleportActivationReference;

    [Space]
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel; 

    // Start is called before the first frame update
    void Start()
    {
        teleportActivationReference.action.performed += TeleportModeActivate;
        teleportActivationReference.action.canceled += TeleportModeCancel;
    }

    private void TeleportModeCancel(InputAction.CallbackContext obj) => Invoke("DeactivateTeleporter", .1f);

    void DeactivateTeleporter() => onTeleportCancel.Invoke();

    private void TeleportModeActivate(InputAction.CallbackContext obj) => onTeleportActivate.Invoke();

}
