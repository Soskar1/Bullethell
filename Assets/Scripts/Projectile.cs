using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public ProjectilePool pool;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    public Action Released;

    private void OnEnable() => StartCoroutine(Timer.Start(_lifeTime, () => pool.pool.Release(this)));

    private void Update() => transform.Translate(Vector2.right * _speed * Time.deltaTime);

    private void OnDisable() => Released?.Invoke();
}
