using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wagnificent.CharacterStats;

public class AttributeAllocator : MonoBehaviour
{
    public Character myCharacter;
    public Text attributePointTracker;
    public Text strengthBonus;
    public Text enduranceBonus;
    public Text coordinationBonus;
    public Text agilityBonus;
    public Text willpowerBonus;
    public float attributePointMax = 100;
    public float attributePointBalance;


    public void modStrength(float amount)
    {
        if (
            attributePointBalance - amount > attributePointMax || 
            attributePointBalance - amount < 0 || 
            myCharacter.Strength.AllocationBonus + amount < 0
            )
        {
            return;
        }
        else 
        {
            myCharacter.Strength.AllocationBonus += amount;
            attributePointBalance -= amount;
            UpdateAttributeUI();
        }
    }

    public void modEndurance(float amount)
    {
        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            myCharacter.Endurance.AllocationBonus + amount < 0
            )
        {
            return;
        }
        else
        {
            myCharacter.Endurance.AllocationBonus += amount;
            attributePointBalance -= amount;
            UpdateAttributeUI();
        }
    }

    public void modCoordination(float amount)
    {
        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            myCharacter.Coordination.AllocationBonus + amount < 0
            )
        {
            return;
        }
        else
        {
            myCharacter.Coordination.AllocationBonus += amount;
            attributePointBalance -= amount;
            UpdateAttributeUI();
        }
    }

    public void modAgility(float amount)
    {
        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            myCharacter.Agility.AllocationBonus + amount < 0
            )
        {
            return;
        }
        else
        {
            myCharacter.Agility.AllocationBonus += amount;
            attributePointBalance -= amount;
            UpdateAttributeUI();
        }
    }

    public void modWillpower(float amount)
    {
        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            myCharacter.Willpower.AllocationBonus + amount < 0
            )
        {
            return;
        }
        else
        {
            myCharacter.Willpower.AllocationBonus += amount;
            attributePointBalance -= amount;
            UpdateAttributeUI();
        }
    }
 
    private void UpdateAttributeUI()
    {
        attributePointTracker.text = attributePointBalance.ToString();
        strengthBonus.text = myCharacter.Strength.AllocationBonus.ToString();
        enduranceBonus.text = myCharacter.Endurance.AllocationBonus.ToString();
        coordinationBonus.text = myCharacter.Coordination.AllocationBonus.ToString();
        agilityBonus.text = myCharacter.Agility.AllocationBonus.ToString();
        willpowerBonus.text = myCharacter.Willpower.AllocationBonus.ToString();
    }

    public void LoadAttributes(Character character)
    {
        myCharacter = character;
        attributePointBalance =
            (
            attributePointMax -
            myCharacter.Strength.AllocationBonus -
            myCharacter.Endurance.AllocationBonus -
            myCharacter.Coordination.AllocationBonus -
            myCharacter.Agility.AllocationBonus -
            myCharacter.Willpower.AllocationBonus
            );
        UpdateAttributeUI();
    }
}
