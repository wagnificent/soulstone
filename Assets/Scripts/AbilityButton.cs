using UnityEngine.UI;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    public int abilityID;
    public int abilityIndex;
    public bool isPrimary;

    private UIManager uiManager;
    private Button button;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(TryEquipAbility);
    }

    public void TryEquipAbility()
    {
        uiManager.TryEquipAbility(abilityID, abilityIndex, isPrimary);
    }
}
