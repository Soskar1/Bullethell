using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : Shooting
{
    private bool _held = false;
    
    [SerializeField] private float _maxTime;
    private float _timer;

    private void Update()
    {
        if (_held)
        { 
            if (_timer <= 0)
            {
                Shoot();
                _timer = _maxTime;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    public void TryShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            _held = true;
        if (ctx.canceled)
            _held = false;
    }
}
