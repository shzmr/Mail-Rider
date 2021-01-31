using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damaging : MonoBehaviour
{
    public float damage = 0; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollideAndTrigger(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollideAndTrigger(collision.gameObject);
    }

    private void OnCollideAndTrigger(GameObject other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable == null) return;
        print(other.name);
        damageable.Damage(damage);
        OnDamagingCollision(gameObject);
    }

    protected virtual void OnDamagingCollision(GameObject go) { Destroy(go); }

}

