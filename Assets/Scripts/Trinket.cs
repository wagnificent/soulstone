using UnityEngine;

public enum TrinketType
{
    Passive = 100,
    Active = 200
}

[CreateAssetMenu(fileName = "Trinket", menuName = "Trinket")]
public class Trinket : Equipment
{
    public TrinketType TrinketType;
}
