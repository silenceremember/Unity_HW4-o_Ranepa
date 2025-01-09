using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float distance = 3f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool startAtRight;

    private Vector3 startPosition;
    private float currentOffset;
    private int direction = 1;

    private void Start()
    {
        startPosition = transform.position;
        if (startAtRight)
        {
            currentOffset = distance;
            direction = -1;
        }
    }

    private void Update()
    {
        currentOffset += speed * direction * Time.deltaTime;

        if (currentOffset >= distance || currentOffset <= 0)
        {
            direction *= -1;
            currentOffset = Mathf.Clamp(currentOffset, 0, distance);
        }

        Vector3 newPosition = startPosition + Vector3.right * currentOffset;
        transform.position = newPosition;
    }
}