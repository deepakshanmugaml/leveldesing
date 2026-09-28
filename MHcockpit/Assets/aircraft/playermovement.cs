using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float runSpeed = 9f;

    [Header("Look")]
    public Transform playerCamera;
    public float mouseSensitivity = 0.15f;
    public float maxLookAngle = 85f;

    private CharacterController controller;
    private float cameraPitch = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Keyboard.current == null || Mouse.current == null)
            return;

        Move();
        Look();
    }

    void Move()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            input.y += 1;

        if (Keyboard.current.sKey.isPressed)
            input.y -= 1;

        if (Keyboard.current.dKey.isPressed)
            input.x += 1;

        if (Keyboard.current.aKey.isPressed)
            input.x -= 1;

        input = Vector2.ClampMagnitude(input, 1f);

        float speed = Keyboard.current.leftShiftKey.isPressed
            ? runSpeed
            : moveSpeed;

        Vector3 move =
            transform.right * input.x +
            transform.forward * input.y;

        controller.Move(
            move * speed * Time.deltaTime
        );
    }

    void Look()
    {
        Vector2 mouseDelta =
            Mouse.current.delta.ReadValue();

        float mouseX =
            mouseDelta.x * mouseSensitivity;

        float mouseY =
            mouseDelta.y * mouseSensitivity;

        // Look left/right
        transform.Rotate(
            Vector3.up * mouseX
        );

        // Look up/down
        cameraPitch -= mouseY;

        cameraPitch = Mathf.Clamp(
            cameraPitch,
            -maxLookAngle,
            maxLookAngle
        );

        playerCamera.localRotation =
            Quaternion.Euler(
                cameraPitch,
                0f,
                0f
            );
    }
}