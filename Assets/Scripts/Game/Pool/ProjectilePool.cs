using UnityEngine;
using UnityEngine.Pool;

namespace Core.Pool
{
    public class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private int _count = 10;
        [SerializeField] private int _maxSize = 100;
        public ObjectPool<Projectile> pool;

        private void Start()
        {
            pool = new ObjectPool<Projectile>(() =>
            {
                return Instantiate(_projectile);
            }, OnGet =>
            {
                OnGet.gameObject.SetActive(true);
            }, OnRelease =>
            {
                OnRelease.gameObject.SetActive(false);
            }, OnDestroy =>
            {
                Destroy(OnDestroy.gameObject);
            }, false, _count, _maxSize);
        }
    }
}