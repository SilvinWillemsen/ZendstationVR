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

    void Update()
    {
        if (fadingIn)
        {
            if (fadeInCounter / 24.0f >= 1.0f)
            {
                videoPlayer.targetCameraAlpha = 1.0f;
                fadingIn = false;
            }
            else
            {
                videoPlayer.targetCameraAlpha = fadeInCounter / 24.0f;
            }
            ++fadeInCounter;
        }
        if (fadingOut)
        {
            if (fadeOutCounter / 24.0f >= 1.0f)
            {
                videoPlayer.targetCameraAlpha = 0.0f;
                fadingOut = false;
                videoPlayer.Stop();
            }
            else
            {
                videoPlayer.targetCameraAlpha = 1.0f - fadeOutCounter / 24.0f;
            }
            ++fadeOutCounter;
        }

    }

    public void StartVideo()
    {
        videoPlayer.Play();
        fadingOut = false;
        fadeOutCounter = 0;

        fadingIn = true;
        fadeInCounter = 0;
    }


    public void StopVideo()
    {
        fadingIn = false;
        fadeInCounter = 0;

        fadingOut = true;
        fadeOutCounter = 0;
    }
}
