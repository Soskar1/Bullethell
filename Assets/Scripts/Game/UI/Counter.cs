using UnityEngine;
using TMPro;

namespace Core.UI
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private Game _game;

        [SerializeField] private TextMeshProUGUI _counterText;
        [SerializeField] private string _counterName;

        private int _deathCount;

        public int DeathCount { get => _deathCount; set => _deathCount = value; }

        private void Start()
        {
            _deathCount = _game.Data.deathCount;
            _counterText.SetText(_counterName + ": " + _deathCount.ToString());
        }

        public void Add()
        {
            _deathCount++;
            _counterText.SetText(_counterName + ": " + _deathCount.ToString());
        }
    }
}