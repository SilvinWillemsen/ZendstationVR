using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using TMPro;
public class ChangeMaterialController : MonoBehaviour
{
    public GameObject ZenderZaalA;
    public GameObject ZenderZaalB;

    public InputActionReference AbuttonClick;
    public InputActionReference BbuttonClick;

    [Space]
    public UnityEvent onAButtonClicked;
    public UnityEvent onBButtonClicked;

    bool init = true;
    // Start is called before the first frame update
    void Start()
    {

        AbuttonClick.action.performed += ClickAButton;
        BbuttonClick.action.performed += ClickBButton;

        // Select material A to begin with
        //SelectMaterialA();
    }

    private void Update()
    {
        //if (init)
        //{
        //    SelectMaterialA();
        //    init = false;
        //}

    }

    private void ClickAButton(InputAction.CallbackContext obj) => onAButtonClicked.Invoke();
    private void ClickBButton(InputAction.CallbackContext obj) => onBButtonClicked.Invoke();

    public void SelectMaterialA()
    {
        ZenderZaalA.SetActive (true);
        ZenderZaalB.SetActive (false);
    }
    public void SelectMaterialB()
    {
        ZenderZaalA.SetActive (false);
        ZenderZaalB.SetActive (true);
    }

}
