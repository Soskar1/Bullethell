using UnityEngine;
using UnityEngine.InputSystem;
using Core.SaveLoadSystem;
using Entity.MainCharacter;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Core.UI;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;

        [HideInInspector] public Transform player;
        [SerializeField] private Transform _start;

        [SerializeField] private List<Player> _playableCharacters;
        [SerializeField] private Counter _counter;

        private PlayerData _data;
        public PlayerData Data { get => _data; set => _data = value; }

        private void OnEnable() => _input.controls.Player.Restart.performed += Restart;
        private void OnDisable() => _input.controls.Player.Restart.performed -= Restart;

        private void Awake()
        {
            _data = TryLoadSave();

            foreach (var character in _playableCharacters)
            {
                if (character.playableCharacterId == _data.playerID)
                {
                    player = character.transform;
                    character.gameObject.SetActive(true);
                }
                else
                {
                    character.gameObject.SetActive(false);
                }
            }

            player.position = _data.position;
            SaveData();
        }

        public void Restart(InputAction.CallbackContext ctx)
        {
            _data = SaveSystem.Load();
            player.position = _data.position;
            player.gameObject.SetActive(true);
        }

        public void Restart()
        {
            _data = SaveSystem.Load();
            player.position = _data.position;
            player.gameObject.SetActive(true);
        }

        public void SaveData()
        {
            _data.position = player.position;
            _data.world = SceneManager.GetActiveScene().buildIndex;
            _data.deathCount = _counter.DeathCount;
            _data.playerID = player.GetComponent<Player>().playableCharacterId;

            SaveSystem.Save(_data);
        }

        private PlayerData TryLoadSave()
        {
            if (SaveSystem.SaveExist())
                return SaveSystem.Load();
            else
                return new PlayerData(_start.position);
        }
    }
}