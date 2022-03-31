using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
    Trinket,
    Consumable
}

public class Equipment : ScriptableObject
{
    public EquipmentType type;
    public int ID;
    public string Name;
    public Sprite Icon;
}
