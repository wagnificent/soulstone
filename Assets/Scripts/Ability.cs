using UnityEngine;
using UnityEngine.UI;

public enum AbilityType
{
    Unarmed = 100,
    OneHanded = 200,
    TwoHanded = 300,
    Archery = 400,
    CombatMagic = 500,
    VitalMagic = 600,
    SupportMagic = 700,
    UtilityMagic = 800,
    Block = 900,
    Dodge = 1000,
    Parry = 1100,
    Harden = 1200
}

public enum EffectType
{
    Damage,
    Heal,
    Buff,
    Debuff
}

[CreateAssetMenu(fileName = "Ability", menuName = "Ability")]
public class Ability: ScriptableObject
{
    public string Name;
    public int AbilityID;
    public AbilityType AbilityType;
    public int RequiredSkillLevel;
    public EffectType EffectType;
    public float EffectMagnitude;
    public float EnergyCost;
    public float Range;
    public bool IsTargetSelf;
    public bool IsAOE;
    public bool IsEnabled;
    public Sprite Icon;
}
