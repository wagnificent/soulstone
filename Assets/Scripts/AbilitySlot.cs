using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
    public Ability AbilityItem;

    private AbilitySelector abilitySelector;

    void Start()
    {
        abilitySelector = FindObjectOfType<AbilitySelector>();
    }

    public void EquipAsPrimary()
    {
        abilitySelector.EquipPrimaryAbility(AbilityItem);
    }

    public void EquipAsAlternate()
    {
        abilitySelector.EquipAlternateAbility(AbilityItem);
    }
}
