using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.VFX;

public class Item : MonoBehaviour
{
    [SerializeField] private List<VisualEffect> visualEffects;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SplineAnimate splineAnimate;

    public SpriteRenderer SpriteRenderer => spriteRenderer;

    public void PlayVFX (bool playing)
    {
        foreach (VisualEffect vfx in visualEffects)
        {
            if (playing)
            {
                vfx.Play();
            }
            else
            {
                vfx.gameObject.SetActive(false);
            }
        }
    }

    public void Setup(Sprite sprite, SplineContainer spline)
    {
        spriteRenderer.sprite = sprite;
        splineAnimate.Container = spline;
    }

    public void PlaySpline (Action callback, float time)
    {
        splineAnimate.Duration = time;
        splineAnimate.Play();
        splineAnimate.Completed += callback;
    }
}
