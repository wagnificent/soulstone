using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Bot : Destructible
{
    public float maxEnergy = 100f;
    public float currentEnergy = 100f;
    public float energyRegenRate = 5f;
    public GameObject SoulStone;

    private bool isDead = false;
    private MatchHandler matchHandler;
    private Character myCharacter;

    private bool isBlocking = false;
    private bool isDodging = false;
    private bool isParrying = false;
    private bool isHardening = false;

    private void Start()
    {
        matchHandler = FindObjectOfType<MatchHandler>();
        myCharacter = GetComponent<Character>();
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        InvokeRepeating("RegenEnergy", 3f, 3f);
    }

    public override void TakeDamage(float amount)
    {
        if (isDead == true) { return; }

        currentHealth -= amount;
        Debug.Log("Damage taken: " + amount);

        if (currentHealth <= 0) { Die(); }
    }

    public override void Heal(float amount)
    {
        if (isDead == true || currentHealth == maxHealth)
        {
            return;
        }

        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        isDead = true;
        Invoke("Respawn", 5f);
        this.gameObject.SetActive(false);
        
    }

    public void Respawn()
    {
        if (!SoulStone)
        {
            Eliminate();
        }
        else
        {
            currentHealth = maxHealth;
            int random = Random.Range(0, SoulStone.GetComponent<SoulStone>().SpawnPoint.Length);
            this.transform.position = SoulStone.GetComponent<SoulStone>().SpawnPoint[random].position;
            isDead = false;
            this.gameObject.SetActive(true);
        }
    }

    public override void Eliminate()
    {
        Debug.Log(this.name + " has been eliminated from the match.");
        matchHandler.UpdateTeam(TeamID);
        Destroy(this.gameObject);
    }

    public void UseAbility(float energyCost, float damage)
    {
        if (energyCost > currentEnergy)
        {
            Debug.Log(this.name + " doesn't have enough energy to use that ability!");
            return;
        }
        else
        {
            currentEnergy -= energyCost;
            Debug.Log(this.name + " spent " + energyCost + " to use an ability.");
        }
    }

    private void RegenEnergy()
    {
        currentEnergy += energyRegenRate;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }

    public bool DidDefend(float attackSkill, float defendSkill)
    {
        float defendChance = defendSkill / (attackSkill + defendSkill);
        float roll = (Random.Range(0f, 100f) / 100f);
        if (defendChance >= roll)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void CalculateDamage(float attackskill, float rawDamage, GameObject attacker)
    {
        float adjustedDamage = rawDamage;

        //Check defenses, and adjust damage as appropriate
        if (isDodging)
        {
            if (DidDefend(attackskill, myCharacter.Dodge.Value))
            {
                Debug.Log("Dodged the attack!");
                //dodging animation
                return;
            }
        }
        else if (isParrying)
        {
            if (DidDefend(attackskill, myCharacter.Parry.Value))
            {
                Debug.Log("Parried the attack!");
                //parrying animation
                return;
            }
        }
        else if (isBlocking)
        {
            if (DidDefend(attackskill, myCharacter.Block.Value))
            {
                adjustedDamage *= (50 / (myCharacter.Block.Value * 2));
                Debug.Log("Blocked some damage!");
                //blocking animation
            }
        }
        else if (isHardening)
        {
            adjustedDamage *= myCharacter.Harden.Value;
        }

        //Adjust damage per armor values
        adjustedDamage -= myCharacter.ArmorRating.Value;

        //Adjust damage per resistances/vulns

        TakeDamage(adjustedDamage);
    }
}
