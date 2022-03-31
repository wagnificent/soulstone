using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public int EquipmentType;
    public int Slot;

    private UIManager uiMananager;
    private Button b;


    private void Awake()
    {
        uiMananager = FindObjectOfType<UIManager>();
        b = GetComponent<Button>();
        b.onClick.AddListener(OpenEquipmentBank);
    }

    private void OpenEquipmentBank()
    {
        uiMananager.OpenEquipmentBank(EquipmentType, Slot);
    }
}
