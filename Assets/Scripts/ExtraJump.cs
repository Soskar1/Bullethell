using UnityEngine;

public class ExtraJump : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private SpriteRenderer _visual;
    [SerializeField] private float _restoreTime;

    [SerializeField] private bool _interactable;

    public bool Interactable 
    { 
        get => _interactable;
        set 
        { 
            _interactable = value;
            if (_interactable)
            {
                _collider.enabled = true;
                _visual.enabled = true;
            }   
            else
            {
                _collider.enabled = false;
                _visual.enabled = false;
            }    
        } 
    }

    public void AddExtraJump(ref int jumpCount)
    {
        jumpCount--;
        Interactable = false;
        StartCoroutine(Timer.Start(_restoreTime, () => Interactable = true));
    }
}
