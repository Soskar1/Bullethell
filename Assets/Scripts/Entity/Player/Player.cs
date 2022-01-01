using Core;
using UnityEngine;

namespace Entity.MainCharacter
{
    [RequireComponent(typeof(Jumping))]
    [RequireComponent(typeof(Flipping))]
    [RequireComponent(typeof(PlayerShooting))]
    public class Player : MonoBehaviour
    {
        private IMovement _movement;
        [SerializeField] private Jumping _jumping;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Flipping _flipping;
        [SerializeField] private PlayerShooting _shooting;
        [SerializeField] private Game _game;

        private void Awake() => _movement = GetComponent<IMovement>();

        private void Start() => _input.controls.Player.Restart.performed += _game.Restart;

        private void OnEnable()
        {
            _input.controls.Player.Jump.performed += _jumping.TryJump;
            _input.controls.Player.Shoot.performed += _shooting.TryShoot;
            _input.controls.Player.Shoot.canceled += _shooting.TryShoot;
        }

        private void OnDisable()
        {
            _input.controls.Player.Jump.performed -= _jumping.TryJump;
            _input.controls.Player.Shoot.performed -= _shooting.TryShoot;
            _input.controls.Player.Shoot.canceled -= _shooting.TryShoot;
        }

        private void Update()
        {
            if (_input.MovementInput > 0 && !_flipping.FacingRight ||
                _input.MovementInput < 0 && _flipping.FacingRight)
                _flipping.Flip();
        }

        private void FixedUpdate() => _movement.Move(_input.MovementInput);
    }
}