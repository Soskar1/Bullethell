using UnityEngine;

[RequireComponent(typeof(Input))]
public class Player : MonoBehaviour
{
    private IMovement _movement;
    [SerializeField] private Jumping _jumping;
    [SerializeField] private Input _input;


    private void Awake()
    {
        _movement = GetComponent<IMovement>();
    }

    private void Start()
    {
        _input.controls.Player.Jump.performed += _jumping.TryJump;
    }

    private void FixedUpdate()
    {
        _movement.Move(_input.MovementInput);
    }

    private void OnDisable()
    {
        _input.controls.Player.Jump.performed -= _jumping.TryJump;
    }
}
