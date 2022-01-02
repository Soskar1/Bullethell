using UnityEngine;
using System;
using Core.Pool;
using LevelDesign;

namespace Entity
{
    [RequireComponent(typeof(ProjectilePool))]
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private ProjectilePool _pool;
        [SerializeField] private Transform _shotPos;

        public void Shoot()
        {
            Projectile projectileInstance = _pool.pool.Get();
            projectileInstance.transform.position = _shotPos.position;
            projectileInstance.transform.rotation = _shotPos.rotation;
            projectileInstance.pool = _pool;
        }

        public void Shoot(Action Released)
        {
            Projectile projectileInstance = _pool.pool.Get();
            projectileInstance.transform.position = _shotPos.position;
            projectileInstance.transform.rotation = _shotPos.rotation;
            projectileInstance.pool = _pool;

            projectileInstance.Released -= Released;
            projectileInstance.Released += Released;
        }
    }
}