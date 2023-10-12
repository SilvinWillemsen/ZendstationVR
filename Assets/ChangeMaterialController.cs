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
    public GameObject ZenderZaalGlass;

    public InputActionReference AbuttonClick;
    public InputActionReference BbuttonClick;

    public GameObject scalePanels;

    [Space]
    public UnityEvent onButtonClicked;

    bool init = true;
    public int material = 0; // 0: absorbing, 1: reflecting, 2: glass

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
        material = (material + 1) % 2;
        ZenderZaalAbsorbing.SetActive(material == 0);
        ZenderZaalReflecting.SetActive(material == 1);
        ZenderZaalGlass.SetActive(material == 2);
        scalePanels.SetActive(material == 0);

    }
}
