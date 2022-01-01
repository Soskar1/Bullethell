using UnityEngine;
using System.IO;

namespace Core.SaveLoadSystem
{
    public static class SaveSystem
    {
        public static string directory = "/SaveData/";
        public static string fileName = "PlayerData.txt";

        public static void Save(PlayerData data)
        {
            string path = Application.persistentDataPath + directory;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path + fileName, json);
        }

        public static PlayerData Load()
        {
            string fullPath = Application.persistentDataPath + directory + fileName;
            PlayerData data = new PlayerData(Vector2.zero);

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                data = JsonUtility.FromJson<PlayerData>(json);
            }
            else
            {
                Debug.LogError("Save file does not exist!");
            }

            return data;
        }

        public static bool SaveExist()
        {
            string fullPath = Application.persistentDataPath + directory + fileName;

            if (File.Exists(fullPath))
                return true;

            return false;
        }
    }
}