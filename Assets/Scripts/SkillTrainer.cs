using UnityEngine;
using UnityEngine.UI;
using Wagnificent.CharacterStats;

public class SkillTrainer : MonoBehaviour
{
    public Character myCharacter;

    public Text SkillPointTracker;

    public GameObject[] TrainingPanels;
    public GameObject[] SkillIcons;

    public GameObject NovicePanel;
    public GameObject AdeptPanel;
    public GameObject MasterPanel;

    public GameObject UnarmedIcon;
    public GameObject OneHandedIcon;
    public GameObject TwoHandedIcon;
    public GameObject ArcheryIcon;
    public GameObject CombatIcon;
    public GameObject VitalIcon;
    public GameObject SupportIcon;
    public GameObject UtilityIcon;
    public GameObject DodgeIcon;
    public GameObject BlockIcon;
    public GameObject ParryIcon;
    public GameObject HardenIcon;

    public float SkillPointMax = 300;
    public float SkillPointBalance;


    public void LoadSkills(Character character)
    {
        myCharacter = character;
        UpdateTrainingBonuses();
        UpdateSkillBalance();
        UpdateSkillUI();
        UpdateSkillIcons();
    }

    public void MoveToNovice(GameObject skillButton)
    {
        skillButton.transform.SetParent(NovicePanel.transform);
    }

    public void MoveToAdept(GameObject skillButton)
    {
        skillButton.transform.SetParent(AdeptPanel.transform);
        Debug.Log(skillButton.name + " moved to Adept Panel!");
    }

    public void MoveToMaster(GameObject skillButton)
    {
        skillButton.transform.SetParent(MasterPanel.transform);
        Debug.Log(skillButton.name + " moved to Master Panel!");
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
    }

    private void UpdateSkillIcons()
    {
        //Move the skill icons to the appropriate panel
        if (myCharacter.Unarmed.SkillLevel == 2) { MoveToMaster(UnarmedIcon); }
        else if (myCharacter.Unarmed.SkillLevel == 1) { MoveToAdept(UnarmedIcon); }

        if (myCharacter.OneHanded.SkillLevel == 2) { MoveToMaster(OneHandedIcon); }
        else if (myCharacter.OneHanded.SkillLevel == 1) { MoveToAdept(OneHandedIcon); }

        if (myCharacter.TwoHanded.SkillLevel == 2) { MoveToMaster(TwoHandedIcon); }
        else if (myCharacter.TwoHanded.SkillLevel == 1) { MoveToAdept(TwoHandedIcon); }

        if (myCharacter.Archery.SkillLevel == 2) { MoveToMaster(ArcheryIcon); }
        else if (myCharacter.Archery.SkillLevel == 1) { MoveToAdept(ArcheryIcon); }

        if (myCharacter.CombatMagic.SkillLevel == 2) { MoveToMaster(CombatIcon); }
        else if (myCharacter.CombatMagic.SkillLevel == 1) { MoveToAdept(CombatIcon); }

        if (myCharacter.VitalMagic.SkillLevel == 2) { MoveToMaster(VitalIcon); }
        else if (myCharacter.VitalMagic.SkillLevel == 1) { MoveToAdept(VitalIcon); }

        if (myCharacter.SupportMagic.SkillLevel == 2) { MoveToMaster(SupportIcon); }
        else if (myCharacter.SupportMagic.SkillLevel == 1) { MoveToAdept(SupportIcon); }

        if (myCharacter.UtilityMagic.SkillLevel == 2) { MoveToMaster(UtilityIcon); }
        else if (myCharacter.UtilityMagic.SkillLevel == 1) { MoveToAdept(UtilityIcon); }

        if (myCharacter.Dodge.SkillLevel == 2) { MoveToMaster(DodgeIcon); }
        else if (myCharacter.Dodge.SkillLevel == 1) { MoveToAdept(DodgeIcon); }

        if (myCharacter.Block.SkillLevel == 2) { MoveToMaster(BlockIcon); }
        else if (myCharacter.Block.SkillLevel == 1) { MoveToAdept(BlockIcon); }

        if (myCharacter.Parry.SkillLevel == 2) { MoveToMaster(ParryIcon); }
        else if (myCharacter.Parry.SkillLevel == 1) { MoveToAdept(ParryIcon); }

        if (myCharacter.Harden.SkillLevel == 2) { MoveToMaster(HardenIcon); }
        else if (myCharacter.Harden.SkillLevel == 1) { MoveToAdept(HardenIcon); }
    }

    public bool TrainSkill(int skillIndex, int skillLevel)
    {
        Skill targetSkill = RetrieveSkill(skillIndex);

        targetSkill.TrainingBonus = skillLevel * 50;
        UpdateSkillBalance();

        //Check to see if the player can afford to train that skill to that level
        if (SkillPointBalance < 0 || SkillPointBalance > SkillPointMax)
        {
            //Revert the change
            targetSkill.TrainingBonus = targetSkill.SkillLevel * 50;
            UpdateSkillBalance();
            Debug.Log("SkillPointBalance outside of valid range");
            return false;
        }
        else
        {
            //Accept the change and move the icon
            targetSkill.SkillLevel = skillLevel;
            SkillIcons[skillIndex].transform.parent = TrainingPanels[skillLevel].transform;
            UpdateSkillUI();
            Debug.Log(targetSkill + " has been trained to level " + skillLevel);
            return true;
        }
    }

    private Skill RetrieveSkill(int skillIndex)
    {
        if (skillIndex == 0) { return myCharacter.Unarmed; }
        if (skillIndex == 1) { return myCharacter.OneHanded; }
        if (skillIndex == 2) { return myCharacter.TwoHanded; }
        if (skillIndex == 3) { return myCharacter.Archery; }
        if (skillIndex == 4) { return myCharacter.CombatMagic; }
        if (skillIndex == 5) { return myCharacter.VitalMagic; }
        if (skillIndex == 6) { return myCharacter.SupportMagic; }
        if (skillIndex == 7) { return myCharacter.UtilityMagic; }
        if (skillIndex == 8) { return myCharacter.Dodge; }
        if (skillIndex == 9) { return myCharacter.Block; }
        if (skillIndex == 10) { return myCharacter.Parry; }
        if (skillIndex == 11) { return myCharacter.Harden; }
        else 
        {
            Debug.Log("Skill not found");
            return null; 
        }
    }

}
