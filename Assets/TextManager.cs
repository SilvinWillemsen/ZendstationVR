using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text teleportText;
    [SerializeField] private TMP_Text teleportArrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTeleportActivate()
    {
        teleportText.color = Color.cyan;
        teleportArrow.color = Color.cyan;

        teleportText.SetText("point down");
        Debug.Log("Teleport activate!");

    }

    public void OnSelectEntered()
    {
        teleportText.color = Color.green;
        teleportArrow.color = Color.green;

        teleportText.SetText("release");
        Debug.Log("Select entered!");

    }

    //public void OnSelectExited()
    //{
    //}

    public void OnTeleportDeactivate()
    {
        teleportText.color = Color.green;
        teleportArrow.color = Color.green;

        teleportText.SetText("teleport");

        Debug.Log("Teleport deactivated!");
    }
    //public void OnHoverCallback()
    //{
    //    //teleportText.SetText("release");
    //}

    public void OnHoverExitCallback()
    {
        teleportText.color = Color.cyan;
        teleportArrow.color = Color.cyan;

        teleportText.SetText("point down");
        Debug.Log("Hover exit!");

        //teleportText.SetText("point down");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
