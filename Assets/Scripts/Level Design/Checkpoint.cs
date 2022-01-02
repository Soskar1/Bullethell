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
                Debug.Log("Идёт сохранение!");
                _game.Data.position = _player.position;
                _game.Data.deathCount = _counter.DeathCount;
                Debug.Log(_game.Data.deathCount);
                SaveSystem.Save(_game.Data);
            }
        }
    }
}