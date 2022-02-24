using UnityEngine;
using UnityEngine.UI;

public class TrinketSlot : MonoBehaviour
{
    public Trinket TrinketItem;

    private EquipmentSelector equipmentSelector;

    void Start()
    {
        equipmentSelector = FindObjectOfType<EquipmentSelector>();
    }

    public void EquipThis()
    {
        equipmentSelector.EquipTrinket(TrinketItem);
    }
}
