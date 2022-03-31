using UnityEngine;

public enum AbilityType
{
    Unarmed,
    OneHanded,
    TwoHanded,
    Archery,
    CombatMagic,
    VitalMagic,
    SupportMagic,
    UtilityMagic,
    Block,
    Dodge,
    Parry,
    Harden
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
