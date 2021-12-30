using UnityEngine;

public class Input : MonoBehaviour
{
    public Controls controls;

    private float _movementInput;
    public float MovementInput { get => _movementInput; }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
    private void Awake() => controls = new Controls();

    private void Update() => _movementInput = controls.Player.Movement.ReadValue<float>();

}
