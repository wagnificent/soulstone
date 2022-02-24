using UnityEngine;
using UnityEngine.UI;

public class ArmorSlot : MonoBehaviour
{
    public Armor ArmorItem;

    private EquipmentSelector equipmentSelector;

    void Start()
    {
        equipmentSelector = FindObjectOfType<EquipmentSelector>();
    }

    public void EquipThis()
    {
        equipmentSelector.EquipArmor(ArmorItem);
    }
}
