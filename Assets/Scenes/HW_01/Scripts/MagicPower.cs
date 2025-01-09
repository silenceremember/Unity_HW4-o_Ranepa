using UnityEngine;

public class MagicPower : MonoBehaviour
{
    [SerializeField] private float _magicForce = 5f;
    
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            
            switch (collision.gameObject.layer)
            {
                case 9: // Friendly
                    break;
                    
                case 10: // Enemy
                    rb.AddForce(direction * _magicForce, ForceMode.Impulse);
                    break;
            }
        }
    }
}