using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _shotPos;

    public void Shoot() => Instantiate(_projectile, _shotPos.position, _shotPos.rotation);
}
