using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float restPosition = 0f;
    [SerializeField] private float pressedPosition = 45f;
    [SerializeField] private float hitStrength = 10000f;
    [SerializeField] private float flipperDamper = 150f;
    [SerializeField] private float stateChangeInterval = 1.5f;

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

        if (timer >= stateChangeInterval)
        {
            isPressed = !isPressed;
            timer = 0f;
        }

        JointSpring spring = new JointSpring
        {
            spring = hitStrength,
            damper = flipperDamper,
            targetPosition = isPressed ? pressedPosition : restPosition
        };

        hinge.spring = spring;
    }
}