using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PotionSpawner : MonoBehaviour
{
    [SerializeField] private ActionEvent actionEvent;

    [SerializeField] private PotionType currentPotionType;
    [SerializeField] private SplineAnimation splineAnimation;

    private void Start()
    {
        actionEvent.OnSTARTChangePotion += OnChangePotion;
    }

    private void OnDestroy()
    {
        actionEvent.OnSTARTChangePotion -= OnChangePotion;
    }

    private void OnChangePotion(PotionType potion)
    {
        if (currentPotionType == potion)
        {
            splineAnimation.DoAnimation(currentPotionType);
        }
    }

}
