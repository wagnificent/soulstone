using UnityEngine;
using UnityEngine.UI;

public enum ArmorType
{
    Light = 100,
    Medium = 200,
    Heavy = 300
}

[CreateAssetMenu(fileName = "Armor", menuName = "Armor")]
public class Armor : ScriptableObject
{
    public string Name;
    public int ArmorID;
    public ArmorType ArmorType;
    public float BaseProtection;
    public Sprite Icon;
}
