using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using TMPro;
public class ChangeSourceController : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips;
    public InputActionReference XbuttonClick;
    public InputActionReference YbuttonClick;

    [Space]
    public UnityEvent onButtonClicked;

    bool init = true;
    bool sourceIsPiano = true;
    // Start is called before the first frame update
    void Start()
    {

        XbuttonClick.action.performed += ClickButton;
        YbuttonClick.action.performed += ClickButton;

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

    private void ClickButton(InputAction.CallbackContext obj) => onButtonClicked.Invoke();
    public void ChangeSource()
    {
        sourceIsPiano = !sourceIsPiano;
        audioSource.Stop();
        if (sourceIsPiano)
            audioSource.clip = audioClips[0];
        else
            audioSource.clip = audioClips[1];
        audioSource.Play();
    }
}
