using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wagnificent.CharacterStats;

public class AbilitySelector : MonoBehaviour
{

    public Character myCharacter;
    private MasterList masterList;

    public AbilitySlot[] PrimaryAbilities;
    public AbilitySlot[] AlternateAbilities;
    
    public Text[] PrimaryAbilityNames;
    public Text[] AlternateAbilityNames;

    public int SlotIndex;

    void Start()
    {
        masterList = FindObjectOfType<MasterList>();
        PopulateInventory();
        UpdateAbilityUI();
    }

    public void LoadAbilities(Character character)
    {
        myCharacter = character;
        UpdateAbilityUI();
    }

    private void PopulateInventory()
    {

        for (int i = 0; i < masterList.Abilities.Count; i++)
        {
            PrimaryAbilities[i].AbilityItem = masterList.Abilities[i];
            PrimaryAbilities[i].GetComponent<Image>().sprite = masterList.Abilities[i].Icon;
        }

        for (int i = 0; i < masterList.Abilities.Count; i++)
        {
            AlternateAbilities[i].AbilityItem = masterList.Abilities[i];
            AlternateAbilities[i].GetComponent<Image>().sprite = masterList.Abilities[i].Icon;
        }
    }

    public void EquipPrimaryAbility(Ability ability)
    {
        myCharacter.PrimaryAbilities[SlotIndex] = ability;
        UpdateAbilityUI();
    }

    public void EquipAlternateAbility(Ability ability)
    {
        myCharacter.AlternateAbilities[SlotIndex] = ability;
        UpdateAbilityUI();
    }

    public void SetSlotIndex(int i)
    {
        SlotIndex = i;
    }

    
    private void UpdateAbilityUI()
    {
        for(int i = 0; i < PrimaryAbilityNames.Length; i++)
        {
            if (myCharacter.PrimaryAbilities[i] == null)
            {
                PrimaryAbilityNames[i].text = "Empty";
            }
            else
            {
                PrimaryAbilityNames[i].text = myCharacter.PrimaryAbilities[i].Name;
            }
        }

        for (int i = 0; i < AlternateAbilityNames.Length; i++)
        {
            if (myCharacter.AlternateAbilities[i] == null)
            {
                AlternateAbilityNames[i].text = "Empty";
            }
            else
            {
                AlternateAbilityNames[i].text = myCharacter.AlternateAbilities[i].Name;
            }
        }
    }

    
    private List<Ability> FilterPrimaryAbilities()
    {
        List<Ability> matchingAbilities = new List<Ability>();

        for (int i = 0; i < masterList.Abilities.Count; i++)
        {

            if (myCharacter.Weapons[0] != null)
            {
                AbilityType weapon0Type = GetAbilityType(myCharacter.Weapons[0]);

                if (masterList.Abilities[i].AbilityType == weapon0Type &&
                    masterList.Abilities[i].RequiredSkillLevel <= GetSkillLevel(masterList.Abilities[i].AbilityType))
                {
                    matchingAbilities.Add(masterList.Abilities[i]);
                }
            }

            if (myCharacter.Weapons[1] != null)
            {
                AbilityType weapon1Type = GetAbilityType(myCharacter.Weapons[1]);

                if (masterList.Abilities[i].AbilityType == weapon1Type &&
                    masterList.Abilities[i].RequiredSkillLevel <= GetSkillLevel(masterList.Abilities[i].AbilityType))
                {
                    matchingAbilities.Add(masterList.Abilities[i]);
                }
            }
        }

        return matchingAbilities;

    }


    private AbilityType SkillToAbility(Skill skill)
    {
        if(skill == myCharacter.Unarmed) { return AbilityType.Unarmed; }
        else if (skill == myCharacter.OneHanded) { return AbilityType.OneHanded; }
        else if (skill == myCharacter.TwoHanded) { return AbilityType.TwoHanded; }
        else if (skill == myCharacter.Archery) { return AbilityType.Archery; }
        else if (skill == myCharacter.CombatMagic) { return AbilityType.CombatMagic; }
        else if (skill == myCharacter.VitalMagic) { return AbilityType.VitalMagic; }
        else if (skill == myCharacter.SupportMagic) { return AbilityType.SupportMagic; }
        else if (skill == myCharacter.UtilityMagic) { return AbilityType.UtilityMagic; }
        else if (skill == myCharacter.Block) { return AbilityType.Block; }
        else if (skill == myCharacter.Dodge) { return AbilityType.Dodge; }
        else if (skill == myCharacter.Parry) { return AbilityType.Parry; }
        else if (skill == myCharacter.Harden) { return AbilityType.Harden; }
        else { Debug.Log("Skill not found. Returning harden"); return AbilityType.Harden; }
    }
    

    private int GetSkillLevel(AbilityType abilityType)
    {
        if(abilityType == AbilityType.Unarmed) { return myCharacter.Unarmed.SkillLevel; }
        else if (abilityType == AbilityType.OneHanded) { return myCharacter.OneHanded.SkillLevel; }
        else if (abilityType == AbilityType.TwoHanded) { return myCharacter.TwoHanded.SkillLevel; }
        else if (abilityType == AbilityType.Archery) { return myCharacter.Archery.SkillLevel; }
        else if (abilityType == AbilityType.CombatMagic) { return myCharacter.CombatMagic.SkillLevel; }
        else if (abilityType == AbilityType.VitalMagic) { return myCharacter.VitalMagic.SkillLevel; }
        else if (abilityType == AbilityType.SupportMagic) { return myCharacter.SupportMagic.SkillLevel; }
        else if (abilityType == AbilityType.UtilityMagic) { return myCharacter.UtilityMagic.SkillLevel; }
        else if (abilityType == AbilityType.Block) { return myCharacter.Block.SkillLevel; }
        else if (abilityType == AbilityType.Dodge) { return myCharacter.Dodge.SkillLevel; }
        else if (abilityType == AbilityType.Parry) { return myCharacter.Parry.SkillLevel; }
        else if (abilityType == AbilityType.Harden) { return myCharacter.Harden.SkillLevel; }
        else { Debug.Log("Ability type not found. Returning harden"); return myCharacter.Harden.SkillLevel; }
    }

    private AbilityType GetAbilityType(Weapon weapon)
    {
        if(weapon.WeaponType == WeaponType.Unarmed) { return AbilityType.Unarmed; }
        else if (weapon.WeaponType == WeaponType.OneHanded) { return AbilityType.OneHanded; }
        else if (weapon.WeaponType == WeaponType.TwoHanded) { return AbilityType.TwoHanded; }
        else if (weapon.WeaponType == WeaponType.Bow) { return AbilityType.Archery; }
        else { Debug.Log("Weapon type not found.  Returning archery"); return AbilityType.Archery; }
    }

}
