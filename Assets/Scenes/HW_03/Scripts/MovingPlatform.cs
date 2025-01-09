using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _distance = 3f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private bool _startAtRight;

    private Vector3 startPosition;
    private float currentOffset;
    private int direction = 1;

    private void Start()
    {
        startPosition = transform.position;
        if (_startAtRight)
        {
            currentOffset = _distance;
            direction = -1;
        }
    }

    private void Update()
    {
        currentOffset += _speed * direction * Time.deltaTime;

        if (currentOffset >= _distance || currentOffset <= 0)
        {
            direction *= -1;
            currentOffset = Mathf.Clamp(currentOffset, 0, _distance);
        }

        Vector3 newPosition = startPosition + Vector3.right * currentOffset;
        transform.position = newPosition;
    }
}