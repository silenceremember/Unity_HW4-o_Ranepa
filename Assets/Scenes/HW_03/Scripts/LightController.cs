using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _modifier = 1f;
    [SerializeField] private float _minIntensity = 0.5f;
    [SerializeField] private float _maxIntensity = 1.5f;
    
    private Light lightComponent;

    private void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    private void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * _speed, 0f);
        float normalizedIntensity = Mathf.Lerp(_minIntensity, _maxIntensity, noise);
        lightComponent.intensity = normalizedIntensity * _modifier;
    }
}