using Entity.MainCharacter;
using UnityEngine;

namespace LevelDesign
{
    public class Trigger : MonoBehaviour
    {
        private ITrigger _trigger;

        private void Awake() => _trigger = GetComponent<ITrigger>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>() != null)
                _trigger.Activate();
        }
    }
}