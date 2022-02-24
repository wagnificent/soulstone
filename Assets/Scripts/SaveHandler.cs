using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Wagnificent.CharacterStats;

public class SaveHandler: MonoBehaviour
{

    public void SaveCharacter(Character characterToSave, int slotIndex)
    {
        SavedCharacter savedCharacter = CreateSavedCharacter(characterToSave);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/charactersave" + slotIndex + ".save");
        bf.Serialize(file, savedCharacter);
        file.Close();
        Debug.Log("Character saved");
    }

    private SavedCharacter CreateSavedCharacter(Character character)
    {
        SavedCharacter savedCharacter = new SavedCharacter();
        
        SaveIdentity(character, savedCharacter);
        SaveAttributes(character, savedCharacter);
        SaveSkills(character, savedCharacter);
        SaveEquipment(character, savedCharacter);
        SaveAbilities(character, savedCharacter);

        return savedCharacter;
    }

    public void LoadCharacter(Character shell, int slotIndex)
    {

        if (IsSlotFilled(slotIndex))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/charactersave" + slotIndex + ".save", FileMode.Open);
            SavedCharacter savedCharacter = (SavedCharacter)bf.Deserialize(file);
            file.Close();

            LoadIdentity(savedCharacter, shell);
            LoadAttributes(savedCharacter, shell);
            LoadSkills(savedCharacter, shell);
            LoadEquipment(savedCharacter, shell);
            LoadAbilities(savedCharacter, shell);

        }
        else
        {
            Debug.Log("Character not found");
        }
    }

    public bool IsSlotFilled(int slotIndex)
    {
        return File.Exists(Application.persistentDataPath + "/charactersave" + slotIndex + ".save");
    }

    void SaveIdentity(Character character, SavedCharacter savedCharacter)
    {
        if (character.Race == Race.Human) { savedCharacter.Race = 0; }
        if (character.Race == Race.Elf) { savedCharacter.Race = 1; }
        if (character.Race == Race.Orc) { savedCharacter.Race = 2; }
        if (character.Race == Race.Dwarf) { savedCharacter.Race = 3; }
        if (character.Race == Race.Halfling) { savedCharacter.Race = 4; }
        if (character.Race == Race.Goblin) { savedCharacter.Race = 5; }
    }

    void SaveAttributes(Character character, SavedCharacter savedCharacter)
    {
        savedCharacter.Strength = character.Strength.AllocationBonus;
        savedCharacter.Endurance = character.Endurance.AllocationBonus;
        savedCharacter.Coordination = character.Coordination.AllocationBonus;
        savedCharacter.Agility = character.Agility.AllocationBonus;
        savedCharacter.Willpower = character.Willpower.AllocationBonus;
    }

    void SaveSkills(Character character, SavedCharacter savedCharacter)
    {
        //Weapon Skills
        savedCharacter.Unarmed = character.Unarmed.SkillLevel;
        savedCharacter.OneHanded = character.OneHanded.SkillLevel;
        savedCharacter.TwoHanded = character.TwoHanded.SkillLevel;
        savedCharacter.Archery = character.Archery.SkillLevel;

        //Magic Skills
        savedCharacter.CombatMagic = character.CombatMagic.SkillLevel;
        savedCharacter.VitalMagic = character.VitalMagic.SkillLevel;
        savedCharacter.SupportMagic = character.SupportMagic.SkillLevel;
        savedCharacter.UtilityMagic = character.UtilityMagic.SkillLevel;

        //Defensive Skills
        savedCharacter.Block = character.Block.SkillLevel;
        savedCharacter.Dodge = character.Dodge.SkillLevel;
        savedCharacter.Parry = character.Parry.SkillLevel;
        savedCharacter.Harden = character.Harden.SkillLevel;
    }

    void SaveEquipment(Character character, SavedCharacter savedCharacter)
    {
        //Weapons
        savedCharacter.Weapons = new List<int>();
        for (int i = 0; i < character.Weapons.Length; i++)
        {
            if (character.Weapons[i] == null) { savedCharacter.Weapons.Add(0); }
            else { savedCharacter.Weapons.Add(character.Weapons[i].WeaponID); }
        }

        //Armor
        if (character.Armor == null) { savedCharacter.Armor = 0; }
        else { savedCharacter.Armor = character.Armor.ArmorID; }

        //Consumable
        if (character.Consumable == null) { savedCharacter.Consumable = 0; }
        else { savedCharacter.Consumable = character.Consumable.ConsumableID; }

        //Trinket
        if (character.Trinket == null) { savedCharacter.Trinket = 0; }
        else { savedCharacter.Trinket = character.Trinket.TrinketID; }
    }

    void SaveAbilities(Character character, SavedCharacter savedCharacter)
    {
        //Primary
        savedCharacter.PrimaryAbilities = new List<int>();
        for (int i = 0; i < character.PrimaryAbilities.Length; i++)
        {
            if (character.PrimaryAbilities[i] == null) { savedCharacter.PrimaryAbilities.Add(0); }
            else { savedCharacter.PrimaryAbilities.Add(character.PrimaryAbilities[i].AbilityID); }
        }

        //Alternative
        savedCharacter.AlternateAbilities = new List<int>();
        for (int i = 0; i < character.AlternateAbilities.Length; i++)
        {
            if (character.AlternateAbilities[i] == null) { savedCharacter.AlternateAbilities.Add(0); }
            else { savedCharacter.AlternateAbilities.Add(character.AlternateAbilities[i].AbilityID); }
        }
    }

    void LoadIdentity(SavedCharacter savedCharacter, Character shell)
    {
        //Race
        if (savedCharacter.Race == 0) { shell.Race = Race.Human; }
        if (savedCharacter.Race == 1) { shell.Race = Race.Elf; }
        if (savedCharacter.Race == 2) { shell.Race = Race.Orc; }
        if (savedCharacter.Race == 3) { shell.Race = Race.Dwarf; }
        if (savedCharacter.Race == 4) { shell.Race = Race.Halfling; }
        if (savedCharacter.Race == 5) { shell.Race = Race.Goblin; }
    }

    void LoadAttributes(SavedCharacter savedCharacter, Character shell)
    {
        shell.Strength.AllocationBonus = savedCharacter.Strength;
        shell.Endurance.AllocationBonus = savedCharacter.Endurance;
        shell.Coordination.AllocationBonus = savedCharacter.Coordination;
        shell.Agility.AllocationBonus = savedCharacter.Agility;
        shell.Willpower.AllocationBonus = savedCharacter.Willpower;
    }

    void LoadSkills(SavedCharacter savedCharacter, Character shell)
    {
        //Weapon Skills
        shell.Unarmed.SkillLevel = savedCharacter.Unarmed;
        shell.OneHanded.SkillLevel = savedCharacter.OneHanded;
        shell.TwoHanded.SkillLevel = savedCharacter.TwoHanded;
        shell.Archery.SkillLevel = savedCharacter.Archery;

        //Magic Skills
        shell.CombatMagic.SkillLevel = savedCharacter.CombatMagic;
        shell.VitalMagic.SkillLevel = savedCharacter.VitalMagic;
        shell.SupportMagic.SkillLevel = savedCharacter.SupportMagic;
        shell.UtilityMagic.SkillLevel = savedCharacter.UtilityMagic;

        //Defensive Skills
        shell.Block.SkillLevel = savedCharacter.Block;
        shell.Dodge.SkillLevel = savedCharacter.Dodge;
        shell.Parry.SkillLevel = savedCharacter.Parry;
        shell.Harden.SkillLevel = savedCharacter.Harden;
    }

    void LoadEquipment(SavedCharacter savedCharacter, Character shell)
    {
        MasterList masterList = FindObjectOfType<MasterList>();

        //Weapons
        for (int i = 0; i < savedCharacter.Weapons.Count; i++)
        {
            if (savedCharacter.Weapons[i] == 0) { shell.Weapons[i] = null; }
            else { shell.Weapons[i] = masterList.GetWeapon(savedCharacter.Weapons[i]); }
        }

        //Armor
        if (savedCharacter.Armor == 0) { shell.Armor = null; }
        else { shell.Armor = masterList.GetArmor(savedCharacter.Armor); }

        //Consumable
        if (savedCharacter.Consumable == 0) { shell.Consumable = null; }
        else { shell.Consumable = masterList.GetConsumable(savedCharacter.Consumable); }

        //Trinket
        if (savedCharacter.Trinket == 0) { shell.Trinket = null; }
        else { shell.Trinket = masterList.GetTrinket(savedCharacter.Trinket); }
    }

    void LoadAbilities(SavedCharacter savedCharacter, Character shell)
    {

        MasterList masterList = FindObjectOfType<MasterList>();

        //Primary
        for (int i = 0; i < savedCharacter.PrimaryAbilities.Count; i++)
        {
            if (savedCharacter.PrimaryAbilities[i] == 0)
            {
                shell.PrimaryAbilities[i] = null;
            }
            else
            {
                shell.PrimaryAbilities[i] = masterList.GetAbility(savedCharacter.PrimaryAbilities[i]);
            }
        }

        //Alternate
        for (int i = 0; i < savedCharacter.AlternateAbilities.Count; i++)
        {
            if (savedCharacter.AlternateAbilities[i] == 0)
            {
                shell.AlternateAbilities[i] = null;
            }
            else
            {
                shell.AlternateAbilities[i] = masterList.GetAbility(savedCharacter.AlternateAbilities[i]);
            }
        }
    }
}
