using UnityEngine;

public enum ArmorType
{
    Light,
    Medium,
    Heavy
}

[CreateAssetMenu(fileName = "Armor", menuName = "Armor")]
public class Armor : Equipment
{
    public ArmorType ArmorType;
    public float BaseProtection;
}
