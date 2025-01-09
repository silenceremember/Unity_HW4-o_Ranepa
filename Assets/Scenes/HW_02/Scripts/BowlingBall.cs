using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    [SerializeField] private float launchForce = 1000f;
    [SerializeField] private float randomRange = 100f;
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        float randomX = Random.Range(-randomRange, randomRange);
        
        rb.AddForce(randomX, 0, -launchForce);
    }
}