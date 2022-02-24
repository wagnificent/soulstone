using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wagnificent.CharacterStats;

public enum Race
{
    Human,
    Elf,
    Orc,
    Dwarf,
    Halfling,
    Goblin
}

public class Character: MonoBehaviour
{

    public Race Race;

    public ArmorRating ArmorRating = new ArmorRating(1f);

    //Attributes
    public Attribute Strength = new Attribute(100f);
    public Attribute Endurance = new Attribute(100f);
    public Attribute Coordination = new Attribute(100f);
    public Attribute Agility = new Attribute(100f);
    public Attribute Willpower = new Attribute(100f);

    //Weapon Skills
    public Skill Unarmed = new Skill(100f);
    public Skill OneHanded = new Skill(100f);
    public Skill TwoHanded = new Skill(100f);
    public Skill Archery = new Skill(100f);

    //Magic Skills
    public Skill CombatMagic = new Skill(100f);
    public Skill VitalMagic = new Skill(100f);
    public Skill SupportMagic = new Skill(100f);
    public Skill UtilityMagic = new Skill(100f);

    //Defensive Skills
    public Skill Block = new Skill(100f);
    public Skill Dodge = new Skill(100f);
    public Skill Parry = new Skill(100f);
    public Skill Harden = new Skill(100f);

    //Equipment
    public Weapon[] Weapons = new Weapon[3];
    public Armor Armor;
    public Consumable Consumable;
    public Trinket Trinket;

    // Abilities
    public Ability[] PrimaryAbilities = new Ability[8];
    public Ability[] AlternateAbilities = new Ability[8];

}