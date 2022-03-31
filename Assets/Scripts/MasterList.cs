using System.Collections.Generic;
using UnityEngine;

public class MasterList: MonoBehaviour
{
    public List<Equipment> Equipment;
    public List<Ability> Abilities;

    public Equipment GetEquipment(EquipmentType type, int id)
    {
        for (int i = 0; i < Equipment.Count; i++)
        {
            if (Equipment[i].type == type && Equipment[i].ID == id)
            {
                return Equipment[i];
            }
        }
        Debug.Log("Equipment not found");
        return null;
    }

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

    public List<Ability> GetAbilities(AbilityType abilityType, int skillLevel)
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

    public AbilityType GetAbilityType(Weapon weapon)
    {
        if (weapon.WeaponType == WeaponType.Unarmed) { return AbilityType.Unarmed; }
        else if (weapon.WeaponType == WeaponType.OneHanded) { return AbilityType.OneHanded; }
        else if (weapon.WeaponType == WeaponType.TwoHanded) { return AbilityType.TwoHanded; }
        else if (weapon.WeaponType == WeaponType.Bow) { return AbilityType.Archery; }
        else { Debug.Log("Weapon type not found.  Returning archery"); return AbilityType.Archery; }
    }
}
