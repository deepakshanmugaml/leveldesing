using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleSwitcher : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    [Header("Cars")]
    public GameObject car1;
    public GameObject car2;

    [Header("Cameras")]
    public Camera playerCamera;
    public Camera car1Camera;
    public Camera car2Camera;

    private int currentMode = 0;

    void Start()
    {
        SetMode(0);
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            currentMode++;

            if (currentMode > 2)
                currentMode = 0;

            SetMode(currentMode);
        }
    }

    void SetMode(int mode)
    {
       

        if (player != null)
            player.SetActive(mode == 0);

        if (car1 != null)
            car1.SetActive(mode == 1);

        if (car2 != null)
            car2.SetActive(mode == 2);

        if (playerCamera != null)
            playerCamera.gameObject.SetActive(mode == 0);

        if (car1Camera != null)
            car1Camera.gameObject.SetActive(mode == 1);

        if (car2Camera != null)
            car2Camera.gameObject.SetActive(mode == 2);
    }
}