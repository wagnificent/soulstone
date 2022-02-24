using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{

    public Weapon WeaponItem;

    private EquipmentSelector equipmentSelector;

    void Start()
    {
        equipmentSelector = FindObjectOfType<EquipmentSelector>();
    }

    public void EquipThis(int slotIndex)
    {
        if(slotIndex == 0)
        {
            equipmentSelector.equipWeapon0(WeaponItem);
        }
        else if(slotIndex == 1)
        {
            equipmentSelector.equipWeapon1(WeaponItem);
        }
        else if (slotIndex == 2)
        {
            equipmentSelector.equipWeapon2(WeaponItem);
        }
        else
        {
            Debug.Log("Weapon slot index not found");
            return;
        }
    }

}
