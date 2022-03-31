using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

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
        savedCharacter.Race = (int)character.Race;
    }

    void SaveAttributes(Character character, SavedCharacter savedCharacter)
    {
        for (int i = 0; i <savedCharacter.Attributes.Length; i++)
        {
            savedCharacter.Attributes[i] = character.Attributes[i].AllocationBonus;
        }
    }

    void SaveSkills(Character character, SavedCharacter savedCharacter)
    {
        for (int i = 0; i < savedCharacter.Skills.Length; i++)
        {
            savedCharacter.Skills[i] = character.Skills[i].SkillLevel;
        }
    }

    void SaveEquipment(Character character, SavedCharacter savedCharacter)
    {
        for (int i = 0; i < character.Equipment.Length; i++)
        {
            if(character.Equipment[i] == null) { savedCharacter.Equipment[i] = 0; }
            else { savedCharacter.Equipment[i] = character.Equipment[i].ID; }
        }
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
        shell.Race = (Race)savedCharacter.Race;
    }

    void LoadAttributes(SavedCharacter savedCharacter, Character shell)
    {
        for (int i = 0; i < shell.Attributes.Length; i++)
        {
            shell.Attributes[i].AllocationBonus = savedCharacter.Attributes[i];
        }
    }

    void LoadSkills(SavedCharacter savedCharacter, Character shell)
    {
        for (int i = 0; i < shell.Skills.Length; i++)
        {
            shell.Skills[i].SkillLevel = savedCharacter.Skills[i];
        }
    }

    void LoadEquipment(SavedCharacter savedCharacter, Character shell)
    {
        MasterList masterList = FindObjectOfType<MasterList>();

        for (int i = 0; i < savedCharacter.Equipment.Length; i++)
        {
            if (i < 3 && savedCharacter.Equipment[i] != 0) { shell.Equipment[i] = masterList.GetEquipment((EquipmentType)0, savedCharacter.Equipment[i]) as Weapon; }
            else if (i == 3 && savedCharacter.Equipment[i] != 0) { shell.Equipment[i] = masterList.GetEquipment((EquipmentType)1, savedCharacter.Equipment[i]) as Armor; }
            else if (i == 4 && savedCharacter.Equipment[i] != 0) { shell.Equipment[i] = masterList.GetEquipment((EquipmentType)2, savedCharacter.Equipment[i]) as Trinket; }
            else if (i == 5 && savedCharacter.Equipment[i] != 0) { shell.Equipment[i] = masterList.GetEquipment((EquipmentType)3, savedCharacter.Equipment[i]) as Consumable; }
            else { shell.Equipment[i] = null; }
        }
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
