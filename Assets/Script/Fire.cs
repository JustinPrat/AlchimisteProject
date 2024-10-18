using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float fireValue;
    [SerializeField, Range(1, 10)] private float firePace;
    [SerializeField, Range(1, 100)] private float fireAddValue;

    void Update()
    {
        fireValue -= firePace * Time.deltaTime;
    }

    void AddFire()
    {
        fireValue += fireAddValue;
    }
}
