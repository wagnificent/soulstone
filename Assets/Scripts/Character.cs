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
    public string Name = null;

    public int Level = 1;

    public int Experience = 0;

    public Race Race = Race.Human;

    public ArmorRating ArmorRating = new ArmorRating();

    public Attribute[] Attributes = new Attribute[5];

    public Skill[] Skills = new Skill[12];

    //Equipment
    public Equipment[] Equipment = new Equipment[6];

    // Abilities
    public Ability[] PrimaryAbilities = new Ability[8];
    public Ability[] AlternateAbilities = new Ability[8];

}