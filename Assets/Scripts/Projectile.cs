using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private void Awake() => Destroy(gameObject, _lifeTime);

    private void Update() => transform.Translate(Vector2.right * _speed * Time.deltaTime);
}
