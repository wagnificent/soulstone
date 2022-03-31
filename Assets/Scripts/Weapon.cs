using UnityEngine;

public enum WeaponType
{
    Unarmed,
    OneHanded,
    TwoHanded,
    Bow,
    Shield
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : Equipment
{
    public WeaponType WeaponType;
    public float BaseDamage; 
    public bool CanChannelMagic;
    public bool IsLarge;
    public bool IsEquipped;
    public bool IsActive;
}
