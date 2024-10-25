using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.VFX;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Sprite> itemSprites = new List<Sprite>();
    [SerializeField] protected Item itemPrefab;

    [SerializeField] protected ActionEvent actionEvent;
    [SerializeField] protected Transform chaudronTransform;
    [SerializeField] protected Transform waypointTransform;

    [SerializeField] protected IngredientType currentIngredientType;
    [SerializeField] protected float curveIntensity = 2;
    [SerializeField] protected VisualEffect dropVFX;
    [SerializeField] protected float timeToDrop = 2;

    [SerializeField] private SplineContainer spline;

    private Item currentIngredient;

    private void Start()
    {
        actionEvent.OnSTARTChangeIngredient += OnChangeIngredient;
    }

    private void OnDestroy()
    {
        actionEvent.OnSTARTChangeIngredient -= OnChangeIngredient;
    }

    private void OnChangeIngredient (IngredientType ingredient)
    {
        if (currentIngredientType == ingredient)
        {
            DoIngredientAnimation();
        }
    }

    private void DoIngredientAnimation ()
    {
        Item item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        currentIngredient = item;
        item.Setup(itemSprites[Random.Range(0, itemSprites.Count)], spline);
        item.PlayVFX(true);
        item.PlaySpline(PlayAfterDrop, timeToDrop);
    }

    private void PlayAfterDrop ()
    {
        if (currentIngredient == null) { return; }

        dropVFX.Play();
        currentIngredient.PlayVFX(false);
        currentIngredient.SpriteRenderer.DOFade(0, 0.5f).OnComplete(() =>
        {
            Destroy(currentIngredient.gameObject);
            actionEvent.OnENDChangeIngredient?.Invoke(currentIngredientType);
        });
    }
}
