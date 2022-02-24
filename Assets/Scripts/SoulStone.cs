using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulStone : Destructible
{
    public Transform[] SpawnPoint;


    public override void CalculateDamage(float attackskill, float rawDamage, GameObject attacker)
    {
        TakeDamage(rawDamage);
    }

    public override void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Debug.Log("Soul stone destroyed! " + TeamID + " team can no longer respawn!");
            Destroy(this.gameObject);
        }
    }

    public override void Heal(float amount)
    {
        Debug.Log("Invalid target -- Soul Stone");
    }
}
