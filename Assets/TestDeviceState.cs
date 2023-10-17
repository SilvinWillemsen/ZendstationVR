using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class TestDeviceState : MonoBehaviour
{
    public GameObject mainCamera;
    public VideoController videoController;

    public XRDisplaySubsystem system;

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
        Application.runInBackground = true;
        //Debug.Log("Active = " + XRSettings.isDeviceActive);
        //Debug.Log("Enabled = " + XRSettings.enabled);

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
                //XRDevice.DisableAutoXRCameraTracking (mainCamera.GetComponent<Camera>(), false);
                //XRSettings.enabled = true;
                //XRGeneralSettings.Instance.Manager.InitializeLoader();
                //XRGeneralSettings.Instance.Manager.StartSubsystems();

                List<XRDisplaySubsystem> xrDisplaySubsystems = new List<XRDisplaySubsystem>();
                SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);

                if (xrDisplaySubsystems.Count != 0)
                    xrDisplaySubsystems[0].Start();

                videoController.StopVideo();
                hmdJustOff = false;
                hmdOff = false;
            }
        }

        if (Time.time - time > 3 && hmdJustOff)
        {
            Debug.Log("HMD is off!!");

            List<XRDisplaySubsystem> xrDisplaySubsystems = new List<XRDisplaySubsystem>();
            SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);

            if (xrDisplaySubsystems.Count != 0)
                xrDisplaySubsystems[0].Stop();

            videoController.StartVideo();
            hmdJustOff = false;
            hmdOff = true;
        }
        lastPosition = mainCamera.transform.position;

    }
}