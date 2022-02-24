using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int TeamID;
    public string Name;
    public float maxHealth;
    public float currentHealth;

    public virtual void CalculateDamage(float attackskill, float rawDamage, GameObject attacker)
    {
        Debug.Log("This virtual method has not been overridden");
    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }

    public virtual void Eliminate()
    {
        Debug.Log("This virtual method has not been overridden");
    }

    public virtual void Heal(float amount)
    {
        Debug.Log("This virtual method has not been overridden");
    }
}
