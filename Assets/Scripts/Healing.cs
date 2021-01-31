using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public float healPoints = 0;

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
        damageable.Heal(healPoints);
        OnHealingCollision(gameObject);
    }

    protected virtual void OnHealingCollision(GameObject go) {
        AudioManager._instance.PlaySound(3, 1, 0);
        Destroy(go); }
}
