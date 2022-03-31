using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    public Character character;

    private UIManager uiManager;
    private SaveHandler saveHandler;
    private MasterList masterList;

    private int activeCharacterSlot = 0;

    private int attributePointMax = 100;
    private int attributePointBalance;

    private int SkillPointMax = 300;
    private int SkillPointBalance;

    private void Start()
    {
        saveHandler = GetComponent<SaveHandler>();
        masterList = FindObjectOfType<MasterList>();
        character = FindObjectOfType<Character>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void EditCharacterSlot(int slotIndex)
    {
        activeCharacterSlot = slotIndex;

        if (saveHandler.IsSlotFilled(activeCharacterSlot)) 
        {
            saveHandler.LoadCharacter(character, activeCharacterSlot);
        }

        InitializeCharacter();

        uiManager.OpenCharacterEditor();
    }

    public void SaveCharacter()
    {
        saveHandler.SaveCharacter(character, activeCharacterSlot);
        Debug.Log("Character saved");

        uiManager.OpenTitleMenu();
        uiManager.OpenTitlePanel("Character Slots");
    }

    public void LoadCharacter(int slotIndex)
    {
        saveHandler.LoadCharacter(character, slotIndex);
        Debug.Log("Character loaded");
    }

    private void InitializeCharacter()
    {
        //Race (model)
        UpdateRacialBonuses(character.Race);
        uiManager.UpdateIdentityUI(character);


        //Attributes
        attributePointBalance = attributePointMax;

        for (int i = 0; i < character.Attributes.Length; i++)
        {
            attributePointBalance -= character.Attributes[i].AllocationBonus;
            uiManager.UpdateAttributeUI(character.Attributes[i], i, attributePointBalance);
        }


        //Skills
        for (int i = 0; i < character.Skills.Length; i++)
        {
            character.Skills[i].TrainingBonus = (character.Skills[i].SkillLevel * 50);
            SkillPointBalance -= character.Skills[i].TrainingBonus;
            uiManager.UpdateSkillUI(i, character.Skills[i].SkillLevel, SkillPointBalance);
        }


        //Equipment
        for (int i = 0; i < character.Equipment.Length; i++)
        {
            uiManager.UpdateEquipmentUI(character.Equipment[i], i);
        }


        //Abilities
        for (int i = 0; i < character.PrimaryAbilities.Length; i++)
        {
            uiManager.UpdateAbilitiesUI(character.PrimaryAbilities[i], i);
        }
    }

    public void SelectRace(int raceIndex)
    {
        character.Race = (Race)raceIndex;
        UpdateRacialBonuses(character.Race);
        uiManager.UpdateIdentityUI(character);
    }

    private void UpdateRacialBonuses(Race race)
    {
        if (race == Race.Human)
        {
            character.Attributes[0].RacialBonus = 0;
            character.Attributes[1].RacialBonus = 0;
            character.Attributes[2].RacialBonus = 0;
            character.Attributes[3].RacialBonus = 0;
            character.Attributes[4].RacialBonus = 0;
        }
        else if (race == Race.Elf)
        {
            character.Attributes[0].RacialBonus = -10;
            character.Attributes[1].RacialBonus = -10;
            character.Attributes[2].RacialBonus = 0;
            character.Attributes[3].RacialBonus = 0;
            character.Attributes[4].RacialBonus = 20;
        }
        else if (race == Race.Orc)
        {
            character.Attributes[0].RacialBonus = 10;
            character.Attributes[1].RacialBonus = 10;
            character.Attributes[2].RacialBonus = 0;
            character.Attributes[3].RacialBonus = 0;
            character.Attributes[4].RacialBonus = -20;
        }
        else if (race == Race.Dwarf)
        {
            character.Attributes[0].RacialBonus = 0;
            character.Attributes[1].RacialBonus = 20;
            character.Attributes[2].RacialBonus = 0;
            character.Attributes[3].RacialBonus = -20;
            character.Attributes[4].RacialBonus = 0;
        }
        else if (race == Race.Halfling)
        {
            character.Attributes[0].RacialBonus = -10;
            character.Attributes[1].RacialBonus = -10;
            character.Attributes[2].RacialBonus = 10;
            character.Attributes[3].RacialBonus = 10;
            character.Attributes[4].RacialBonus = 0;
        }
        else if (race == Race.Goblin)
        {
            character.Attributes[0].RacialBonus = 10;
            character.Attributes[1].RacialBonus = 0;
            character.Attributes[2].RacialBonus = 0;
            character.Attributes[3].RacialBonus = 10;
            character.Attributes[4].RacialBonus = -20;
        }
        else
        {
            Debug.Log("Race type not recognized");
            return;
        }
    }

    public void ModAttribute(int index, int value)
    {
        int amount = value - character.Attributes[index].AllocationBonus;

        if (
            attributePointBalance - amount > attributePointMax ||
            attributePointBalance - amount < 0 ||
            character.Attributes[index].AllocationBonus + amount < 0
            )
        {
            Debug.Log("Point allocation outside of valide range");
        }
        else
        {
            character.Attributes[index].AllocationBonus += amount;
            attributePointBalance -= amount;
        }

        uiManager.UpdateAttributeUI(character.Attributes[index], index, attributePointBalance);
    }

    public void TrainSkill(int index, int level)
    {
        character.Skills[index].TrainingBonus = level * 50;
        UpdateSkillBalance();

        //Check to see if the player can afford to train that skill to that level
        if (SkillPointBalance < 0 || SkillPointBalance > SkillPointMax)
        {
            //Revert the change
            character.Skills[index].TrainingBonus = character.Skills[index].SkillLevel * 50;
            UpdateSkillBalance();
            uiManager.OpenCharacterPanel("Skills Panel");
            Debug.Log("SkillPointBalance outside of valid range");
        }
        else
        {
            //Accept the change and move the icon
            character.Skills[index].SkillLevel = level;
            uiManager.UpdateSkillUI(index, level, SkillPointBalance);
        }
    }

    private void UpdateSkillBalance()
    {
        SkillPointBalance = SkillPointMax;

        for (int i = 0; i < character.Skills.Length; i++)
        {
            SkillPointBalance -= character.Skills[i].TrainingBonus;
        }
    }

    public void EquipAbility(int id, int index, bool isPrimary)
    {
        if (isPrimary)
        {
            character.PrimaryAbilities[index] = masterList.GetAbility(id);
            uiManager.UpdateAbilitiesUI(character.PrimaryAbilities[index], index);
        }
        else
        {
            character.AlternateAbilities[index] = masterList.GetAbility(id);
            uiManager.UpdateAbilitiesUI(character.AlternateAbilities[index], index);
        }
    }

    public void EquipItem(int type, int ID, int slot)
    {
        Equipment e = masterList.GetEquipment((EquipmentType)type, ID);
        if(e.type == 0 && slot < 3)
        {
            Weapon w = e as Weapon;
            checkEquippedWeapons(w, slot);
            character.Equipment[slot] = w;
        }
        else if (e.type == (EquipmentType)1)
        {
            Armor a = e as Armor;
            character.Equipment[slot] = a;
        }
        else if (e.type == (EquipmentType)2)
        {
            Trinket t = e as Trinket;
            character.Equipment[slot] = t;
        }
        else if (e.type == (EquipmentType)3)
        {
            Consumable c = e as Consumable;
            character.Equipment[slot] = c;
        }
        else
        {
            Debug.Log("Couldn't equip that item");
        }

        uiManager.UpdateEquipmentUI(e, slot);
    }

    private void checkEquippedWeapons(Weapon weapon, int slot)
    {
        if (weapon.WeaponType == WeaponType.Shield)
        {
            checkForShield();
        }
        
        if (weapon.WeaponType == WeaponType.Bow)
        {
            checkForBow();
        }
        
        if (slot < 2)
        {
            checkForLarge(weapon.IsLarge, slot);
        }
        
    }

    private void checkForBow()
    {

        for (int i = 0; i < 3; i++)
        {
            Weapon w = character.Equipment[i] as Weapon;

            if (w != null && w.WeaponType == WeaponType.Bow)
            {
                character.Equipment[i] = null;
                uiManager.UpdateEquipmentUI(character.Equipment[i], i);
                Debug.Log("You can only carry one bow.  Unequipping other bow");
            }
        }
    }

    private void checkForShield()
    {

        for (int i = 0; i < 3; i++)
        {
            Weapon w = character.Equipment[i] as Weapon;

            if (w != null && w.WeaponType == WeaponType.Shield)
            {
                character.Equipment[i] = null;
                uiManager.UpdateEquipmentUI(character.Equipment[i], i);
                Debug.Log("You can only carry one shield.  Unequipping other shield");
            }
        }
    }

    private void checkForLarge(bool isNewWeaponLarge, int slot)
    {
        if (isNewWeaponLarge) 
        {
            int i = Mathf.Abs(slot - 1);
            character.Equipment[i] = null;
            uiManager.UpdateEquipmentUI(character.Equipment[i], i);
            Debug.Log("Other weapon requires two hands.  Unequipping other weapon");
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                Weapon w = character.Equipment[i] as Weapon;

                if (w != null && w.IsLarge)
                {
                    character.Equipment[i] = null;
                    uiManager.UpdateEquipmentUI(character.Equipment[i], i);
                    Debug.Log("This weapon requires two hands.  Unequipping other weapon");
                }
            }
        }

    }

}
