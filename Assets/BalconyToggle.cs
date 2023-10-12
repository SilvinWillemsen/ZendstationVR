using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using TMPro;
public class BalconyToggle : MonoBehaviour
{
    public GameObject xrOrigin;
    public GameObject mainXRCamera;

    public GameObject balconyOrigin;

    public GameObject groundTeleportation;
    public GameObject balconyTeleportation;

    public TMP_Text toggleText;
    public InputActionReference togglePositionReference;

    [Space]
    public UnityEvent onTogglePosition;

    private Vector3 origCameraPos = new Vector3();
    private Vector3 origXROriginOffset = new Vector3();

    private Vector3 balconyPos = new Vector3();

    bool isDown = true;
    // Start is called before the first frame update
    void Start()
    {
        origXROriginOffset = xrOrigin.transform.position;
        origCameraPos = mainXRCamera.transform.position;
        balconyPos = balconyOrigin.transform.position;

        togglePositionReference.action.performed += TriggerTogglePosition;

    }
    private void TriggerTogglePosition(InputAction.CallbackContext obj) => onTogglePosition.Invoke();

    void Update()
    {
    }

    public void TogglePosition()
    {
        isDown = !isDown;
        if (isDown)
        {
            var distanceDiff = mainXRCamera.transform.position - origCameraPos;
            xrOrigin.transform.position -= distanceDiff; 
            origCameraPos = mainXRCamera.transform.position;
            toggleText.text = "go to\nbalcony";
        }
        else
        {
            var distanceDiff = mainXRCamera.transform.position - balconyPos;
            xrOrigin.transform.position -= distanceDiff;
            balconyPos = mainXRCamera.transform.position;
            toggleText.text = "go to\nground floor";

        }
        groundTeleportation.SetActive (!isDown);
        balconyTeleportation.SetActive (isDown);

    }
}
