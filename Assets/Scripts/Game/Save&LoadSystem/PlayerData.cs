using UnityEngine;

namespace Core.SaveLoadSystem
{
    [System.Serializable]
    public class PlayerData
    {
        public Vector2 position;
        public int world;

        public PlayerData(Vector2 position, int world = 0)
        {
            this.position = position;
            this.world = world;
        }
    }
}