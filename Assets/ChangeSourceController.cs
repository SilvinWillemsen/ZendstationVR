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
    public UnityEvent onXButtonClicked;
    public UnityEvent onYButtonClicked;

    bool init = true;
    // Start is called before the first frame update
    void Start()
    {

        XbuttonClick.action.performed += ClickXButton;
        YbuttonClick.action.performed += ClickYButton;

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

    private void ClickXButton(InputAction.CallbackContext obj) => onXButtonClicked.Invoke();
    private void ClickYButton(InputAction.CallbackContext obj) => onYButtonClicked.Invoke();

    public void SelectSourceX()
    {
        audioSource.Stop();
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    public void SelectSourceY()
    {
        audioSource.Stop();
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

}
