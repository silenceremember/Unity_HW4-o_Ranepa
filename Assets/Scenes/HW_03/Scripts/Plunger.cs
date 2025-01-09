using UnityEngine;

public class Plunger : MonoBehaviour
{
    [SerializeField] private float _minForce = 500f;
    [SerializeField] private float _maxForce = 1500f;
    [SerializeField] private float _launchDelay = 1f;
    
    private Rigidbody currentBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            currentBall = other.GetComponent<Rigidbody>();
            if (currentBall != null)
            {
                Invoke(nameof(LaunchBall), _launchDelay);
            }
        }
    }

    private void LaunchBall()
    {
        if (currentBall != null)
        {
            float randomForce = Random.Range(_minForce, _maxForce);
            currentBall.AddForce(Vector3.forward * randomForce, ForceMode.Impulse);
            currentBall = null;
        }
    }
}