using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _whatIsGround;

    public bool Check()
    {
        Collider2D overlapInfo = Physics2D.OverlapCircle(_groundCheck.position, _radius, _whatIsGround);

        if (overlapInfo != null)
            return true;

        return false;
    }
}
