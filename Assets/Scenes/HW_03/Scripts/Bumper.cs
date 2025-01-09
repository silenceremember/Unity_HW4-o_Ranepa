using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 1000f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                Vector3 bounceDirection = (collision.transform.position - transform.position).normalized;
                ballRb.AddForce(bounceDirection * _bounceForce, ForceMode.Impulse);
            }
        }
    }
}