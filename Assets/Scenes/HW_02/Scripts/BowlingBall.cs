using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    [SerializeField] private float _launchForce = 1000f;
    [SerializeField] private float _randomRange = 100f;
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        float randomX = Random.Range(-_randomRange, _randomRange);
        
        rb.AddForce(randomX, 0, -_launchForce);
    }
}