using Core;
using UnityEngine;

namespace LevelDesign
{
    public class SaveTrigger : MonoBehaviour, ITrigger
    {
        [SerializeField] private Game _game;

        public void Activate()
        {
            _game.SaveData();
            gameObject.SetActive(false);
        }
    }
}