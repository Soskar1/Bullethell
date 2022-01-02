using UnityEngine;

namespace Core.SaveLoadSystem
{
    [System.Serializable]
    public class PlayerData
    {
        public Vector2 position;
        public int world;
        public int deathCount;

        public PlayerData(Vector2 position, int world = 0, int deathCount = 0)
        {
            this.position = position;
            this.world = world;
            this.deathCount = deathCount;
        }
    }
}