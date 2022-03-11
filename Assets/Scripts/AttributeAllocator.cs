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

    public Slider StrengthSlider;
    public Slider EnduranceSlider;
    public Slider CoordinationSlider;
    public Slider AgilitySlider;
    public Slider WillpowerSlider;

    public float attributePointMax = 100;
    public float attributePointBalance;


    public void modStrength()
    {
        float amount = StrengthSlider.value - myCharacter.Strength.AllocationBonus;

        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            myCharacter.Strength.AllocationBonus + amount < 0
            )
        {
            Debug.Log("Strength point allocation invalid");
            StrengthSlider.value = myCharacter.Strength.AllocationBonus;
            return;
        }
        else
        {
            myCharacter.Strength.AllocationBonus += amount;
            attributePointBalance -= amount;
            UpdateAttributeUI();
        }
    }

    public void modEndurance()
    {
        float amount = EnduranceSlider.value - myCharacter.Endurance.AllocationBonus;

        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            myCharacter.Endurance.AllocationBonus + amount < 0
            )
        {
            Debug.Log("Enduranct point allocation invalid");
            EnduranceSlider.value = myCharacter.Endurance.AllocationBonus;
            return;
        }
        else
        {
            myCharacter.Endurance.AllocationBonus += amount;
            attributePointBalance -= amount;
            UpdateAttributeUI();
        }
    }

    public void modCoordination()
    {
        float amount = CoordinationSlider.value - myCharacter.Coordination.AllocationBonus;

        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            myCharacter.Coordination.AllocationBonus + amount < 0
            )
        {
            Debug.Log("Coordination point allocation invalid");
            CoordinationSlider.value = myCharacter.Coordination.AllocationBonus;
            return;
        }
        else
        {
            myCharacter.Coordination.AllocationBonus += amount;
            attributePointBalance -= amount;
            UpdateAttributeUI();
        }
    }

    public void modAgility()
    {
        float amount = AgilitySlider.value - myCharacter.Agility.AllocationBonus;

        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            myCharacter.Agility.AllocationBonus + amount < 0
            )
        {
            Debug.Log("Agility point allocation invalid");
            AgilitySlider.value = myCharacter.Agility.AllocationBonus;
            return;
        }
        else
        {
            myCharacter.Agility.AllocationBonus += amount;
            attributePointBalance -= amount;
            UpdateAttributeUI();
        }
    }

    public void modWillpower()
    {
        float amount = WillpowerSlider.value - myCharacter.Willpower.AllocationBonus;

        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            myCharacter.Willpower.AllocationBonus + amount < 0
            )
        {
            Debug.Log("Willpower point allocation invalid");
            WillpowerSlider.value = myCharacter.Willpower.AllocationBonus;
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

        StrengthSlider.value = myCharacter.Strength.AllocationBonus;
        EnduranceSlider.value = myCharacter.Endurance.AllocationBonus;
        CoordinationSlider.value = myCharacter.Coordination.AllocationBonus;
        AgilitySlider.value = myCharacter.Agility.AllocationBonus;
        WillpowerSlider.value = myCharacter.Willpower.AllocationBonus;
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
