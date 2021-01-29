using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damaging : MonoBehaviour
{
    public float damage = 0; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollideAndTrigger(collision.gameObject);
        OnDamagingCollision(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollideAndTrigger(collision.gameObject);
        OnDamagingCollision(gameObject);
    }

    private void OnCollideAndTrigger(GameObject other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable == null) return;
        damageable.Damage(damage);
    }

    protected virtual void OnDamagingCollision(GameObject go) { }

}

