using Core;
using Core.SaveLoadSystem;
using Core.UI;
using UnityEngine;

namespace LevelDesign
{
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private Counter _counter;
        [SerializeField] private Transform _player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Projectile>() != null)
            {
                Projectile projectile = collision.GetComponent<Projectile>();

                _game.Data.position = _player.position;
                _game.Data.deathCount = _counter.DeathCount;
                SaveSystem.Save(_game.Data);
                projectile.pool.pool.Release(projectile);
            }
        }
    }
}