using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GroundCheck))]
[RequireComponent(typeof(Rigidbody2D))]
public class Jumping : MonoBehaviour
{
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private float _force;

    [SerializeField] private int _maxJumps;
    private int _jumpCount = 0;

    private void LateUpdate()
    {
        if (_groundCheck.Check())
            _jumpCount = 0;
    }

    public void TryJump(InputAction.CallbackContext ctx)
    {
        if (_groundCheck.Check() || _jumpCount > 0 && _jumpCount < _maxJumps)
        {
            _rb2d.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            _jumpCount++;
        }
    }
}
