using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DamageEvent : UnityEvent<GameObject, float> { }
public class DeathEvent : DamageEvent{}


public class Damageable : MonoBehaviour
{
    public float maxHp = 100;

    public float hp { get; private set; }

    static DamageEvent globalDamageEvent = new DamageEvent();
    static DeathEvent globalDeathEvent = new DeathEvent();

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
        hp += amount + ((maxHp > (amount + hp))? amount : maxHp - hp);
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
        damageEvent.Invoke(gameObject, amount);
        globalDamageEvent.Invoke(gameObject, amount);
    }
}

