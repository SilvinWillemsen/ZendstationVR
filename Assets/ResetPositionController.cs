using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using TMPro;
public class ResetPositionController : MonoBehaviour
{
    public GameObject xrOrigin;
    public GameObject mainXRCamera;

    public TMP_Text holdText;
    public InputActionReference resetPositionReference;

    [Space]
    public UnityEvent onResetCounterStart;
    public UnityEvent onResetResetCounter;

    private bool shouldCount = false;
    private float curTime;
    public int countDown = 3;
    private Vector3 origCameraPos = new Vector3();
    private Vector3 origXROriginOffset = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        origXROriginOffset = xrOrigin.transform.position;
        origCameraPos = mainXRCamera.transform.position;

        resetPositionReference.action.performed += StartResetCounter;
        resetPositionReference.action.canceled += ResetResetCounter;

    }
    private void StartResetCounter(InputAction.CallbackContext obj) => onResetCounterStart.Invoke();

    private void ResetResetCounter(InputAction.CallbackContext obj) => onResetResetCounter.Invoke();

    void Update()
    {
        if (shouldCount)
        {
            if (Time.time - curTime > 0.5 * (3 - countDown))
            {
                if (countDown == 0)
                {
                    var distanceDiff = mainXRCamera.transform.position - origCameraPos;
                    xrOrigin.transform.position -= distanceDiff;
                    ResetResetCounter();
                    origCameraPos = mainXRCamera.transform.position;

                    return;
                }
                holdText.SetText (countDown.ToString());
                countDown--;

            }
        }
    }

    public void StartReset()
    {
        Debug.Log("Starting reset counter");
        shouldCount = true;
        countDown = 3;
        curTime = Time.time;
    }
    public void ResetResetCounter()
    {
        Debug.Log("Resetting reset counter");
        holdText.SetText("hold to go\nback to start");
        shouldCount = false;
        countDown = 3;
    }

}
