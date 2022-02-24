using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreator : MonoBehaviour
{
    public Character character;

    public IdentityGenerator identityGenerator;
    public AttributeAllocator attributeAllocator;
    public SkillTrainer skillTrainer;
    public EquipmentSelector equipmentSelector;
    public AbilitySelector abilitySelector;
    
    public SaveHandler saveHandler;
    public int activeCharacterSlot;
    public GameObject customizerPanel;
    public GameObject slotsPanel;

    public void EditCharacterSlot(int slotIndex)
    {
        activeCharacterSlot = slotIndex;
        if (saveHandler.IsSlotFilled(activeCharacterSlot)) 
        {
            saveHandler.LoadCharacter(character, activeCharacterSlot);
        }
        customizerPanel.SetActive(true);
        identityGenerator.LoadIdentity(character);
        attributeAllocator.LoadAttributes(character);
        skillTrainer.LoadSkills(character);
        equipmentSelector.LoadEquipment(character);
        abilitySelector.LoadAbilities(character);
        slotsPanel.SetActive(false);

    }

    public void SaveCharacter()
    {
        saveHandler.SaveCharacter(character, activeCharacterSlot);
        customizerPanel.SetActive(false);
        slotsPanel.SetActive(true);
        Debug.Log("Character saved");
    }

    public void LoadCharacter(int slotIndex)
    {
        saveHandler.LoadCharacter(character, slotIndex);
        Debug.Log("Character loaded");
    }
}
