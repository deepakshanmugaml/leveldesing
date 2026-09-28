using UnityEngine;
using UnityEngine.InputSystem;

public class TwoCarController : MonoBehaviour
{
    [Header("Car Controllers")]
    public MonoBehaviour car1Controller;
    public MonoBehaviour car2Controller;

    private bool car1Active = true;

    void Start()
    {
        SetCar1();
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        // Press E to switch car
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (car1Active)
                SetCar2();
            else
                SetCar1();
        }
    }

    void SetCar1()
    {
        car1Active = true;

        car1Controller.enabled = true;
        car2Controller.enabled = false;
    }

    void SetCar2()
    {
        car1Active = false;

        car1Controller.enabled = false;
        car2Controller.enabled = true;
    }
}