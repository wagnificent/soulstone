using UnityEngine;

public enum ConsumableType
{
    Potion,
    Scroll,
    Trap,
    Grenade
}

[CreateAssetMenu(fileName = "Consumable", menuName = "Consumable")]
public class Consumable : Equipment
{
    public ConsumableType ConsumableType;
}
