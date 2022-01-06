using Core;
using UnityEngine;

namespace LevelDesign
{
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField] private Game _game;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Projectile>() != null)
            {
                Projectile projectile = collision.GetComponent<Projectile>();

                _game.SaveData();
                projectile.pool.pool.Release(projectile);
            }
        }
    }
}