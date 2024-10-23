using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Sprite> itemSprites = new List<Sprite>();
    [SerializeField] protected Item itemPrefab;

    [SerializeField] protected ActionEvent actionEvent;
    [SerializeField] protected Transform chaudronTransform;

    [SerializeField] protected IngredientType currentIngredientType;
    [SerializeField] protected float curveIntensity = 2;
    [SerializeField] protected VisualEffect dropVFX;
    [SerializeField] protected float timeToDrop = 2;

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

    public void DoIngredientAnimation()
    {
        Item item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        item.SetSprite(itemSprites[Random.Range(0, itemSprites.Count)]);
        item.PlayVFX();
        //item.transform.DOMove(chaudronTransform.position, 4).SetEase(Ease.InOutSine);
        Debug.Log("chauldron = " + chaudronTransform.position + " / Intermediaire = " + new Vector3(chaudronTransform.position.x, transform.position.y));

        Vector3[] arrayWaypoints = new Vector3[3];
        arrayWaypoints[0] = chaudronTransform.position;

        Vector3 middleDirection = (chaudronTransform.position - transform.position) / 2;
        Vector3 middlePoint = transform.position + middleDirection;
        Vector3 toChaudronDirection = middlePoint - chaudronTransform.position;
        Vector3 rotatedDirection = Quaternion.Euler(0, 0, -90) * toChaudronDirection;

        if (chaudronTransform.position.x < transform.position.x)
        {
            rotatedDirection = -rotatedDirection;
        }

        arrayWaypoints[1] = middlePoint + rotatedDirection.normalized * curveIntensity;
        arrayWaypoints[2] = middlePoint + rotatedDirection.normalized * curveIntensity;

        //Debug.DrawRay(middlePoint, -rotatedDirection, Color.yellow, 3);

        item.transform.DOPath(arrayWaypoints, timeToDrop, pathType: PathType.CubicBezier, pathMode: PathMode.Ignore).SetEase(Ease.InSine).OnComplete(() =>
        {
            dropVFX.Play();

            item.SpriteRenderer.DOFade(0, 0.5f).OnComplete(() =>
            {
                Destroy(item.gameObject);
                actionEvent.OnENDChangeIngredient?.Invoke(currentIngredientType);
            });
        });
    }
}
