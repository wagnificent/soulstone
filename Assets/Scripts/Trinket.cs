using UnityEngine;
using UnityEngine.UI;
using Wagnificent.CharacterStats;

public enum TrinketType
{
    Passive = 100,
    Active = 200
}

[CreateAssetMenu(fileName = "Trinket", menuName = "Trinket")]
public class Trinket : ScriptableObject
{
    public string Name;
    public int TrinketID;
    public TrinketType TrinketType;
    public Sprite Icon;
}
