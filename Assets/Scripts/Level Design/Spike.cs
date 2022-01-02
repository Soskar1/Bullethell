using Entity.MainCharacter;
using UnityEngine;

namespace LevelDesign
{
    public class Spike : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>() != null)
                collision.gameObject.SetActive(false);
        }
    }
}