using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR;

public class VideoController : MonoBehaviour
{
    VideoPlayer videoPlayer;

    bool fadingIn = false;
    bool fadingOut = false;
    int fadeInCounter = 0;
    int fadeOutCounter = 0;
    float fadeInSec = 1;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Application.runInBackground = true;
    //}

    void FixedUpdate()
    {
        if (fadingIn)
        {
            if (fadeInSec * fadeInCounter / 50.0f >= 1.0f)
            {
                videoPlayer.targetCameraAlpha = 1.0f;
                fadingIn = false;
            }
            else
            {
                videoPlayer.targetCameraAlpha = fadeInSec * fadeInCounter / 50.0f;
            }
            ++fadeInCounter;
        }
    }

    public void StartVideo()
    {
        videoPlayer.Play();

        fadingIn = true;
        fadeInCounter = 0;
    }


    public void StopVideo()
    {
        fadingIn = false;
        fadeInCounter = 0;

        videoPlayer.Stop();

    }
}
