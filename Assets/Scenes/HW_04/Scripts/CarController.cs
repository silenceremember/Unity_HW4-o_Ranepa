using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Wheel References")]
    [SerializeField] private GameObject wheelR1;
    [SerializeField] private GameObject wheelR2;
    [SerializeField] private GameObject wheelL1;
    [SerializeField] private GameObject wheelL2;

    [Header("Engine Settings")]
    [SerializeField] private float targetVelocity = 3500f;
    [SerializeField] private float motorForce = 3000f;

    private HingeJoint hingeFrontRight;
    private HingeJoint hingeFrontLeft;
    private HingeJoint hingeRearRight;
    private HingeJoint hingeRearLeft;

    private void Start()
    {
        hingeFrontRight = wheelR1.GetComponent<HingeJoint>();
        hingeFrontLeft = wheelL1.GetComponent<HingeJoint>();
        hingeRearRight = wheelR2.GetComponent<HingeJoint>();
        hingeRearLeft = wheelL2.GetComponent<HingeJoint>();

        ConfigureWheelMotor(hingeFrontRight);
        ConfigureWheelMotor(hingeFrontLeft);
        ConfigureWheelMotor(hingeRearRight);
        ConfigureWheelMotor(hingeRearLeft);
    }

    private void ConfigureWheelMotor(HingeJoint wheel)
    {
        var motor = wheel.motor;
        motor.force = 0;
        motor.targetVelocity = 0;
        motor.freeSpin = false;
        wheel.motor = motor;
        wheel.useMotor = true;
    }

    private void Update()
    {
        JointMotor motor = new JointMotor();

        if (Input.GetKey(KeyCode.W))
        {
            motor.targetVelocity = targetVelocity;
            motor.force = motorForce;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            motor.targetVelocity = -targetVelocity;
            motor.force = motorForce;
        }
        else
        {
            motor.targetVelocity = 0;
            motor.force = 0;
        }

        hingeFrontRight.motor = motor;
        hingeFrontLeft.motor = motor;
        hingeRearRight.motor = motor;
        hingeRearLeft.motor = motor;
    }
}