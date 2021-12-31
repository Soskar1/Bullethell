using UnityEngine;

public class Flipping : MonoBehaviour
{
    [SerializeField] private bool _facingRight;

    public bool FacingRight { get => _facingRight; }

    public void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0, 180, 0);
    }
}
