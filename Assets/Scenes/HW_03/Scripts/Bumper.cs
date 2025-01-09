using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float bounceForce = 1000f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 12) // Ball
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                Vector3 bounceDirection = (collision.transform.position - transform.position).normalized;
                ballRb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
            }
        }
    }
}