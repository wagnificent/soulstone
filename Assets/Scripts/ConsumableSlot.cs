using UnityEngine;
using UnityEngine.UI;

public class ConsumableSlot : MonoBehaviour
{
    public Consumable ConsumableItem;

    private EquipmentSelector equipmentSelector;

    void Start()
    {
        equipmentSelector = FindObjectOfType<EquipmentSelector>();
    }

    public void EquipThis()
    {
        equipmentSelector.EquipConsumable(ConsumableItem);
    }
}