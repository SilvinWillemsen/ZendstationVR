using UnityEngine;
using UnityEngine.XR;

public class TestDeviceState : MonoBehaviour
{
    public GameObject mainCamera;

    private Vector3 lastPosition = new Vector3();
    private bool hmdOff = true;
    private bool hmdJustOff = false;
    float time = 0; 
    void Start()
    {
        lastPosition = mainCamera.transform.position;
    }

    void Update()
    {
        if (mainCamera.transform.position == lastPosition)
        {
            if (!hmdJustOff && !hmdOff)
            {
                time = Time.time;
                hmdJustOff = true;
            }
        }
        else
        {
            if (hmdJustOff)
            {
                hmdJustOff = false;
                Debug.Log ("HMD off-taking cancelled..");
            }

            if (hmdOff)
            {
                Debug.Log ("HMD is on again!");
                hmdJustOff = false;
                hmdOff = false;
            }
        }

        if (Time.time - time > 3 && hmdJustOff)
        {
            Debug.Log ("HMD is off!!");
            hmdJustOff = false;
            hmdOff = true;
        }
        lastPosition = mainCamera.transform.position;

    }
}