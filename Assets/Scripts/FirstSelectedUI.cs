using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelectedUI : MonoBehaviour
{
    public void SetFirstSelected(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
}