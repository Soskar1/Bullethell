using Core;
using Core.UI;
using UnityEngine;

namespace Entity.MainCharacter
{
    [RequireComponent(typeof(Jumping))]
    [RequireComponent(typeof(Flipping))]
    [RequireComponent(typeof(PlayerShooting))]
    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour
    {
        public int playableCharacterId;

        private IMovement _movement;
        [SerializeField] private Jumping _jumping;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Flipping _flipping;
        [SerializeField] private PlayerShooting _shooting;
        [SerializeField] private Animator _animator;

        [SerializeField] private Game _game;
        [SerializeField] private Counter _deathCounter;
        [SerializeField] private GameObject _gameOver;

        private void Awake() => _movement = GetComponent<IMovement>();

        private void OnEnable()
        {
            _gameOver.SetActive(false);

            _input.controls.Player.Jump.performed += _jumping.TryJump;
            _input.controls.Player.Shoot.performed += _shooting.TryShoot;
            _input.controls.Player.Shoot.canceled += _shooting.TryShoot;
        }

        private void OnDisable()
        {
            _input.controls.Player.Jump.performed -= _jumping.TryJump;
            _input.controls.Player.Shoot.performed -= _shooting.TryShoot;
            _input.controls.Player.Shoot.canceled -= _shooting.TryShoot;

            _deathCounter.Add();
            _gameOver.SetActive(true);
        }

        private void Update()
        {
            if (_input.MovementInput > 0 && !_flipping.FacingRight ||
                _input.MovementInput < 0 && _flipping.FacingRight)
                _flipping.Flip();

            _animator.SetFloat("Speed", Mathf.Abs(_input.MovementInput));
        }

        private void FixedUpdate() => _movement.Move(_input.MovementInput);
    }
}