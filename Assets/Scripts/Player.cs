using UnityEngine;
using Wagnificent.CharacterStats;

public class Player : Destructible
{
    public float maxEnergy = 100f;
    public float currentEnergy = 100f;
    public float energyRegenRate = 5f;
    public float speed = 50f;
    public float sprintCost = 10f;
    public float jumpCost = 20f;
    public float jumpStrength = 5f;
    public GameObject SoulStone;
    
    private bool isDead = false;
    private PlayerHUD myHUD;
    private TargetingSystem targetingSystem;
    private MatchHandler matchHandler;
    private Character myCharacter;
    private Rigidbody myRigidbody;

    private Ability primedAbility;

    private bool usingAlternateWeapons = false;
    private bool isBlocking = false;
    private bool isDodging = false;
    private bool isParrying = false;
    private bool isHardening = false;
    private bool isSprinting = false;


    void Start()
    {
        matchHandler = FindObjectOfType<MatchHandler>();
        myCharacter = GetComponent<Character>();
        myRigidbody = GetComponent<Rigidbody>();
        targetingSystem = GetComponent<TargetingSystem>();
        myHUD = GetComponent<PlayerHUD>();
        InitializeCharacter();
        currentEnergy = maxEnergy;
        InvokeRepeating("UpdateEnergy", 1f, 1f);
        myHUD.UpdateVitals();
    }

    private void InitializeCharacter()
    {
        for (int i = 0; i < myCharacter.Attributes.Length; i++)
        {
            myCharacter.Attributes[i].AddBonuses();
        }
    }

    public override void TakeDamage(float amount)
    {
        if(isDead == true) { return; }

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Debug.Log("You received " + amount + " damage! You have died.");
            isDead = true;
            Invoke("Respawn", 5f);
            this.gameObject.SetActive(false);
        } 

        else { Debug.Log("You received " + amount + " damage! Current health: " + currentHealth); }

