using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class SplineAnimation : MonoBehaviour
{
    [SerializeField] private SplineExtrude splineExtrude;
    [SerializeField] private ActionEvent inputs;

    private float startValue = 1.0f;
    private float endValue = 1.0f;
    private float lerpTime = 0.0f;

    void Start()
    {
        if (splineExtrude == null)
        {
            Debug.LogError("SplineExtrude component not found on the GameObject.");
            return;
        }

        SetExtrusionRange(0.0f, 0.0f);
    }

    public void DoAnimation (PotionType type)
    {
        StartCoroutine(MoveLiquid(type));
    }

    private IEnumerator MoveLiquid (PotionType type)
    {
        while (lerpTime <= 1)
        {
            //float newStartValue = Mathf.Lerp(0.0f, startValue, lerpTime);
            float newEndValue = Mathf.Lerp(0.0f, endValue, lerpTime);
            SetExtrusionRange(0, newEndValue);
            lerpTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        ResetExtrusionAnimation();

        while (lerpTime <= 1)
        {
            float newStartValue = Mathf.Lerp(0.0f, startValue, lerpTime);
            SetExtrusionRange(newStartValue, 1);
            lerpTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        ResetExtrusionAnimation();
        inputs.OnENDChangePotion?.Invoke(type);
    }

    void SetExtrusionRange(float start, float end)
    {
        splineExtrude.Range = new Vector2(start, end);
        splineExtrude.Rebuild();
    }

    public void ResetExtrusionAnimation()
    {
        lerpTime = 0.0f;
    }
}