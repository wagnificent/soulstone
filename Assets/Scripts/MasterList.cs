using System.Collections.Generic;
using UnityEngine;

public class MasterList: MonoBehaviour
{
    public List<Weapon> Weapons;
    public List<Armor> Armor;
    public List<Consumable> Consumables;
    public List<Trinket> Trinkets;
    public List<Ability> Abilities;

    public Ability GetAbility (int abilityID)
    {
        for (int i = 0; i < Abilities.Count; i++)
        {
            if(Abilities[i].AbilityID == abilityID)
            {
                return Abilities[i];
            }
        }
        return null;
    }

    public Consumable GetConsumable(int consumableID)
    {
        for (int i = 0; i < Consumables.Count; i++)
        {
            if (Consumables[i].ConsumableID == consumableID)
            {
                return Consumables[i];
            }
        }
        return null;
    }

    public Trinket GetTrinket(int trinketID)
    {
        for (int i = 0; i < Trinkets.Count; i++)
        {
            if (Trinkets[i].TrinketID == trinketID)
            {
                return Trinkets[i];
            }
        }
        return null;
    }

    public Weapon GetWeapon(int weaponID)
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            if (Weapons[i].WeaponID == weaponID)
            {
                return Weapons[i];
            }
        }
        return null;
    }

    public Armor GetArmor(int armorID)
    {
        for (int i = 0; i < Armor.Count; i++)
        {
            if (Armor[i].ArmorID == armorID)
            {
                return Armor[i];
            }
        }
        return null;
    }

    public List<Ability> FindAbilities(AbilityType abilityType, int skillLevel)
    {
        List<Ability> matchingAbilities = new List<Ability>();
        foreach(Ability ability in Abilities)
        {
            if(ability.AbilityType == abilityType && ability.RequiredSkillLevel <= skillLevel)
            {
                matchingAbilities.Add(ability);
            }
        }
        return matchingAbilities;
    }
}
