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
    public GameObject piano;
    public GameObject hands;
    public GameObject cello;


    [Space]
    public UnityEvent onButtonClicked;

    bool init = true;
    int sourceIdx = 0;
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
        sourceIdx = (sourceIdx + 1) % 3;
        audioSource.Stop();

        piano.SetActive (sourceIdx == 0);
        cello.SetActive (sourceIdx == 1);
        hands.SetActive (sourceIdx == 2);

        audioSource.clip = audioClips[sourceIdx];
        audioSource.Play();
    }
}
