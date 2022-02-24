using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSelector : MonoBehaviour
{
    public Character myCharacter;
    private MasterList masterList;

    public Text[] WeaponName;
    public Text ArmorName;
    public Text ConsumableName;
    public Text TrinketName;

    public WeaponSlot[] WeaponInventory0;
    public WeaponSlot[] WeaponInventory1;
    public WeaponSlot[] WeaponInventory2;
    public ArmorSlot[] ArmorInventory;
    public ConsumableSlot[] ConsumableInventory;
    public TrinketSlot[] TrinketInventory;

    private bool HasShield = false;
    private bool HasBow = false;


    void Start()
    {
        masterList = FindObjectOfType<MasterList>();
        PopulateInventory();
        UpdateEquipmentUI();
    }

    public void LoadEquipment(Character character)
    {
        myCharacter = character;
        UpdateEquipmentUI();
    }

    public void PopulateInventory()
    {
        for (int i = 0; i < masterList.Weapons.Count; i++)
        {
            WeaponInventory0[i].WeaponItem = masterList.Weapons[i];
            WeaponInventory0[i].GetComponent<Image>().sprite = masterList.Weapons[i].Icon;
        }
        for (int i = 0; i < masterList.Weapons.Count; i++)
        {
            WeaponInventory1[i].WeaponItem = masterList.Weapons[i];
            WeaponInventory1[i].GetComponent<Image>().sprite = masterList.Weapons[i].Icon;
        }
        for (int i = 0; i < masterList.Weapons.Count; i++)
        {
            WeaponInventory2[i].WeaponItem = masterList.Weapons[i];
            WeaponInventory2[i].GetComponent<Image>().sprite = masterList.Weapons[i].Icon;
        }
        for(int i = 0; i < masterList.Armor.Count; i++)
        {
            ArmorInventory[i].ArmorItem = masterList.Armor[i];
            ArmorInventory[i].GetComponent<Image>().sprite = masterList.Armor[i].Icon;
        }
        for (int i = 0; i < masterList.Consumables.Count; i++)
        {
            ConsumableInventory[i].ConsumableItem = masterList.Consumables[i];
            ConsumableInventory[i].GetComponent<Image>().sprite = masterList.Consumables[i].Icon;
        }
        for (int i = 0; i < masterList.Trinkets.Count; i++)
        {
            TrinketInventory[i].TrinketItem = masterList.Trinkets[i];
            TrinketInventory[i].GetComponent<Image>().sprite = masterList.Trinkets[i].Icon;
        }
    }

    public void equipWeapon0(Weapon weapon)
    {
        if (!CanEquip(weapon))
        {
            return;
        }
        else
        {
            myCharacter.Weapons[0] = weapon;
            if (weapon.IsLarge == true) { myCharacter.Weapons[1] = null; }
            if (myCharacter.Weapons[1] != null && myCharacter.Weapons[1].IsLarge) { myCharacter.Weapons[1] = null; }
            CheckForBowShield();
            UpdateEquipmentUI();
        }
    }

    public void equipWeapon1(Weapon weapon)
    {
        if (!CanEquip(weapon))
        {
            return;
        }
        else
        {
            myCharacter.Weapons[1] = weapon;
            if (weapon.IsLarge == true) { myCharacter.Weapons[0] = null; }
            if (myCharacter.Weapons[0] != null && myCharacter.Weapons[0].IsLarge) { myCharacter.Weapons[0] = null; }
            CheckForBowShield();
            UpdateEquipmentUI();
        }
    }

    public void equipWeapon2(Weapon weapon)
    {
        if (!CanEquip(weapon))
        {
            return;
        }
        else
        {
            myCharacter.Weapons[2] = weapon;
            CheckForBowShield();
            UpdateEquipmentUI();
        }
    }

    private bool CanEquip(Weapon weapon)
    {
        if (weapon.WeaponType == WeaponType.Shield && HasShield == true)
        {
            Debug.Log("Character already has a shield");
            return false;
        }
        else if (weapon.WeaponType == WeaponType.Bow && HasBow == true)
        {
            Debug.Log("Character already has a bow");
            return false;
        }
        else
        {
            return true;
        }
    }

    private void CheckForBowShield()
    {
        int bowCount = 0;
        int shieldCount = 0;

        for (int i = 0; i < myCharacter.Weapons.Length; i++)
        {
            if (myCharacter.Weapons[i] != null && myCharacter.Weapons[i].WeaponType == WeaponType.Shield)
            {
                shieldCount++;
            }
            if (myCharacter.Weapons[i] != null && myCharacter.Weapons[i].WeaponType == WeaponType.Bow)
            {
                bowCount++;
            }
        }

        if (bowCount == 0)
        {
            HasBow = false;
        }
        if (bowCount > 0)
        {
            HasBow = true;
        }
        if (shieldCount == 0)
        {
            HasShield = false;
        }
        if (shieldCount > 0)
        {
            HasShield = true;
        }
    }

    public void EquipArmor(Armor armor)
    {
        myCharacter.Armor = armor;
        UpdateEquipmentUI();
    }

    public void EquipConsumable(Consumable consumable)
    {
        myCharacter.Consumable = consumable;
        UpdateEquipmentUI();
    }

    public void EquipTrinket(Trinket trinket)
    {
        myCharacter.Trinket = trinket;
        UpdateEquipmentUI();
    }

    private void UpdateEquipmentUI()
    {
        for(int i = 0; i < myCharacter.Weapons.Length; i++)
        {
            if(myCharacter.Weapons[i] != null)
            {
                WeaponName[i].text = myCharacter.Weapons[i].Name;
            }
            else
            {
                WeaponName[i].text = "Empty";
            }
        }

        if(myCharacter.Armor != null)
        {
            ArmorName.text = myCharacter.Armor.Name;
        }
        if(myCharacter.Armor == null)
        {
            ArmorName.text = "Empty";
        }

        if(myCharacter.Consumable != null)
        {
            ConsumableName.text = myCharacter.Consumable.Name;
        }
        if(myCharacter.Consumable == null)
        {
            ConsumableName.text = "Empty";
        }

        if (myCharacter.Trinket != null)
        {
            TrinketName.text = myCharacter.Trinket.Name;
        }
        if (myCharacter.Trinket == null)
        {
            TrinketName.text = "Empty";
        }
    }
}