        myHUD.UpdateVitals();
        
    }

    public override void Heal(float amount)
    {
        if (isDead == true || currentHealth == maxHealth)
        {
            return;
        }

        currentHealth += amount;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            Debug.Log("You recovered " + amount + " health! You are at full health!");
        }
        else
        {
            Debug.Log("You recovered " + amount + " health! Current health: " + currentHealth);
        }
        
        myHUD.UpdateVitals();
    }

    public void Respawn()
    {
        if (SoulStone)
        {
            currentHealth = maxHealth;
            currentEnergy = maxEnergy;
            int random = Random.Range(0, SoulStone.GetComponent<SoulStone>().SpawnPoint.Length);
            this.transform.position = SoulStone.GetComponent<SoulStone>().SpawnPoint[random].position;
            this.gameObject.SetActive(true);
            Debug.Log("You have respawned at your Soul Stone!");
            myHUD.UpdateVitals();
            isDead = false;
        }
        else
        {
            Eliminate();
        }
        
    }

    public override void Eliminate()
    {
        // Display game over screen
        Debug.Log("Your soul stone has been destroyed.  You have been eliminated from the match.");
        matchHandler.UpdateTeam(TeamID);
        Destroy(this.gameObject);
        // Enable spectate mode

        // Enable exit game button
    } 

    private void UpdateEnergy()
    {
        if (isSprinting)
        {
            currentEnergy -= sprintCost;
            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                ToggleSprint();
                Debug.Log("You are out of energy!");
            }
            
        }
        else
        {
            currentEnergy += energyRegenRate;
            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
        }
        myHUD.UpdateVitals();
    }

    public void UseAbility()
    {         
        // Identify the target
        Destructible target;

        if (primedAbility.IsTargetSelf) { target = this.GetComponent<Destructible>(); }
        else if (targetingSystem.currentTarget != null && targetingSystem.currentTarget.gameObject.activeInHierarchy) 
        { 
            target = targetingSystem.currentTarget.GetComponent<Destructible>(); 
        }
        else 
        { 
            Debug.Log("You don't have a target selected"); 
            return; 
        }

        // Confirm that the character can use the ability on the target
        {
            if (!CanUseAbility(primedAbility)) { return; }
            else
            {

                // Calculate the magnitude of the ability's effect using attributes, skills, and equipment
                float magnitude = CalculateMagnitude(primedAbility);

                // Affect the target, as appropriate
                if(primedAbility.EffectType == EffectType.Damage)
                {
                    float hitChance = CalculateHitChance(primedAbility);
                    target.CalculateDamage(hitChance, magnitude, this.gameObject);
                }
                else if(primedAbility.EffectType == EffectType.Heal)
                {
                    target.Heal(magnitude);
                }
                else if (primedAbility.EffectType == EffectType.Buff)
                {
                    Debug.Log("Buffed the target!");
                }
                else if (primedAbility.EffectType == EffectType.Debuff)
                {
                    float hitChance = CalculateHitChance(primedAbility);
                    Debug.Log("Debuffed the target!");
                }
                else
                {
                    Debug.Log("You did something that hasn't been defined yet!");
                }

                // Update vitals
                currentEnergy -= primedAbility.EnergyCost;
                myHUD.UpdateVitals();
                //Debug.Log("You spent " + ability.EnergyCost + " to use " + ability.Name + "!");
            }
        }
    }

    private bool CanUseAbility(Ability ability)
    {
        float distance = Vector3.Distance(this.transform.position, targetingSystem.currentTarget.transform.position);

        if (ability.EnergyCost > currentEnergy)
        {
            Debug.Log("You don't have enough energy to use this ability");
            return false;
        }

        else if (distance > ability.Range && !ability.IsTargetSelf)
        {
            Debug.Log("Target is out of range");
            return false;
        }

        else
        {
            return true;
        }
    }

    public bool DidDefend(float hitChance, float defendChance)
    {
        float odds = defendChance / (hitChance + defendChance);
        float roll = (Random.Range(0f, 100f) / 100f);
        if (roll <= odds)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void CalculateDamage(float hitChance, float rawDamage, GameObject attacker)
    {
        float adjustedDamage = rawDamage;

        //Check defenses, and adjust damage as appropriate
        if (isDodging && attacker == targetingSystem.currentTarget)
        {
            if (DidDefend(hitChance, myCharacter.Skills[8].Value))
            {
                Debug.Log("Dodged the attack!");
                //dodging animation
                return;
            }
        }
        else if (isParrying && attacker == targetingSystem.currentTarget)
        {
            if (DidDefend(hitChance, myCharacter.Skills[10].Value))
            {
                Debug.Log("Parried the attack!");
                //parrying animation
                return;
            }
        }
        else if (isBlocking && attacker == targetingSystem.currentTarget)
        {
            if (DidDefend(hitChance, myCharacter.Skills[9].Value))
            {
                adjustedDamage *= (50 / (myCharacter.Skills[9].Value * 2));
                Debug.Log("Blocked some damage!");
                //blocking animation
            }
        }
        else if (isHardening && attacker == targetingSystem.currentTarget)
        {
            adjustedDamage *= myCharacter.Skills[11].Value;
        }

        //Adjust damage per armor values
        adjustedDamage *= (100 / myCharacter.ArmorRating.Value * 2);

        //Adjust damage per resistances/vulns

        TakeDamage(adjustedDamage);
    }

    private float MatchingSkill(AbilityType abilityType)
    {
        int skillIndex = ((int)abilityType);
        return myCharacter.Skills[skillIndex].Value;
    }

    private float MatchingWeapon(AbilityType abilityType)
    {
        // Check primary weapons
        if (!usingAlternateWeapons)
        {
            for (int i = 0; i < 2; i++)
            {
                if(myCharacter.Equipment[i] != null)
                {
                    Weapon w = myCharacter.Equipment[i] as Weapon;

                    if (abilityType == AbilityType.Unarmed && w.WeaponType == WeaponType.Unarmed)
                    {
                        return w.BaseDamage;
                    }
                    else if (abilityType == AbilityType.OneHanded && w.WeaponType == WeaponType.OneHanded)
                    {
                        return w.BaseDamage;
                    }
                    else if (abilityType == AbilityType.TwoHanded && w.WeaponType == WeaponType.TwoHanded)
                    {
                        return w.BaseDamage;
                    }
                    else if (abilityType == AbilityType.Archery && w.WeaponType == WeaponType.Bow)
                    {
                        return w.BaseDamage;
                    }
                    else if (
                        (
                        abilityType == AbilityType.CombatMagic ||
                        abilityType == AbilityType.VitalMagic ||
                        abilityType == AbilityType.SupportMagic ||
                        abilityType == AbilityType.UtilityMagic
                        )
                        &&
                        w.CanChannelMagic
                        )
                    { 
                        return w.BaseDamage; 
                    }
                }
                else
                {
                    Debug.Log("No weapon equipped");
                    return 0f;
                }
            }

            Debug.Log("No weapon match found");
            return 0f;
        }

        // Check alternate weapon
        else
        {
            if(myCharacter.Equipment[2] != null)
            {
                Weapon w = myCharacter.Equipment[2] as Weapon;

                if (abilityType == AbilityType.Unarmed && w.WeaponType == WeaponType.Unarmed)
                {
                    return w.BaseDamage;
                }
                else if (abilityType == AbilityType.OneHanded && w.WeaponType == WeaponType.OneHanded)
                {
                    return w.BaseDamage;
                }
                else if (abilityType == AbilityType.TwoHanded && w.WeaponType == WeaponType.TwoHanded)
                {
                    return w.BaseDamage;
                }
                else if (abilityType == AbilityType.Archery && w.WeaponType == WeaponType.Bow)
                {
                    return w.BaseDamage;
                }
                else if (
                    (
                    abilityType == AbilityType.CombatMagic ||
                    abilityType == AbilityType.VitalMagic ||
                    abilityType == AbilityType.SupportMagic ||
                    abilityType == AbilityType.UtilityMagic
                    )
                    &&
                    w.CanChannelMagic
                    )
                {
                    return w.BaseDamage;
                }
                else
                {
                    Debug.Log("No weapon match found");
                    return 0f;
                }
            }

            else
            {
                Debug.Log("No weapon equipped");
                return 0f;
            }
        }
    }

    private float MatchingAttribute(AbilityType abilityType)
    {
        if (abilityType == AbilityType.CombatMagic ||
            abilityType == AbilityType.VitalMagic ||
            abilityType == AbilityType.SupportMagic ||
            abilityType == AbilityType.UtilityMagic)
        {
            return myCharacter.Attributes[4].Value;
        }

        else 
        { 
            return myCharacter.Attributes[0].Value;
        }
    }

    private float CalculateMagnitude(Ability ability)
    {
        float modifier = (MatchingAttribute(ability.AbilityType) + MatchingSkill(ability.AbilityType)) / 200;
        return ability.EffectMagnitude + MatchingWeapon(ability.AbilityType) + modifier;
    }

    private float CalculateHitChance(Ability ability)
    {
        float hitChance = (myCharacter.Attributes[2].Value + MatchingSkill(ability.AbilityType)) / 200;
        return hitChance;
    }

    public void PrimeAbility(int abilityIndex)
    {
        // Set the selected ability as the primed ability (only one ability can be primed at a time)
        if (!usingAlternateWeapons && myCharacter.PrimaryAbilities[abilityIndex] != null)
        {
            primedAbility = myCharacter.PrimaryAbilities[abilityIndex];
        } 
        else if (usingAlternateWeapons && myCharacter.AlternateAbilities[abilityIndex] != null)
        { 
            primedAbility = myCharacter.AlternateAbilities[abilityIndex]; 
        }
        else
        {
            Debug.Log("Ability not found");
            return;
        }

        // If this is a defensive ability, set up the defense
        if(primedAbility.AbilityType == AbilityType.Block && isBlocking == false)
        {
            isBlocking = true;
            // Add stat modifier for block skill
        }
        else if (primedAbility.AbilityType == AbilityType.Dodge && isDodging == false)
        {
            isDodging = true;
            // Add stat modifier for dodge skill
        }
        else if (primedAbility.AbilityType == AbilityType.Parry && isParrying == false)
        {
            isParrying = true;
            // Add stat modifier for parry skill
        }
        else if (primedAbility.AbilityType == AbilityType.Harden && isHardening == false)
        {
            isHardening = true;
            // Add stat modifier for dodge skill
        }

        // If this ability targets another character, enable targeting system
        if (!primedAbility.IsTargetSelf)
        {
            targetingSystem.SelectTarget();
        }
    }

    public void ExecuteAbility()
    {
        if (primedAbility.AbilityType == AbilityType.Block)
        {
            isBlocking = false;
            // Remove stat modifier for block skill
        }
        else if (primedAbility.AbilityType == AbilityType.Dodge)
        {
            isDodging = false;
            // Remove stat modifier for dodge skill
        }
        else if (primedAbility.AbilityType == AbilityType.Parry)
        {
            isParrying = false;
            // Remove stat modifier for parry skill
        }
        else if (primedAbility.AbilityType == AbilityType.Harden)
        {
            isHardening = false;
            // Remove stat modifier for dodge skill
        }
        
        else 
        { 
            UseAbility(); 
        }
    }

    public void ClearTarget()
    {
        targetingSystem.currentTarget = null;
        Debug.Log("Target cleared");
        primedAbility = null;
        Debug.Log("Ability deprimed");
    }

    public void SwitchWeapons()
    {
        usingAlternateWeapons = !usingAlternateWeapons;
        Debug.Log("Weapons and abilities switched");
    }

    public void ToggleSprint()
    {
        isSprinting = !isSprinting;
        if (isSprinting)
        {
            Debug.Log("Sprinting...");
            speed *= 1.5f;
        }
        else
        {
            Debug.Log("Jogging");
            speed /= 1.5f;
        }
    }

    public void Jump()
    {
        if(currentEnergy >= jumpCost)
        {
            currentEnergy -= jumpCost;
            myRigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("You don't have enough energy to jump!");
        }
    }

    public void Interact()
    {
        Debug.Log("Interacting with target");
    }

    public void UseTrinket()
    {
        Debug.Log("Using trinket...");
    }

    public void UseConsumable()
    {
        Debug.Log("Using consumable...");
    }

    public void PingLocation()
    {
        Debug.Log("Pinging target location");
    }

    public void Emote()
    {
        Debug.Log("Using emote...");
    }

    public void Chat()
    {
        Debug.Log("Sending chat message...");
    }
}
