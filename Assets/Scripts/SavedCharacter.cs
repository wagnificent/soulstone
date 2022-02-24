using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedCharacter
{
    //Identity
    public int Race;

    //Attributes
    public float Strength;
    public float Endurance;
    public float Coordination;
    public float Agility;
    public float Willpower;

    //Weapon Skills
    public int Unarmed;
    public int OneHanded;
    public int TwoHanded;
    public int Archery;

    //Magic Skills
    public int CombatMagic;
    public int VitalMagic;
    public int SupportMagic;
    public int UtilityMagic;

    //Defensive Skills
    public int Block;
    public int Dodge;
    public int Parry;
    public int Harden;

    //Equipment
    public List<int> Weapons;
    public int Armor;
    public int Consumable;
    public int Trinket;

    //Abilities
    public List<int> PrimaryAbilities;
    public List<int> AlternateAbilities;

}
