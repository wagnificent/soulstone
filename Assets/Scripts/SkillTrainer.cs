using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wagnificent.CharacterStats;

public class SkillTrainer : MonoBehaviour
{
    public Character myCharacter;

    public Text SkillPointTracker;
    public Text UnarmedBonus;
    public Text OneHandedBonus;
    public Text TwoHandedBonus;
    public Text ArcheryBonus;
    public Text CombatMagicBonus;
    public Text VitalMagicBonus;
    public Text SupportMagicBonus;
    public Text UtilityMagicBonus;
    public Text BlockBonus;
    public Text DodgeBonus;
    public Text ParryBonus;
    public Text HardenBonus;

    public float SkillPointMax = 300;
    public float SkillPointBalance;


    public void LoadSkills(Character character)
    {
        myCharacter = character;
        UpdateTrainingBonuses();
        UpdateSkillBalance();
        UpdateSkillUI();
    }

    public void ModUnarmed(int skillLevel)
    {
        float previousValue = myCharacter.Unarmed.TrainingBonus;
        int previousSkill = myCharacter.Unarmed.SkillLevel;

        myCharacter.Unarmed.TrainingBonus = (skillLevel * 50);
        myCharacter.Unarmed.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.Unarmed.TrainingBonus = previousValue;
            myCharacter.Unarmed.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModOneHanded(int skillLevel)
    {
        float previousValue = myCharacter.OneHanded.TrainingBonus;
        int previousSkill = myCharacter.OneHanded.SkillLevel;

        myCharacter.OneHanded.TrainingBonus = (skillLevel * 50);
        myCharacter.OneHanded.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.OneHanded.TrainingBonus = previousValue;
            myCharacter.OneHanded.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModTwoHanded(int skillLevel)
    {
        float previousValue = myCharacter.TwoHanded.TrainingBonus;
        int previousSkill = myCharacter.TwoHanded.SkillLevel;

        myCharacter.TwoHanded.TrainingBonus = (skillLevel * 50);
        myCharacter.TwoHanded.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.TwoHanded.TrainingBonus = previousValue;
            myCharacter.TwoHanded.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModArchery(int skillLevel)
    {
        float previousValue = myCharacter.Archery.TrainingBonus;
        int previousSkill = myCharacter.Archery.SkillLevel;

        myCharacter.Archery.TrainingBonus = (skillLevel * 50);
        myCharacter.Archery.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.Archery.TrainingBonus = previousValue;
            myCharacter.Archery.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModCombatMagic(int skillLevel)
    {
        float previousValue = myCharacter.CombatMagic.TrainingBonus;
        int previousSkill = myCharacter.CombatMagic.SkillLevel;

        myCharacter.CombatMagic.TrainingBonus = (skillLevel * 50);
        myCharacter.CombatMagic.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.CombatMagic.TrainingBonus = previousValue;
            myCharacter.CombatMagic.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModVitalMagic(int skillLevel)
    {
        float previousValue = myCharacter.VitalMagic.TrainingBonus;
        int previousSkill = myCharacter.VitalMagic.SkillLevel;

        myCharacter.VitalMagic.TrainingBonus = (skillLevel * 50);
        myCharacter.VitalMagic.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.VitalMagic.TrainingBonus = previousValue;
            myCharacter.VitalMagic.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModSupportMagic(int skillLevel)
    {
        float previousValue = myCharacter.SupportMagic.TrainingBonus;
        int previousSkill = myCharacter.SupportMagic.SkillLevel;

        myCharacter.SupportMagic.TrainingBonus = (skillLevel * 50);
        myCharacter.SupportMagic.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.SupportMagic.TrainingBonus = previousValue;
            myCharacter.SupportMagic.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModUtilityMagic(int skillLevel)
    {
        float previousValue = myCharacter.UtilityMagic.TrainingBonus;
        int previousSkill = myCharacter.UtilityMagic.SkillLevel;

        myCharacter.UtilityMagic.TrainingBonus = (skillLevel * 50);
        myCharacter.UtilityMagic.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.UtilityMagic.TrainingBonus = previousValue;
            myCharacter.UtilityMagic.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModBlock(int skillLevel)
    {
        float previousValue = myCharacter.Block.TrainingBonus;
        int previousSkill = myCharacter.Block.SkillLevel;

        myCharacter.Block.TrainingBonus = (skillLevel * 50);
        myCharacter.Block.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.Block.TrainingBonus = previousValue;
            myCharacter.Block.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModDodge(int skillLevel)
    {
        float previousValue = myCharacter.Dodge.TrainingBonus;
        int previousSkill = myCharacter.Dodge.SkillLevel;

        myCharacter.Dodge.TrainingBonus = (skillLevel * 50);
        myCharacter.Dodge.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.Dodge.TrainingBonus = previousValue;
            myCharacter.Dodge.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModParry(int skillLevel)
    {
        float previousValue = myCharacter.Parry.TrainingBonus;
        int previousSkill = myCharacter.Parry.SkillLevel;

        myCharacter.Parry.TrainingBonus = (skillLevel * 50);
        myCharacter.Parry.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.Parry.TrainingBonus = previousValue;
            myCharacter.Parry.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    public void ModHarden(int skillLevel)
    {
        float previousValue = myCharacter.Harden.TrainingBonus;
        int previousSkill = myCharacter.Harden.SkillLevel;

        myCharacter.Harden.TrainingBonus = (skillLevel * 50);
        myCharacter.Harden.SkillLevel = skillLevel;
        UpdateSkillBalance();

        if (SkillPointBalance < 0)
        {
            Debug.Log("You do not have enough skill points for this");
            myCharacter.Harden.TrainingBonus = previousValue;
            myCharacter.Harden.SkillLevel = previousSkill;
        }
        else
        {
            UpdateSkillUI();
        }
    }

    private void UpdateTrainingBonuses()
    {
        myCharacter.Unarmed.TrainingBonus = (myCharacter.Unarmed.SkillLevel * 50);
        myCharacter.OneHanded.TrainingBonus = (myCharacter.OneHanded.SkillLevel * 50);
        myCharacter.TwoHanded.TrainingBonus = (myCharacter.TwoHanded.SkillLevel * 50);
        myCharacter.Archery.TrainingBonus = (myCharacter.Archery.SkillLevel * 50);
        myCharacter.CombatMagic.TrainingBonus = (myCharacter.CombatMagic.SkillLevel * 50);
        myCharacter.VitalMagic.TrainingBonus = (myCharacter.VitalMagic.SkillLevel * 50);
        myCharacter.SupportMagic.TrainingBonus = (myCharacter.SupportMagic.SkillLevel * 50);
        myCharacter.UtilityMagic.TrainingBonus = (myCharacter.UtilityMagic.SkillLevel * 50);
        myCharacter.Block.TrainingBonus = (myCharacter.Block.SkillLevel * 50);
        myCharacter.Dodge.TrainingBonus = (myCharacter.Dodge.SkillLevel * 50);
        myCharacter.Parry.TrainingBonus = (myCharacter.Parry.SkillLevel * 50);
        myCharacter.Harden.TrainingBonus = (myCharacter.Harden.SkillLevel * 50);
    }

    private void UpdateSkillBalance()
    {
        SkillPointBalance = (
            SkillPointMax -
            myCharacter.Unarmed.TrainingBonus -
            myCharacter.OneHanded.TrainingBonus -
            myCharacter.TwoHanded.TrainingBonus -
            myCharacter.Archery.TrainingBonus -
            myCharacter.CombatMagic.TrainingBonus -
            myCharacter.VitalMagic.TrainingBonus -
            myCharacter.SupportMagic.TrainingBonus -
            myCharacter.UtilityMagic.TrainingBonus -
            myCharacter.Block.TrainingBonus -
            myCharacter.Dodge.TrainingBonus -
            myCharacter.Parry.TrainingBonus -
            myCharacter.Harden.TrainingBonus
        );
    }

    private void UpdateSkillUI()
    {
        SkillPointTracker.text = SkillPointBalance.ToString();
        UnarmedBonus.text = myCharacter.Unarmed.TrainingBonus.ToString();
        OneHandedBonus.text = myCharacter.OneHanded.TrainingBonus.ToString();
        TwoHandedBonus.text = myCharacter.TwoHanded.TrainingBonus.ToString();
        ArcheryBonus.text = myCharacter.Archery.TrainingBonus.ToString();
        CombatMagicBonus.text = myCharacter.CombatMagic.TrainingBonus.ToString();
        VitalMagicBonus.text = myCharacter.VitalMagic.TrainingBonus.ToString();
        SupportMagicBonus.text = myCharacter.SupportMagic.TrainingBonus.ToString();
        UtilityMagicBonus.text = myCharacter.UtilityMagic.TrainingBonus.ToString();
        BlockBonus.text = myCharacter.Block.TrainingBonus.ToString();
        DodgeBonus.text = myCharacter.Dodge.TrainingBonus.ToString();
        ParryBonus.text = myCharacter.Parry.TrainingBonus.ToString();
        HardenBonus.text = myCharacter.Harden.TrainingBonus.ToString();
    }

}
