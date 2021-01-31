using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DamageEvent : UnityEvent<GameObject, float> { }
public class DeathEvent : DamageEvent{}


public class Damageable : MonoBehaviour
{
    public float maxHp = 100;

    bool playing = false;

    public float hp { get; private set; }

    public static DamageEvent globalDamageEvent = new DamageEvent();
    public static DeathEvent globalDeathEvent = new DeathEvent();

    public virtual void Start()
    {
        hp = maxHp;
    }

    DeathEvent deathEvent = new DeathEvent();
    DamageEvent damageEvent = new DamageEvent();

    public void Damage(float amount)
    {
        amount = Mathf.Abs(amount);
        hp -= amount;
        if (hp < 0)
        {
            hp = 0;
            Die(amount);
        }
        else InvokeDamage(amount);
        print(hp);
    }

    public void Heal(float amount)
    {
        amount = Mathf.Abs(amount);
        if (maxHp > (amount + hp))
            hp += amount;
        else hp = maxHp;
        InvokeDamage(-amount);
    }

    protected virtual void Die(float amount)
    {
        InvokeDeath(amount);
    }

    void InvokeDeath(float amount)
    {
        deathEvent.Invoke(gameObject, amount);
        globalDeathEvent.Invoke(gameObject, amount);
    }

    void InvokeDamage(float amount)
    {
        if (!playing && amount > 0)
        StartCoroutine(HitSounds());
        damageEvent.Invoke(gameObject, amount);
        globalDamageEvent.Invoke(gameObject, amount);
    }

    IEnumerator HitSounds()
    {
        playing = true;
        AudioManager._instance.PlaySound(1, 0.4f, 0);
        yield return new WaitForSeconds(0.5f);
        AudioManager._instance.PlaySound(2, 0.4f, 0);
        yield return new WaitForSeconds(0.5f);
        playing = false;
    }
}

