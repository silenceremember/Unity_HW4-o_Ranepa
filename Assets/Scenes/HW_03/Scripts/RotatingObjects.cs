using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private bool rotateClockwise = true;
    
    private void Update()
    {
        float direction = rotateClockwise ? -1f : 1f;
        transform.Rotate(Vector3.up * (rotationSpeed * direction * Time.deltaTime));
    }
}