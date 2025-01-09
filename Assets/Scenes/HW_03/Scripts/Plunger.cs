using UnityEngine;

public class Plunger : MonoBehaviour
{
    [SerializeField] private float minForce = 500f;
    [SerializeField] private float maxForce = 1500f;
    [SerializeField] private float launchDelay = 1f;
    
    private Rigidbody currentBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            currentBall = other.GetComponent<Rigidbody>();
            if (currentBall != null)
            {
                Invoke(nameof(LaunchBall), launchDelay);
            }
        }
    }

    private void LaunchBall()
    {
        if (currentBall != null)
        {
            float randomForce = Random.Range(minForce, maxForce);
            currentBall.AddForce(Vector3.forward * randomForce, ForceMode.Impulse);
            currentBall = null;
        }
    }
}