using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private bool _rotateClockwise = true;
    
    private void Update()
    {
        float direction = _rotateClockwise ? -1f : 1f;
        transform.Rotate(Vector3.up * (_rotationSpeed * direction * Time.deltaTime));
    }
}