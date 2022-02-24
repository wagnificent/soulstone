using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wagnificent.CharacterStats;

public class IdentityGenerator : MonoBehaviour
{

    public Character myCharacter;

    public Text StrengthValue;

    public void LoadIdentity(Character character)
    {
        myCharacter = character;
        myCharacter.Race = character.Race;
        UpdateRacialBonuses(myCharacter.Race);
        UpdateIdentityUI();
    }

    public void MakeHuman()
    {
        myCharacter.Race = Race.Human;
        UpdateRacialBonuses(myCharacter.Race);
        UpdateIdentityUI();
    }

    public void MakeElf()
    {
        myCharacter.Race = Race.Elf;
        UpdateRacialBonuses(myCharacter.Race);
        UpdateIdentityUI();
    }

    public void MakeOrc()
    {
        myCharacter.Race = Race.Orc;
        UpdateRacialBonuses(myCharacter.Race);
        UpdateIdentityUI();
    }

    public void MakeDwarf()
    {
        myCharacter.Race = Race.Dwarf;
        UpdateRacialBonuses(myCharacter.Race);
        UpdateIdentityUI();
    }

    public void MakeHalfling()
    {
        myCharacter.Race = Race.Halfling;
        UpdateRacialBonuses(myCharacter.Race);
        UpdateIdentityUI();
    }

    public void MakeGoblin()
    {
        myCharacter.Race = Race.Goblin;
        UpdateRacialBonuses(myCharacter.Race);
        UpdateIdentityUI();
    }

    private void UpdateRacialBonuses(Race race)
    {
        if(race == Race.Human)
        {
            myCharacter.Strength.RacialBonus = 0f;
            myCharacter.Endurance.RacialBonus = 0f;
            myCharacter.Coordination.RacialBonus = 0f;
            myCharacter.Agility.RacialBonus = 0f;
            myCharacter.Willpower.RacialBonus = 0f;
        }
        else if (race == Race.Elf)
        {
            myCharacter.Strength.RacialBonus = -10f;
            myCharacter.Endurance.RacialBonus = -10f;
            myCharacter.Coordination.RacialBonus = 0f;
            myCharacter.Agility.RacialBonus = 0f;
            myCharacter.Willpower.RacialBonus = 20f;
        }
        else if (race == Race.Orc)
        {
            myCharacter.Strength.RacialBonus = 10f;
            myCharacter.Endurance.RacialBonus = 10f;
            myCharacter.Coordination.RacialBonus = 0f;
            myCharacter.Agility.RacialBonus = 0f;
            myCharacter.Willpower.RacialBonus = -20f;
        }
        else if (race == Race.Dwarf)
        {
            myCharacter.Strength.RacialBonus = 0f;
            myCharacter.Endurance.RacialBonus = 20f;
            myCharacter.Coordination.RacialBonus = 0f;
            myCharacter.Agility.RacialBonus = -20f;
            myCharacter.Willpower.RacialBonus = 0f;
        }
        else if (race == Race.Halfling)
        {
            myCharacter.Strength.RacialBonus = -10f;
            myCharacter.Endurance.RacialBonus = -10f;
            myCharacter.Coordination.RacialBonus = 10f;
            myCharacter.Agility.RacialBonus = 10f;
            myCharacter.Willpower.RacialBonus = 0f;
        }
        else if (race == Race.Goblin)
        {
            myCharacter.Strength.RacialBonus = 10f;
            myCharacter.Endurance.RacialBonus = 0f;
            myCharacter.Coordination.RacialBonus = 0f;
            myCharacter.Agility.RacialBonus = 10f;
            myCharacter.Willpower.RacialBonus = -20f;
        }
        else
        {
            Debug.Log("Race type not recognized");
            return;
        }
    }

    private void UpdateIdentityUI()
    {
        Debug.Log("You still need to update the Identity UI!");
    }

}
