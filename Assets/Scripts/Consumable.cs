using UnityEngine;
using UnityEngine.UI;

public enum ConsumableType
{
    Potion = 100,
    Scroll = 200,
    Trap = 300,
    Grenade = 400
}

[CreateAssetMenu(fileName = "Consumable", menuName = "Consumable")]
public class Consumable : ScriptableObject
{
    public string Name;
    public int ConsumableID;
    public ConsumableType ConsumableType;
    public Sprite Icon;
}
