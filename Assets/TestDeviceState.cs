using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TestDeviceState : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject xrOrigin;

    public VideoController videoController;
    public ChangeSourceController sourceController;
    public ChangeMaterialController materialController;

    public XRDisplaySubsystem system;
    public BalconyToggle resetPosition;

    private Vector3 lastPosition = new Vector3();
    private bool hmdOff = false;
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
                ResetInteractions();

                ///// Not necessary, pretty sure that Oculus does this by itself /////
                List<XRDisplaySubsystem> xrDisplaySubsystems = new List<XRDisplaySubsystem>();
                SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);
                if (xrDisplaySubsystems.Count != 0)
                    xrDisplaySubsystems[0].Start();
                /////


                videoController.StopVideo();

                hmdJustOff = false;
                hmdOff = false;
            }
        }

        if (Time.time - time > 3 && hmdJustOff)
        {
            Debug.Log("HMD is off!!");

            sourceController.StopPlaying();
            videoController.StartVideo();

            List<XRDisplaySubsystem> xrDisplaySubsystems = new List<XRDisplaySubsystem>();
            SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);

            if (xrDisplaySubsystems.Count != 0)
                xrDisplaySubsystems[0].Stop();

            mainCamera.GetComponent<Camera>().fieldOfView = 60.0f;

            hmdJustOff = false;
            hmdOff = true;
        }
        lastPosition = mainCamera.transform.position;

    }

    public void ResetInteractions()
    {
        resetPosition.TogglePosition(true);
        sourceController.SetSource(0);
        materialController.SetMaterial(0);
        xrOrigin.transform.eulerAngles = new Vector3(0, -180, 0);
    }
}