using UnityEngine;
using UnityEngine.UI;

public enum WeaponType
{
    Unarmed = 100,
    OneHanded = 200,
    TwoHanded = 300,
    Bow = 400,
    Shield = 500
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{

    public string Name;
    public int WeaponID;
    public WeaponType WeaponType;
    public float BaseDamage; 
    public bool CanChannelMagic;
    public bool IsLarge;
    public bool IsEquipped;
    public bool IsActive;
    public Sprite Icon;

}
