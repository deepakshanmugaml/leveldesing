using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    [Header("Car Settings")]
    public float acceleration = 20f;
    public float maxSpeed = 25f;
    public float reverseSpeed = 10f;
    public float turnSpeed = 80f;
    public float brakePower = 30f;

    [Header("Flying")]
    public float flySpeed = 10f;

    private float currentSpeed = 0f;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
            return;

        // =========================
        // FORWARD
        // W
        // =========================

        if (keyboard.wKey.isPressed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        // =========================
        // REVERSE
        // S
        // =========================

        if (keyboard.sKey.isPressed)
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }

        // =========================
        // NATURAL FRICTION
        // =========================

        if (!keyboard.wKey.isPressed &&
            !keyboard.sKey.isPressed)
        {
            currentSpeed = Mathf.MoveTowards(
                currentSpeed,
                0f,
                10f * Time.deltaTime
            );
        }

        currentSpeed = Mathf.Clamp(
            currentSpeed,
            -reverseSpeed,
            maxSpeed
        );

        // =========================
        // STEERING
        // A / D
        // =========================

        float steering = 0f;

        if (keyboard.aKey.isPressed)
            steering = -1f;

        if (keyboard.dKey.isPressed)
            steering = 1f;

        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            float direction = currentSpeed >= 0 ? 1f : -1f;

            transform.Rotate(
                0f,
                steering * turnSpeed *
                direction *
                Time.deltaTime,
                0f
            );
        }

        // =========================
        // BRAKE
        // SPACE
        // =========================

        if (keyboard.spaceKey.isPressed)
        {
            currentSpeed = Mathf.MoveTowards(
                currentSpeed,
                0f,
                brakePower * Time.deltaTime
            );
        }

        // =========================
        // CAR MOVEMENT
        // =========================

        transform.position +=
            transform.forward *
            currentSpeed *
            Time.deltaTime;

        // =========================
        // FLY UP
        // UP ARROW
        // =========================

        if (keyboard.upArrowKey.isPressed)
        {
            transform.position +=
                Vector3.up *
                flySpeed *
                Time.deltaTime;
        }

        // =========================
        // FLY DOWN
        // DOWN ARROW
        // =========================

        if (keyboard.downArrowKey.isPressed)
        {
            transform.position -=
                Vector3.up *
                flySpeed *
                Time.deltaTime;
        }
    }
}