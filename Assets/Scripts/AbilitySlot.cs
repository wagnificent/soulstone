using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
    public int AbilityIndex;
    public bool IsPrimary;
    
    private UIManager uIManager;
    private Button button;

    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenAbilityBank);
    }

    public void OpenAbilityBank()
    {
        uIManager.OpenAbilityBank(AbilityIndex, IsPrimary);
    }
}
