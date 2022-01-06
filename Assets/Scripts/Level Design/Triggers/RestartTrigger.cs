using Core;
using UnityEngine;

namespace LevelDesign
{
    public class RestartTrigger : MonoBehaviour, ITrigger
    {
        [SerializeField] private Game _game;

        public void Activate() => _game.Restart();
    }
}