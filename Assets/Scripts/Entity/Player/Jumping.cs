using UnityEngine;
using UnityEngine.InputSystem;

namespace Entity.MainCharacter
{
    [RequireComponent(typeof(GroundCheck))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumping : MonoBehaviour
    {
        [SerializeField] private GroundCheck _groundCheck;
        [SerializeField] private Rigidbody2D _rb2d;
        [SerializeField] private float _force;

        [SerializeField] private int _maxExtraJumps;
        private int _extraJumpCount = 0;

        private void LateUpdate()
        {
            if (_extraJumpCount > 0)
                if (_groundCheck.Check())
                    _extraJumpCount = 0;
        }

        public void TryJump(InputAction.CallbackContext ctx)
        {
            if (_groundCheck.Check() || _extraJumpCount < _maxExtraJumps)
            {
                _rb2d.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                _extraJumpCount++;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<ExtraJump>() != null)
                collision.GetComponent<ExtraJump>().AddExtraJump(ref _extraJumpCount);
        }
    }
}