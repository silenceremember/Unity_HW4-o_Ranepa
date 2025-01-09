using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float _restPosition = 0f;
    [SerializeField] private float _pressedPosition = 45f;
    [SerializeField] private float _hitStrength = 10000f;
    [SerializeField] private float _flipperDamper = 150f;
    [SerializeField] private float _stateChangeInterval = 1.5f;

    private HingeJoint hinge;
    private float timer;
    private bool isPressed;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
        timer = 0f;
        isPressed = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= _stateChangeInterval)
        {
            isPressed = !isPressed;
            timer = 0f;
        }

        JointSpring spring = new JointSpring
        {
            spring = _hitStrength,
            damper = _flipperDamper,
            targetPosition = isPressed ? _pressedPosition : _restPosition
        };

        hinge.spring = spring;
    }
}