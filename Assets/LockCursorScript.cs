using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf)
            Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
