using UnityEngine;

public class ExtraJump : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private SpriteRenderer _visual;
    [SerializeField] private float _restoreTime;

    private bool _interactable = true;

    private bool Interactable 
    { 
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
