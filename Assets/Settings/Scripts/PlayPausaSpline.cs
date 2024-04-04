using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PlayPausaSpline : MonoBehaviour
{
    public SplineAnimate splineAnimate;

    public void PlayPause()
    {
        if (splineAnimate.IsPlaying)
        {
            splineAnimate.Pause();
        }
        else
        {
            splineAnimate.Play();
        }
    }
}
