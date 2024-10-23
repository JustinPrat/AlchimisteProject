using UnityEngine;
using UnityEngine.Splines;

public class SplineAnimation : MonoBehaviour
{
    private SplineExtrude splineExtrude;

    private float startValue = 0.0f;
    private float endValue = 1.0f;
    private float lerpTime = 0.0f;
    private bool isAnimating = false;

    void Start()
    {
        splineExtrude = GetComponent<SplineExtrude>();

        if (splineExtrude == null)
        {
            Debug.LogError("SplineExtrude component not found on the GameObject.");
            return;
        }

        SetExtrusionRange(0.0f, 0.0f);
    }

    void Update()
    {
        if (Input.GetKey("g"))
        {
            lerpTime += Time.deltaTime;

            float newStartValue = Mathf.Lerp(0.0f, startValue, lerpTime);
            float newEndValue = Mathf.Lerp(0.0f, endValue, lerpTime);

            SetExtrusionRange(newStartValue, newEndValue);

            if (lerpTime >= 1.0f)
            {
                isAnimating = false;
            }
        }
    }
    void SetExtrusionRange(float start, float end)
    {
        splineExtrude.Range = new Vector2(start, end);
        //splineExtrude.start = start;
        //splineExtrude.end = end;
        splineExtrude.Rebuild();
    }

    public void StartExtrusionAnimation()
    {
        lerpTime = 0.0f;
        isAnimating = true;
    }
}