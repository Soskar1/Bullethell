using UnityEngine;
using UnityEngine.InputSystem;
using Core.SaveLoadSystem;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _start;

        private PlayerData _data;

        public PlayerData Data { get => _data; set => _data = value; }

        private void Awake()
        {
            _data = TryLoadSave();
            _player.position = _data.position;
            SaveSystem.Save(_data);
        }

        private PlayerData TryLoadSave()
        {
            if (SaveSystem.SaveExist())
                return SaveSystem.Load();
            else
                return new PlayerData(_start.position);
        }

        public void Restart(InputAction.CallbackContext ctx)
        {
            _data = SaveSystem.Load();
            _player.position = _data.position;
            _player.gameObject.SetActive(true);
        }
    }
}