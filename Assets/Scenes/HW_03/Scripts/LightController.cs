using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float modifier = 1f;
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 1.5f;
    
    private Light lightComponent;

    private void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    private void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * speed, 0f);
        float normalizedIntensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        lightComponent.intensity = normalizedIntensity * modifier;
    }
}