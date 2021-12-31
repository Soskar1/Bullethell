using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : Shooting
{
    private bool _held = false;

    [Header("Projectiles")]
    [SerializeField] private int _maxProjectiles = 5;
    private int _currentProjectilesCount = 0;

    [Header("Delay")]
    [SerializeField] private float _delay;
    private float _timer;

    private void Update()
    {
        if (_held)
        { 
            if (_timer <= 0)
            {
                if (_currentProjectilesCount < _maxProjectiles)
                {
                    Shoot(ReduceProjectileCount);
                    _currentProjectilesCount++;
                    _timer = _delay;
                }
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

    private void ReduceProjectileCount() => _currentProjectilesCount--;
}
