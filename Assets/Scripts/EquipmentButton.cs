using UnityEngine;
using UnityEngine.UI;

public class EquipmentButton : MonoBehaviour
{
    public int EquipmentType;
    public int ID;
    public int Slot;

    private UIManager uiManager;
    private Button b;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        b = GetComponent<Button>();
        b.onClick.AddListener(TryEquipItem);
    }

    private void TryEquipItem()
    {
        uiManager.TryEquipItem(EquipmentType, ID, Slot);
    }

}
