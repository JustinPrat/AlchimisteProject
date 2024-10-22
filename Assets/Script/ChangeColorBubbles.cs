using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ChangeColorBubbles : MonoBehaviour
{
    [SerializeField] VisualEffect _bubblesVFX;
    Gradient vfxGradient;
    void Start()
    {
        vfxGradient = _bubblesVFX.GetGradient("bubblesColor");
    }

    void Update()
    {
        vfxGradient.colorKeys[1].color = Color.blue;
    }
    public void ChangeColor()
    {

    }
}
