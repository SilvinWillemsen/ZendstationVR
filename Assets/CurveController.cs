using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CurveController : MonoBehaviour
{
    public GameObject baseController;
    public XRRayInteractor xRRayInteractor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Repeat(baseController.transform.eulerAngles.x + 180.0f, 360.0f) - 180.0f;

        float startTransitionAngle = 10.0f;
        float endTransitionAngle = 12.5f;
        float endPointHeight1 = -7.5f;
        float endPointHeight2 = 6.5f;

        // Debug.Log(angle);
        if (angle < startTransitionAngle)
        {
            xRRayInteractor.endPointHeight = endPointHeight2;
        } else if (angle < endTransitionAngle)
        {
            // Debug.Log("set endpoint height to 6.0");
            xRRayInteractor.endPointHeight = endPointHeight2 - (endPointHeight2 - endPointHeight1) * (angle - startTransitionAngle) / (endTransitionAngle - startTransitionAngle); //-7.5f - (angle + 0.0f);
        } else {
            // Debug.Log("set endpoint height to -7.5");
            xRRayInteractor.endPointHeight = endPointHeight1;
        }
    }
}
