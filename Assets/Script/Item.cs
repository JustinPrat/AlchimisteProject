using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Item : MonoBehaviour
{
    [SerializeField] private List<VisualEffect> visualEffects;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public SpriteRenderer SpriteRenderer => spriteRenderer;

    public void PlayVFX ()
    {
        foreach (VisualEffect vfx in visualEffects)
        {
            vfx.Play();
        }
    }

    public void SetSprite (Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
