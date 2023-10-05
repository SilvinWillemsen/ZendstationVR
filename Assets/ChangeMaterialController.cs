using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using TMPro;
public class ChangeMaterialController : MonoBehaviour
{
    public GameObject ZenderZaalAbsorbing;
    public GameObject ZenderZaalReflecting;

    public InputActionReference AbuttonClick;
    public InputActionReference BbuttonClick;

public GameObject scalePanels;

    [Space]
    public UnityEvent onButtonClicked;

    bool init = true;
    bool panelsOn = true;
    // Start is called before the first frame update
    void Start()
    {

        AbuttonClick.action.performed += ClickButton;
        BbuttonClick.action.performed += ClickButton;

        // Select material A to begin with
        //SelectMaterialA();
    }

    private void Update()
    {
        // if (init)
        // {
        //    SelectMaterialA();
        //    init = false;
        // }

    }

    private void ClickButton(InputAction.CallbackContext obj) => onButtonClicked.Invoke();

    public void ChangeMaterial()
    {
        panelsOn = !panelsOn;
        ZenderZaalAbsorbing.SetActive (panelsOn);
        ZenderZaalReflecting.SetActive (!panelsOn);
        scalePanels.SetActive (panelsOn);

    }
}
